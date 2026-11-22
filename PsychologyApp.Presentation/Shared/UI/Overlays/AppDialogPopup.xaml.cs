using CommunityToolkit.Maui.Views;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class AppDialogPopup : Popup
{
    private readonly AppDialogInput? _input;
    private bool _useBottomSheet;
    private bool _isClosing;

    public AppDialogPopup(
        string? title,
        string message,
        string accept,
        string? cancel,
        AppDialogInput? input = null,
        bool useBottomSheet = false,
        bool isDestructive = false)
    {
        InitializeComponent();

        _input = input;
        if (useBottomSheet)
        {
            ConfigureBottomSheet(accept, cancel, isDestructive);
        }

        if (input is not null)
        {
            if (!useBottomSheet)
            {
                Microsoft.Maui.Devices.DisplayInfo display = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo;
                double screenWidthDp = display.Width / Math.Max(1d, display.Density);
                DialogCardHost.Margin = new Thickness(16, 24);
                DialogCardHost.HorizontalOptions = LayoutOptions.Fill;
                DialogCard.MaximumWidthRequest = 320;
                DialogCard.WidthRequest = Math.Min(320d, Math.Max(280d, screenWidthDp - 32d));
                DialogCard.HorizontalOptions = LayoutOptions.Fill;
            }

            InputBorder.IsVisible = true;
            InputEntry.IsPassword = input.IsPassword;
            InputEntry.Placeholder = input.Placeholder;
            InputEntry.Text = input.InitialText;
            InputEntry.MaxLength = input.MaxLength;
            SemanticProperties.SetDescription(InputEntry, input.Placeholder);
            AcceptLabel.LineBreakMode = LineBreakMode.NoWrap;
            CancelLabel.LineBreakMode = LineBreakMode.NoWrap;
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            TitleLabel.IsVisible = false;
        }
        else
        {
            TitleLabel.Text = title;
        }

        MessageLabel.Text = message;
        MessageLabel.IsVisible = !string.IsNullOrWhiteSpace(message);
        AcceptLabel.Text = accept;

        if (cancel is null)
        {
            CancelTapArea.IsVisible = false;
            ActionDivider.IsVisible = false;
            Grid.SetColumn(AcceptTapArea, 0);
            Grid.SetColumnSpan(AcceptTapArea, 3);
        }
        else
        {
            CancelLabel.Text = cancel;
        }

        Loaded += OnLoaded;
    }

    public bool? DialogResult { get; private set; }

    /// <summary>What was typed in the field; empty when the dialog has none.</summary>
    public string InputText => InputEntry.Text ?? string.Empty;

    public void MarkDismissedOutside() => DialogResult = false;

    private void ConfigureBottomSheet(string accept, string? cancel, bool isDestructive)
    {
        _useBottomSheet = true;
        Microsoft.Maui.Devices.DisplayInfo display = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo;
        double width = display.Width / Math.Max(1d, display.Density);
        double height = display.Height / Math.Max(1d, display.Density);

        DialogCardHost.Margin = new Thickness(16, 0, 16, 48);
        DialogCardHost.VerticalOptions = LayoutOptions.End;
        DialogCardHost.HorizontalOptions = LayoutOptions.Fill;
        DialogCardHost.MaximumHeightRequest = Math.Max(280, height - 112);
        DialogCard.Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppOptionsSheetPopupCardStyle"];
        DialogCard.WidthRequest = Math.Min(560, Math.Max(280, width - 32));
        DialogCard.MaximumWidthRequest = 560;
        DialogCard.HorizontalOptions = LayoutOptions.Fill;
        TitleLabel.HorizontalTextAlignment = TextAlignment.Center;
        TitleLabel.Margin = new Thickness(8, 0);
        TitleLabel.VerticalTextAlignment = TextAlignment.Center;
        ButtonRow.IsVisible = false;
        SheetActions.IsVisible = true;
        SheetGrabber.IsVisible = true;
        SheetAcceptButton.BodyText = accept;
        SheetAcceptButton.Variant = isDestructive ? "Danger" : "Primary";
        SheetAcceptButton.TapCommand = new Command(() => CloseWithResult(true).FireAndForget());
        SheetCancelButton.IsVisible = cancel is not null;
        if (cancel is not null)
        {
            SheetCancelButton.BodyText = cancel;
            SheetCancelButton.TapCommand = new Command(() => CloseWithResult(false).FireAndForget());
            SemanticProperties.SetDescription(SheetCancelButton, cancel);
        }

        SemanticProperties.SetDescription(SheetAcceptButton, accept);
    }

    private void OnLoaded(object? sender, EventArgs e)
    {
        if (_useBottomSheet)
        {
            UiAnimations.AnimateToastPopInAsync(DialogCardHost, slideOffset: 12).FireAndForget();
        }
        else
        {
            UiAnimations.AnimateAlertPopInAsync(DialogCardHost).FireAndForget();
        }
        // A text to edit gets the keyboard at once, the cursor after the current text; a secret waits for a tap, as before.
        if (_input is { IsPassword: false })
        {
            InputEntry.Focus();
            InputEntry.CursorPosition = InputEntry.Text?.Length ?? 0;
        }
    }

    private void OnEntryCompleted(object? sender, EventArgs e) =>
        CloseWithResult(true).FireAndForget();

    private void OnAcceptTapped(object? sender, TappedEventArgs e) =>
        CloseWithResult(true).FireAndForget();

    private void OnCancelTapped(object? sender, TappedEventArgs e) =>
        CloseWithResult(false).FireAndForget();

    private async Task CloseWithResult(bool accepted)
    {
        if (_isClosing)
        {
            return;
        }

        _isClosing = true;
        DialogResult = accepted;
        if (_useBottomSheet)
        {
            await UiAnimations.AnimateToastPopOutAsync(DialogCardHost, slideOffset: 12);
        }
        else
        {
            await UiAnimations.AnimateAlertPopOutAsync(DialogCardHost);
        }
        await CloseAsync();
    }
}
