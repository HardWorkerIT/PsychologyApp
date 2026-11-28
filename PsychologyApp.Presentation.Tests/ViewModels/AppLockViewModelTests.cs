using Moq;
using PsychologyApp.Presentation.Pages.ManageProfile.AppLock;
using PsychologyApp.Presentation.Shared.Services.Clipboard;
using PsychologyApp.Presentation.Shared.UI.Overlays;
using PsychologyApp.Presentation.Shared.Services.Security;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

/// <summary>The lock screen keeps personal content closed until an app PIN is set or verified.</summary>
[Collection("StaticShims")]
public sealed class AppLockViewModelTests
{
    private readonly Mock<IDeviceAuthenticator> _authenticator = new();
    private readonly Mock<IAppPinCredentialStore> _pinStore = new();
    private readonly Mock<IAppClipboardService> _clipboard = new();

    private AppLockViewModel Create(DeviceUnlockAvailability availability, DeviceUnlockResult result, bool hasPin = true, TimeProvider? clock = null)
    {
        _authenticator.SetupGet(a => a.Availability).Returns(availability);
        _authenticator.Setup(a => a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(result);
        _pinStore.Setup(s => s.HasPinAsync()).ReturnsAsync(hasPin);
        _pinStore.Setup(s => s.VerifyPinAsync(It.IsAny<string>()))
            .ReturnsAsync(new AppPinVerificationResult(true, TimeSpan.Zero));
        return new AppLockViewModel(_authenticator.Object, _pinStore.Object, _clipboard.Object, clock);
    }

    [Fact]
    public async Task A_pin_lockout_disables_the_keypad_until_the_wait_expires()
    {
        var clock = new PinTestClock();
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed, clock: clock);
        _pinStore.SetupSequence(store => store.VerifyPinAsync("123456"))
            .ReturnsAsync(new AppPinVerificationResult(false, TimeSpan.FromSeconds(3)))
            .ReturnsAsync(new AppPinVerificationResult(true, TimeSpan.Zero));
        await viewModel.InitializeAsync();
        viewModel.PinInput = "123456";
        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);

        viewModel.AddPinDigitCommand.Execute("1");
        Assert.Empty(viewModel.PinInput);
        Assert.False(viewModel.CanEnterPin);
        Assert.True(viewModel.HasSystemRecovery);
        Assert.Equal(AppStrings.AppLockPinLockedOut(3), viewModel.StatusText);

        clock.Seconds = 2;
        viewModel.RefreshPinCooldown();
        Assert.Equal(AppStrings.AppLockPinLockedOut(1), viewModel.StatusText);
        Assert.False(viewModel.CanEnterPin);

        clock.Seconds = 3;
        viewModel.RefreshPinCooldown();
        Assert.True(viewModel.CanEnterPin);
        Assert.False(viewModel.HasStatus);
        viewModel.PinInput = "123456";
        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);
        Assert.True(viewModel.Unlocked.IsCompletedSuccessfully);
    }

    private sealed class PinTestClock : TimeProvider
    {
        public long Seconds { get; set; }
        public override long TimestampFrequency => TimeSpan.TicksPerSecond;
        public override long GetTimestamp() => Seconds * TimeSpan.TicksPerSecond;
    }

    [Fact]
    public async Task A_correct_app_pin_opens_the_app()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
        await viewModel.InitializeAsync();
        viewModel.PinInput = "123456";

        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);

        Assert.True(viewModel.Unlocked.IsCompletedSuccessfully);
        _pinStore.Verify(s => s.VerifyPinAsync("123456"), Times.Once);
    }

    [Fact]
    public async Task A_slow_verification_keeps_the_masked_entry_and_shows_that_the_pin_is_being_checked()
    {
        AppLockViewModel vm = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
        var verification = new TaskCompletionSource<AppPinVerificationResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        _pinStore.Setup(s => s.VerifyPinAsync("123456")).Returns(verification.Task);
        await vm.InitializeAsync();
        vm.PinInput = "123456";
        vm.SubmitPinCommand.Execute(null);

        Assert.False(vm.CanEnterPin);
        Assert.Equal(AppStrings.AppLockCheckingPin, vm.StatusText);
        Assert.All(vm.PinCells, cell => Assert.True(cell));
        Assert.False(vm.Unlocked.IsCompleted);

        verification.SetResult(new(false, TimeSpan.Zero));
        await VmTestHelpers.WaitUntilAsync(() => vm.SubmitPinCommand.CanExecute(null));
        Assert.True(vm.CanEnterPin);
        Assert.Equal(AppStrings.AppLockPinIncorrect, vm.StatusText);
        Assert.All(vm.PinCells, cell => Assert.False(cell));
    }

    [Fact]
    public async Task Storage_retry_without_phone_credentials_requires_an_existing_pin_and_keeps_the_app_locked()
    {
        AppLockViewModel vm = Create(DeviceUnlockAvailability.NoScreenLock, DeviceUnlockResult.CannotAsk);
        _authenticator.SetupGet(a => a.CanOpenSecuritySettings).Returns(true);
        _authenticator.Setup(a => a.TryOpenSecuritySettingsAsync()).ReturnsAsync(true);
        _pinStore.SetupSequence(s => s.HasPinAsync())
            .ThrowsAsync(new IOException())
            .ReturnsAsync(false)
            .ReturnsAsync(true);
        await vm.InitializeAsync();

        Assert.True(vm.ShowRetryStorage);
        Assert.True(vm.CanOpenSecuritySettings);
        Assert.False(vm.HasSystemRecovery);
        await VmTestHelpers.RunAsync(vm.OpenSecuritySettingsCommand);
        _authenticator.Verify(a => a.TryOpenSecuritySettingsAsync(), Times.Once);

        await VmTestHelpers.RunAsync(vm.RetryPinStorageCommand);
        Assert.False(vm.IsPinEntryVisible);
        Assert.Equal(AppStrings.AppLockStorageStillUnavailable, vm.StatusText);

        await VmTestHelpers.RunAsync(vm.RetryPinStorageCommand);
        Assert.True(vm.IsPinEntryVisible);
        Assert.False(vm.ShowRetryStorage);
        Assert.False(vm.Unlocked.IsCompleted);
        _pinStore.Verify(s => s.SetPinAsync(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task An_incorrect_app_pin_keeps_personal_content_closed()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
        _pinStore.Setup(s => s.VerifyPinAsync(It.IsAny<string>()))
            .ReturnsAsync(new AppPinVerificationResult(false, TimeSpan.Zero));
        await viewModel.InitializeAsync();
        viewModel.PinInput = "123456";

        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);

        Assert.False(viewModel.Unlocked.IsCompleted);
        Assert.True(viewModel.HasStatus);
    }

    [Fact]
    public async Task The_first_launch_requires_a_pin_to_be_created_and_confirmed()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed, hasPin: false);
        await viewModel.InitializeAsync();
        viewModel.PinInput = "123456";
        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);
        Assert.False(viewModel.Unlocked.IsCompleted);

        viewModel.PinInput = "123456";
        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);

        Assert.True(viewModel.Unlocked.IsCompletedSuccessfully);
        _pinStore.Verify(s => s.SetPinAsync("123456"), Times.Once);
    }

    [Fact]
    public async Task UnavailablePhoneAuthenticationKeepsTheAppLockedAndAllowsRetry()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.CannotAsk);
        await viewModel.InitializeAsync();

        await VmTestHelpers.RunAsync(viewModel.RecoverPinCommand);

        Assert.False(viewModel.Unlocked.IsCompleted);
        Assert.True(viewModel.HasSystemRecovery);
        Assert.Equal(AppStrings.AppLockPhoneUnlockUnavailable, viewModel.StatusText);
        viewModel.PinInput = "123456";
        await VmTestHelpers.RunAsync(viewModel.SubmitPinCommand);
        Assert.True(viewModel.Unlocked.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task An_unavailable_dialer_leaves_instructions_visible_without_unlocking_the_app()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
        await viewModel.InitializeAsync();
        Launcher.FailWith = new InvalidOperationException("No dialer");
        try
        {
            await VmTestHelpers.RunAsync(viewModel.CallEmergencyCommand);

            Assert.True(viewModel.ShowDialFailure);
            Assert.False(string.IsNullOrWhiteSpace(viewModel.DialFailureText));
            await VmTestHelpers.RunAsync(viewModel.CopyNumberCommand);
            _clipboard.Verify(service => service.CopyWithFeedbackAsync(
                It.Is<string>(number => viewModel.DialFailureText.Contains(number)), AppStrings.QuoteCopied, AppToastKind.Success), Times.Once);
            Assert.False(viewModel.Unlocked.IsCompleted);
        }
        finally
        {
            Launcher.FailWith = null;
        }
    }

    [Fact]
    public async Task A_secure_storage_error_keeps_the_app_locked_and_offers_phone_recovery()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
        _pinStore.Setup(s => s.HasPinAsync()).ThrowsAsync(new IOException("Secure storage unavailable"));
        await viewModel.InitializeAsync();

        Assert.False(viewModel.IsPinEntryVisible);
        Assert.True(viewModel.HasSystemRecovery);
        Assert.False(viewModel.Unlocked.IsCompleted);

        await VmTestHelpers.RunAsync(viewModel.RecoverPinCommand);

        Assert.True(viewModel.IsPinEntryVisible);
        Assert.False(viewModel.Unlocked.IsCompleted);
        _authenticator.Verify(a => a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task Phone_authentication_starts_pin_recovery_but_does_not_skip_new_pin_setup()
    {
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
        await viewModel.InitializeAsync();

        await VmTestHelpers.RunAsync(viewModel.RecoverPinCommand);

        Assert.False(viewModel.Unlocked.IsCompleted);
        Assert.True(viewModel.IsPinEntryVisible);
        _authenticator.Verify(a => a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}
