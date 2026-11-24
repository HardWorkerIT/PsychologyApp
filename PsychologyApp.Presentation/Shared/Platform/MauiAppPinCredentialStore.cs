using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Maui.Storage;
using PsychologyApp.Presentation.Shared.Services.Security;

namespace PsychologyApp.Presentation.Shared.Platform;

/// <summary>Stores only a salted PBKDF2 verifier in platform-protected storage; the PIN itself is never persisted.</summary>
public sealed class MauiAppPinCredentialStore : IAppPinCredentialStore
{
    private const string StorageKey = "app.pin.verifier.v1";
    private const string FailedAttemptsKey = "AppLockPinFailedAttempts";
    private const string LockoutLevelKey = "AppLockPinLockoutLevel";
    private const string LockoutUntilKey = "AppLockPinLockoutUntilUtc";
    private const int IterationCount = 210_000;
    private const int SaltLength = 16;
    private const int HashLength = 32;
    private const int AttemptsBeforeLockout = 5;
    private const int InitialLockoutSeconds = 30;
    private const int MaximumLockoutSeconds = 300;

    private readonly SemaphoreSlim _gate = new(1, 1);

    public async Task<bool> HasPinAsync()
    {
        await _gate.WaitAsync().ConfigureAwait(false);
        try
        {
            string? record = await SecureStorage.Default.GetAsync(StorageKey).ConfigureAwait(false);
            if (record is null)
            {
                return false;
            }

            _ = ParseRecord(record);
            return true;
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task SetPinAsync(string pin)
    {
        if (!AppPinPolicy.IsValid(pin))
        {
            throw new ArgumentException($"A PIN must contain exactly {AppPinPolicy.Length} digits.", nameof(pin));
        }

        await _gate.WaitAsync().ConfigureAwait(false);
        try
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltLength);
            byte[] password = Encoding.ASCII.GetBytes(pin);
            byte[] hash = [];
            try
            {
                hash = await Task.Run(() => Rfc2898DeriveBytes.Pbkdf2(
                    password, salt, IterationCount, HashAlgorithmName.SHA256, HashLength)).ConfigureAwait(false);
                string record = string.Join('$',
                    "v1",
                    IterationCount.ToString(CultureInfo.InvariantCulture),
                    Convert.ToBase64String(salt),
                    Convert.ToBase64String(hash));
                await SecureStorage.Default.SetAsync(StorageKey, record).ConfigureAwait(false);
                ClearLockout();
            }
            finally
            {
                CryptographicOperations.ZeroMemory(password);
                CryptographicOperations.ZeroMemory(hash);
                CryptographicOperations.ZeroMemory(salt);
            }
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task<AppPinVerificationResult> VerifyPinAsync(string pin)
    {
        if (!AppPinPolicy.IsValid(pin))
        {
            return new(false, TimeSpan.Zero);
        }

        await _gate.WaitAsync().ConfigureAwait(false);
        try
        {
            TimeSpan retryAfter = GetRetryAfter();
            if (retryAfter > TimeSpan.Zero)
            {
                return new(false, retryAfter);
            }

            string? record = await SecureStorage.Default.GetAsync(StorageKey).ConfigureAwait(false);
            if (record is null)
            {
                return new(false, TimeSpan.Zero);
            }

            (int iterations, byte[] salt, byte[] expectedHash) = ParseRecord(record);
            byte[] password = Encoding.ASCII.GetBytes(pin);
            byte[] actualHash = [];
            try
            {
                actualHash = await Task.Run(() => Rfc2898DeriveBytes.Pbkdf2(
                    password, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length)).ConfigureAwait(false);
                bool isValid = CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
                if (isValid)
                {
                    ClearLockout();
                    return new(true, TimeSpan.Zero);
                }

                return new(false, RegisterFailure());
            }
            finally
            {
                CryptographicOperations.ZeroMemory(password);
                CryptographicOperations.ZeroMemory(actualHash);
                CryptographicOperations.ZeroMemory(expectedHash);
                CryptographicOperations.ZeroMemory(salt);
            }
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task ClearPinAsync()
    {
        await _gate.WaitAsync().ConfigureAwait(false);
        try
        {
#if ANDROID
            await Task.Run(ClearAndroidPin).ConfigureAwait(false);
#else
            if (!SecureStorage.Default.Remove(StorageKey)
                && await SecureStorage.Default.GetAsync(StorageKey).ConfigureAwait(false) is not null)
            {
                throw new IOException("The stored app PIN verifier could not be removed.");
            }
#endif
            ClearLockout();
        }
        finally
        {
            _gate.Release();
        }
    }

#if ANDROID
    private static void ClearAndroidPin()
    {
        // MAUI SecureStorage.Remove uses Apply. Erasure shuts down the process immediately, so use the
        // same encrypted preferences with Commit to persist the deletion without touching the database key.
        var context = Microsoft.Maui.ApplicationModel.Platform.AppContext;
        string alias = $"{context.PackageName}.microsoft.maui.essentials.preferences";
#pragma warning disable CS0618 // Match the encrypted preference format used by MAUI SecureStorage.
        using var builder = new AndroidX.Security.Crypto.MasterKey.Builder(context, alias);
        builder.SetKeyScheme(AndroidX.Security.Crypto.MasterKey.KeyScheme.Aes256Gcm);
        using var key = builder.Build() ?? throw new IOException("The app secure storage key is unavailable.");
        using var preferences = AndroidX.Security.Crypto.EncryptedSharedPreferences.Create(context, alias, key,
            AndroidX.Security.Crypto.EncryptedSharedPreferences.PrefKeyEncryptionScheme.Aes256Siv,
            AndroidX.Security.Crypto.EncryptedSharedPreferences.PrefValueEncryptionScheme.Aes256Gcm)
            ?? throw new IOException("The app secure storage is unavailable.");
#pragma warning restore CS0618
        using var editor = preferences.Edit();
        if (editor?.Remove(StorageKey)?.Commit() != true)
        {
            throw new IOException("The stored app PIN verifier could not be removed.");
        }
    }
#endif

    private static (int Iterations, byte[] Salt, byte[] Hash) ParseRecord(string record)
    {
        string[] parts = record.Split('$');
        if (parts.Length != 4
            || parts[0] != "v1"
            || !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out int iterations)
            || iterations is < 100_000 or > 500_000)
        {
            throw new InvalidOperationException("The stored app PIN verifier is invalid.");
        }

        try
        {
            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] hash = Convert.FromBase64String(parts[3]);
            if (salt.Length != SaltLength || hash.Length != HashLength)
            {
                CryptographicOperations.ZeroMemory(salt);
                CryptographicOperations.ZeroMemory(hash);
                throw new InvalidOperationException("The stored app PIN verifier is invalid.");
            }

            return (iterations, salt, hash);
        }
        catch (FormatException ex)
        {
            throw new InvalidOperationException("The stored app PIN verifier is invalid.", ex);
        }
    }

    private static TimeSpan GetRetryAfter()
    {
        long until = Preferences.Default.Get(LockoutUntilKey, 0L);
        long remaining = until - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return remaining > 0 ? TimeSpan.FromSeconds(remaining) : TimeSpan.Zero;
    }

    private static TimeSpan RegisterFailure()
    {
        int failedAttempts = Preferences.Default.Get(FailedAttemptsKey, 0) + 1;
        if (failedAttempts < AttemptsBeforeLockout)
        {
            Preferences.Default.Set(FailedAttemptsKey, failedAttempts);
            return TimeSpan.Zero;
        }

        int level = Preferences.Default.Get(LockoutLevelKey, 0) + 1;
        int seconds = Math.Min(InitialLockoutSeconds * (1 << Math.Min(level - 1, 4)), MaximumLockoutSeconds);
        Preferences.Default.Set(FailedAttemptsKey, 0);
        Preferences.Default.Set(LockoutLevelKey, level);
        Preferences.Default.Set(LockoutUntilKey, DateTimeOffset.UtcNow.ToUnixTimeSeconds() + seconds);
        return TimeSpan.FromSeconds(seconds);
    }

    private static void ClearLockout()
    {
        Preferences.Default.Remove(FailedAttemptsKey);
        Preferences.Default.Remove(LockoutLevelKey);
        Preferences.Default.Remove(LockoutUntilKey);
    }
}
