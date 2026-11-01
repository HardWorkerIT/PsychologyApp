namespace PsychologyApp.Application.Conversation.Companion;

public sealed record LocalModelFile(string Path, string Url, long SizeBytes, string? Sha256 = null, bool VerifySize = true);

/// <param name="Id">Changing the id (or any file) makes an installed copy count as outdated and triggers a reinstall.</param>
public sealed record LocalModelManifest(
    string Id,
    string DisplayName,
    string LicenseUrl,
    IReadOnlyList<LocalModelFile> Files,
    IReadOnlyList<string> Languages,
    long MinTotalMemoryBytes)
{
    public long TotalBytes => Files.Sum(f => f.SizeBytes);

    /// <summary>Languages enabled for guarded generation. Other languages always use scripted replies.</summary>
    public bool SupportsLanguage(bool english) => Languages.Contains(english ? "en" : "ru");
}

public sealed record ModelInstallProgress(long DownloadedBytes, long TotalBytes, string CurrentFile)
{
    public double Fraction => TotalBytes == 0 ? 0 : Math.Clamp((double)DownloadedBytes / TotalBytes, 0, 1);
}

/// <summary>Downloads the on-device model with the user's consent. The only place in the companion feature that touches the network.</summary>
public interface ILocalModelInstaller
{
    LocalModelManifest Manifest { get; }

    bool IsInstalled { get; }

    /// <summary>Resumes a previous partial download if there is one. Throws on network or integrity failure; the model stays uninstalled.</summary>
    Task InstallAsync(IProgress<ModelInstallProgress>? progress = null, CancellationToken cancellationToken = default);

    Task DeleteAsync(CancellationToken cancellationToken = default);
}

/// <summary>Fallback for platforms without an on-device model installer.</summary>
public sealed class NullLocalModelInstaller : ILocalModelInstaller
{
    public LocalModelManifest Manifest => LocalModelCatalog.Default;
    public bool IsInstalled => false;
    public Task InstallAsync(IProgress<ModelInstallProgress>? progress = null, CancellationToken cancellationToken = default) =>
        Task.FromException(new PlatformNotSupportedException("On-device model downloads are not supported on this platform."));
    public Task DeleteAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
}

/// <summary>What the phone can offer to a large on-device model. Zero means "unknown / not supported".</summary>
public interface IDeviceCapabilities
{
    long TotalMemoryBytes { get; }

    long FreeStorageBytes { get; }
}

public sealed class NullDeviceCapabilities : IDeviceCapabilities
{
    public long TotalMemoryBytes => 0;
    public long FreeStorageBytes => 0;
}

public enum LocalModelEligibility
{
    Eligible,
    NotEnoughMemory,
    NotEnoughStorage
}

public static class LocalModelEligibilityChecker
{
    /// <summary>Extra room beyond the model itself for temporary files and normal app use.</summary>
    private const double StorageHeadroom = 1.15;

    public static LocalModelEligibility Check(LocalModelManifest manifest, IDeviceCapabilities device)
    {
        if (device.TotalMemoryBytes < manifest.MinTotalMemoryBytes)
        {
            return LocalModelEligibility.NotEnoughMemory;
        }

        return device.FreeStorageBytes < manifest.TotalBytes * StorageHeadroom
            ? LocalModelEligibility.NotEnoughStorage
            : LocalModelEligibility.Eligible;
    }
}
