using CommunityToolkit.Maui.Views;
using Microsoft.Maui.ApplicationModel;
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
        CopyNumberButton.BodyText = AppStrings.DonateCopyNumber;
        CopyNumberButton.TapCommand = new AsyncCommand(CopyNumberAsync);
        SemanticProperties.SetDescription(CloseButton, AppStrings.Cancel);

        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, EventArgs e) =>
        UiAnimations.AnimateToastPopInAsync(SheetCardHost, slideOffset: 12).FireAndForget();

    private void OnDismissTapped(object? sender, TappedEventArgs e) =>
        CloseSheetAsync().FireAndForget();

    private void OnCloseTapped(object? sender, TappedEventArgs e) =>
        CloseSheetAsync().FireAndForget();

    private async Task OpenSberAsync()
    {
        await CloseSheetAsync();
        await Browser.Default.OpenAsync(DonationConfiguration.SberTransferUrl, BrowserLaunchMode.SystemPreferred);
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
