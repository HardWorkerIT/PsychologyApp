using Android.App;
using Android.Content;
using PsychologyApp.Application.DataBackup;
using AndroidUri = Android.Net.Uri;

namespace PsychologyApp.Presentation.Platforms.Android;

internal static class BackupDocumentPicker
{
    private const int RequestCode = 19841;
    private static (Activity Owner, TaskCompletionSource<AndroidUri?> Completion)? _pending;

    internal static async Task<string?> ReadAsync(string title, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Activity owner = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity
            ?? throw new IOException("The document picker has no host activity.");
        if (_pending is not null)
        {
            throw new IOException("The document picker is already open.");
        }

        TaskCompletionSource<AndroidUri?> result = new(TaskCreationOptions.RunContinuationsAsynchronously);
        using Intent pick = new(Intent.ActionOpenDocument);
        pick.AddCategory(Intent.CategoryOpenable);
        pick.SetType("*/*");
        using Intent chooser = Intent.CreateChooser(pick, title)
            ?? throw new IOException("Android could not create the document picker.");
        _pending = (owner, result);
        try
        {
#pragma warning disable CS0618 // The host receives the result, retaining the document grant without copying it to cache.
            owner.StartActivityForResult(chooser, RequestCode);
#pragma warning restore CS0618
        }
        catch (ActivityNotFoundException)
        {
            _pending = null;
            throw new IOException("No Android document picker is available.");
        }
        catch
        {
            _pending = null;
            throw;
        }

        using CancellationTokenRegistration registration = cancellationToken.Register(() => result.TrySetCanceled(cancellationToken));
        using AndroidUri? document = await result.Task;
        if (document is null)
        {
            return null;
        }

        if (!string.Equals(document.Scheme, "content", StringComparison.Ordinal))
        {
            throw new IOException("The picker did not return a document stream.");
        }

        try
        {
            return await Task.Run(async () =>
            {
                using Stream source = owner.ContentResolver?.OpenInputStream(document)
                    ?? throw new IOException("The selected document could not be opened.");
                return await BackupFileReader.ReadAsync(source, cancellationToken).ConfigureAwait(false);
            }, cancellationToken);
        }
        catch (Exception ex) when (ex is Java.IO.IOException or Java.Lang.SecurityException)
        {
            throw new IOException("Android could not read the selected document.");
        }
    }

    internal static void OnActivityResult(Activity owner, int requestCode, Result result, Intent? data)
    {
        if (requestCode == RequestCode && _pending is { } pending && ReferenceEquals(pending.Owner, owner))
        {
            _pending = null;
            AndroidUri? document = result == Result.Ok ? data?.Data : null;
            if (!pending.Completion.TrySetResult(document))
            {
                document?.Dispose();
            }
        }
    }

    internal static void OnDestroyed(Activity owner)
    {
        OnActivityResult(owner, RequestCode, Result.Canceled, null);
    }
}
