using Moq;
using PsychologyApp.Presentation.Pages.ManageProfile.AppLock;
using PsychologyApp.Presentation.Shared.Services.Security;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

/// <summary>The lock screen keeps personal content closed until an app PIN is set or verified.</summary>
public sealed class AppLockViewModelTests
{
    private readonly Mock<IDeviceAuthenticator> _authenticator = new();
    private readonly Mock<IAppPinCredentialStore> _pinStore = new();

    private AppLockViewModel Create(DeviceUnlockAvailability availability, DeviceUnlockResult result, bool hasPin = true)
    {
        _authenticator.SetupGet(a => a.Availability).Returns(availability);
        _authenticator.Setup(a => a.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(result);
        _pinStore.Setup(s => s.HasPinAsync()).ReturnsAsync(hasPin);
        _pinStore.Setup(s => s.VerifyPinAsync(It.IsAny<string>()))
            .ReturnsAsync(new AppPinVerificationResult(true, TimeSpan.Zero));
        return new AppLockViewModel(_authenticator.Object, _pinStore.Object);
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
    public async Task An_incorrect_app_pin_keeps_personal_content_closed()
    {
        _pinStore.Setup(s => s.VerifyPinAsync(It.IsAny<string>()))
            .ReturnsAsync(new AppPinVerificationResult(false, TimeSpan.Zero));
        AppLockViewModel viewModel = Create(DeviceUnlockAvailability.Available, DeviceUnlockResult.Passed);
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
