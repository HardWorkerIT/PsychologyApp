using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Devices;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class AdsDisclosurePopup : Popup
{
    private bool _isClosing;

    public AdsDisclosurePopup()
    {
        InitializeComponent();
        TitleLabel.Text = AppStrings.AdsDisclosureTitle;
        MayReceiveTitleLabel.Text = AppStrings.AdsDisclosureMayReceiveTitle;
        MayReceiveBodyLabel.Text = AppStrings.AdsDisclosureMayReceiveBody;
        OnDeviceTitleLabel.Text = AppStrings.AdsDisclosureOnDeviceTitle;
        OnDeviceBodyLabel.Text = AppStrings.AdsDisclosureOnDeviceBody;
        PrivacyPolicyLabel.Text = AppStrings.AdsPrivacyPolicy;
        DoneButton.BodyText = AppStrings.AdsDisclosureDone;
        DoneButton.TapCommand = new Command(ClosePopup);
        SemanticProperties.SetDescription(CloseButton, AppStrings.Cancel);
        SemanticProperties.SetDescription(PrivacyPolicyLink, AppStrings.AdsPrivacyPolicy);
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, EventArgs e)
    {
        ApplyHostSize();
        UiAnimations.AnimateToastPopInAsync(SheetCardHost, slideOffset: 12).FireAndForget();
    }

    private void ApplyHostSize()
    {
        Window? window = Microsoft.Maui.Controls.Application.Current?.Windows.FirstOrDefault();
        double width;
        double height;
        if (window is not null && window.Width > 0 && window.Height > 0)
        {
            width = window.Width;
            height = window.Height;
        }
        else
        {
            DisplayInfo display = DeviceDisplay.MainDisplayInfo;
            width = display.Width / display.Density;
            height = display.Height / display.Density;
        }

        SheetHost.WidthRequest = width;
        SheetHost.HeightRequest = height;
        SheetCard.MaximumHeightRequest = Math.Max(240, height - 112);
        DisclosureScroll.MaximumHeightRequest = Math.Max(140, Math.Min(500, height - 320));
    }

    private void OnCloseTapped(object? sender, TappedEventArgs e) => ClosePopup();

    private void OnDismissTapped(object? sender, TappedEventArgs e) => ClosePopup();

    private void OnPrivacyPolicyTapped(object? sender, TappedEventArgs e) =>
        SafeAsync.Run(OpenPrivacyPolicyAsync);

    private async Task OpenPrivacyPolicyAsync()
    {
        if (!AdvertisingConfiguration.IsPrivacyPolicyConfigured)
        {
            return;
        }

        try
        {
            await Browser.Default.OpenAsync(AdvertisingConfiguration.PrivacyPolicyUrl, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception error)
        {
            BestEffort.Report(error);
        }
    }

    private void ClosePopup()
    {
        if (_isClosing)
        {
            return;
        }

        _isClosing = true;
        SafeAsync.Run(async () =>
        {
            await UiAnimations.AnimateToastPopOutAsync(SheetCardHost, slideOffset: 12);
            await CloseAsync();
        });
    }
}
