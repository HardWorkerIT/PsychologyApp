using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using PsychologyApp.Presentation.Features.ManageProfile;
using PsychologyApp.Presentation.Pages.ManageProfile.AppLock;
using PsychologyApp.Presentation.Shared.Services.Security;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

[Collection("StaticShims")]
public sealed class AppLockCoordinatorTests
{
    [Theory]
    [InlineData(DeviceUnlockAvailability.Available)]
    [InlineData(DeviceUnlockAvailability.NoScreenLock)]
    public async Task AnExistingPinKeepsPersonalContentHiddenUntilTheFallbackAuthenticates(DeviceUnlockAvailability availability)
    {
        Mock<INavigation> navigation = new();
        navigation.Setup(n => n.PushModalAsync(It.IsAny<Page>(), false))
            .ThrowsAsync(new InvalidOperationException("Navigation unavailable"));
        Page privatePage = new() { Handler = new object(), Navigation = navigation.Object };
        Window window = new(privatePage);
        var app = new Microsoft.Maui.Controls.Application();
        var previous = Microsoft.Maui.Controls.Application.Current;
        app.Windows.Add(window);
        Microsoft.Maui.Controls.Application.Current = app;

        Mock<IDeviceAuthenticator> authenticator = new();
        authenticator.SetupGet(a => a.Availability).Returns(availability);
        Mock<IAppPinCredentialStore> pins = new();
        pins.Setup(p => p.HasPinAsync()).ReturnsAsync(true);
        pins.Setup(p => p.VerifyPinAsync("123456")).ReturnsAsync(new AppPinVerificationResult(true, TimeSpan.Zero));
        AppLockCoordinator coordinator = new(authenticator.Object, pins.Object, NullLogger<AppLockCoordinator>.Instance);

        try
        {
            Preferences.Default.Remove("AppLockEnabled");
            Task guard = coordinator.GuardAsync();

            Assert.True(coordinator.IsCovering);
            Assert.False(guard.IsCompleted);
            AppLockPage fallback = Assert.IsType<AppLockPage>(window.Page);
            await fallback.ViewModel.InitializeAsync();
            fallback.ViewModel.PinInput = "123456";
            await VmTestHelpers.RunAsync(fallback.ViewModel.SubmitPinCommand);
            await guard.WaitAsync(TimeSpan.FromSeconds(3));

            Assert.Same(privatePage, window.Page);
            Assert.False(coordinator.IsCovering);
            Assert.True(Preferences.Default.Get("AppLockEnabled", false));
        }
        finally
        {
            Preferences.Default.Remove("AppLockEnabled");
            Microsoft.Maui.Controls.Application.Current = previous;
        }
    }
}
