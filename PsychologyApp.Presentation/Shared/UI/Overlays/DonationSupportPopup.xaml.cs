using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Devices;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Services.Clipboard;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class DonationSupportPopup : Popup
{
    private readonly IAppClipboardService _clipboardService;
    private bool _isClosing;

    public DonationSupportPopup(IAppClipboardService clipboardService)
    {
        _clipboardService = clipboardService;
        InitializeComponent();

        TitleLabel.Text = AppStrings.OptionsDonateTitle;
        IntroLabel.Text = AppStrings.DonateBody;
        PaymentMethodLabel.Text = AppStrings.DonatePaymentMethod;
        RecipientLabel.Text = AppStrings.DonateMaskedRecipient;
        BankCheckNoteLabel.Text = AppStrings.DonateBankCheckNote;
        OpenSberButton.BodyText = AppStrings.DonateOpenSber;
        OpenSberButton.TapCommand = new AsyncCommand(OpenSberAsync);
        OpenSberButton.IsVisible = CanOpenSberApp();
        CopyNumberButton.BodyText = AppStrings.DonateCopyNumber;
        CopyNumberButton.TapCommand = new AsyncCommand(CopyNumberAsync);
        CancelLabel.Text = AppStrings.Cancel;
        SemanticProperties.SetDescription(CancelHost, AppStrings.Cancel);

        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, EventArgs e)
    {
        ApplyHostSize();
        UiAnimations.AnimateToastPopInAsync(SheetCardHost, slideOffset: 12).FireAndForget();
    }

    private void ApplyHostSize()
    {
        if (GetUsableWindowSize() is (double width, double height))
        {
            SheetHost.WidthRequest = width;
            SheetHost.HeightRequest = height;
            ContentScroll.MaximumHeightRequest = GetBodyMaximumHeight(height);
            return;
        }

        DisplayInfo display = DeviceDisplay.MainDisplayInfo;
        double displayWidth = display.Width / display.Density;
        double displayHeight = display.Height / display.Density;
        SheetHost.WidthRequest = displayWidth;
        SheetHost.HeightRequest = displayHeight;
        ContentScroll.MaximumHeightRequest = GetBodyMaximumHeight(displayHeight);
    }

    private static double GetBodyMaximumHeight(double windowHeight) =>
        Math.Max(96, Math.Min(520, windowHeight - 180));

    private static (double Width, double Height)? GetUsableWindowSize()
    {
        Window? window = Microsoft.Maui.Controls.Application.Current?.Windows.FirstOrDefault();
        if (window is null || window.Width <= 0 || window.Height <= 0)
        {
            return null;
        }

        return (window.Width, window.Height);
    }

    private void OnDismissTapped(object? sender, TappedEventArgs e) =>
        CloseSheetAsync().FireAndForget();

    private void OnCancelTapped(object? sender, TappedEventArgs e) =>
        CloseSheetAsync().FireAndForget();

    private async Task OpenSberAsync()
    {
        await CloseSheetAsync();
#if ANDROID
        var launchIntent = Android.App.Application.Context.PackageManager?
            .GetLaunchIntentForPackage("ru.sberbankmobile");
        if (launchIntent is not null && Microsoft.Maui.ApplicationModel.Platform.CurrentActivity is { } activity)
        {
            try
            {
                activity.StartActivity(launchIntent);
                return;
            }
            catch (Android.Content.ActivityNotFoundException)
            {
                // No web fallback: the supplied Sber URL fails certificate validation on some devices.
            }
        }
#endif
        await _clipboardService.CopyWithFeedbackAsync(
            DonationConfiguration.SberTransferPhoneNumber,
            AppStrings.DonateNumberCopied);
    }

    private static bool CanOpenSberApp()
    {
#if ANDROID
        return Android.App.Application.Context.PackageManager?
            .GetLaunchIntentForPackage("ru.sberbankmobile") is not null;
#else
        return false;
#endif
    }

    private async Task CopyNumberAsync()
    {
        await CloseSheetAsync();
        await _clipboardService.CopyWithFeedbackAsync(
            DonationConfiguration.SberTransferPhoneNumber,
            AppStrings.DonateNumberCopied);
    }

    private async Task CloseSheetAsync()
    {
        if (_isClosing)
        {
            return;
        }

        _isClosing = true;
        await UiAnimations.AnimateToastPopOutAsync(SheetCardHost, slideOffset: 12);
        await CloseAsync();
    }
}
