using Microsoft.Extensions.Logging;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Chat;

namespace PsychologyApp.Presentation.Features.ManageProfile;

/// <summary>
/// The database file is replaced by an empty one (journal, practices, tests, chats, safety plan, body log, drafts, saved
/// quotes), settings are cleared, the logs are deleted, and so are the app's own files in the cache: an exported journal,
/// backup, summary or error log waiting to be shared, and a picked backup the file picker copied there. The rest of the cache is
/// left alone: it holds the icon fonts MAUI unpacks there, the system's compiled code and downloaded music, none of it the
/// person's. The database key stays: it protects the new, empty file just as well. Android starts a fresh process; on iOS and
/// Mac Catalyst, the app replaces its screens and in-memory preferences before returning to onboarding.
/// </summary>
public sealed class PersonalDataEraser(
    IDatabaseInitializer database,
    IPersonalDataEraseLifecycle eraseLifecycle,
    IChatService chat,
    ILogger<PersonalDataEraser> logger) : IPersonalDataEraser
{
    // Screens are detached before the database operation on platforms that cannot restart the process. Android exits inside the
    // exclusive callback, before a queued write can reach the replacement database.
    public async Task EraseAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await eraseLifecycle.PrepareForEraseAsync();
            if (chat is IChatEraseLifecycle chatEraseLifecycle)
            {
                await chatEraseLifecycle.PrepareForEraseAsync();
            }

            await database.RecreateDatabaseAsync(() =>
            {
                DeleteFilesAndSettings();
#if ANDROID
                Restart();
#endif
                return Task.CompletedTask;
            }, cancellationToken);
        }
        finally
        {
            if (chat is IChatEraseLifecycle chatEraseLifecycle)
            {
                chatEraseLifecycle.CompleteErase();
            }

            await eraseLifecycle.CompleteEraseAsync();
        }
    }

    private void DeleteFilesAndSettings()
    {
        bool allFilesDeleted = DeleteQuietly(Path.Combine(FileSystem.AppDataDirectory, "logs"));
        allFilesDeleted &= DeleteOwnCacheFiles();

        ClearPreferences();
        if (!allFilesDeleted)
        {
            throw new IOException("Some app-owned files could not be deleted.");
        }

        logger.LogInformation("All personal data was deleted");
    }

    private bool DeleteOwnCacheFiles()
    {
        string cacheDirectory = FileSystem.CacheDirectory;
        FileAttributes rootAttributes;
        try
        {
            rootAttributes = File.GetAttributes(cacheDirectory);
        }
        catch (FileNotFoundException)
        {
            return true;
        }
        catch (DirectoryNotFoundException)
        {
            return true;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            logger.LogWarning(ex, "The cache directory could not be inspected while erasing the data");
            return false;
        }

        if ((rootAttributes & FileAttributes.Directory) == 0 || (rootAttributes & FileAttributes.ReparsePoint) != 0)
        {
            logger.LogWarning("The cache root is not a regular app directory; its contents were left untouched");
            return false;
        }

        bool complete = true;
        Stack<string> directories = new();
        directories.Push(cacheDirectory);
        while (directories.Count > 0)
        {
            string directory = directories.Pop();
            string[] entries;
            try
            {
                entries = Directory.GetFileSystemEntries(directory);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                complete = false;
                logger.LogWarning(ex, "A cache directory could not be scanned while erasing the data");
                continue;
            }

            foreach (string entry in entries)
            {
                try
                {
                    FileAttributes attributes = File.GetAttributes(entry);
                    if ((attributes & FileAttributes.Directory) != 0)
                    {
                        // Do not follow a link out of the app cache while searching for files to delete.
                        if ((attributes & FileAttributes.ReparsePoint) == 0)
                        {
                            directories.Push(entry);
                        }

                        continue;
                    }

                    if (SharedFileNames.IsOwn(Path.GetFileName(entry)) && !DeleteQuietly(entry))
                    {
                        complete = false;
                    }
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    complete = false;
                    logger.LogWarning(ex, "A cache entry could not be inspected while erasing the data");
                }
            }
        }

        return complete;
    }

    // Keep trying the remaining files after a failure; the caller reports incomplete erasure after cleanup finishes.
    private bool DeleteQuietly(string path)
    {
        try
        {
            FileAttributes attributes = File.GetAttributes(path);
            bool isDirectory = (attributes & FileAttributes.Directory) != 0;
            bool isLink = (attributes & FileAttributes.ReparsePoint) != 0;
            if (isDirectory)
            {
                Directory.Delete(path, recursive: !isLink);
            }
            else
            {
                File.Delete(path);
            }

            return true;
        }
        catch (FileNotFoundException)
        {
            return true;
        }
        catch (DirectoryNotFoundException)
        {
            return true;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            logger.LogWarning(ex, "A file could not be deleted while erasing the data");
            return false;
        }
    }

    /// <summary>
    /// On Android, Preferences.Clear writes to disk in the background; the restart ends the process at once, before that write
    /// lands, and the old settings came back (onboarding counted as done). The file MAUI uses is cleared and committed here instead.
    /// </summary>
    private static void ClearPreferences()
    {
#if ANDROID
        global::Android.Content.Context context = Platform.AppContext;
        bool committed = context.GetSharedPreferences($"{context.PackageName}_preferences", global::Android.Content.FileCreationMode.Private)?
            .Edit()?
            .Clear()?
            .Commit() ?? false;
        if (!committed)
        {
            throw new InvalidOperationException("App preferences could not be cleared from disk.");
        }
#else
        Preferences.Default.Clear();
#endif
    }

    private static void Restart()
    {
#if ANDROID
        // The new launch is asked for while the app is still in front, then this process ends: Android starts the app in a
        // fresh process, with nothing of the old state left in memory.
        global::Android.App.Activity? activity = Platform.CurrentActivity;
        if (activity?.PackageManager?.GetLaunchIntentForPackage(activity.PackageName!) is { } launch)
        {
            launch.AddFlags(global::Android.Content.ActivityFlags.NewTask | global::Android.Content.ActivityFlags.ClearTask);
            activity.StartActivity(launch);
        }

        Java.Lang.JavaSystem.Exit(0);
#endif
    }
}
