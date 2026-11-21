using CommunityToolkit.Maui.Views;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class AppDialogPopup : Popup
{
    private readonly AppDialogInput? _input;
    private bool _isClosing;

    public AppDialogPopup(string? title, string message, string accept, string? cancel, AppDialogInput? input = null)
    {
        InitializeComponent();

        _input = input;
        if (input is not null)
        {
            Microsoft.Maui.Devices.DisplayInfo display = Microsoft.Maui.Devices.DeviceDisplay.MainDisplayInfo;
            double screenWidthDp = display.Width / Math.Max(1d, display.Density);
            DialogCardHost.Margin = new Thickness(16, 24);
            DialogCardHost.HorizontalOptions = LayoutOptions.Fill;
            DialogCard.MaximumWidthRequest = 320;
            DialogCard.WidthRequest = Math.Min(320d, Math.Max(280d, screenWidthDp - 32d));
            DialogCard.HorizontalOptions = LayoutOptions.Fill;
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

    private void OnLoaded(object? sender, EventArgs e)
    {
        UiAnimations.AnimateAlertPopInAsync(DialogCardHost).FireAndForget();
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
        await UiAnimations.AnimateAlertPopOutAsync(DialogCardHost);
        await CloseAsync();
    }
}
