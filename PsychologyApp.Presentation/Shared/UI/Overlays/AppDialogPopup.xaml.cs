using CommunityToolkit.Maui.Views;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class AppDialogPopup : Popup
{
    private readonly AppDialogInput? _input;
    private bool _isClosing;

    public AppDialogPopup(
        string? title,
        string message,
        string accept,
        string? cancel,
        AppDialogInput? input = null)
    {
        InitializeComponent();

        _input = input;
        if (input is not null)
        {
            DialogCardHost.HorizontalOptions = LayoutOptions.Fill;
            DialogCard.HorizontalOptions = LayoutOptions.Fill;

            InputBorder.IsVisible = true;
            InputEntry.IsPassword = input.IsPassword;
            InputEntry.Placeholder = input.Placeholder;
            InputEntry.Text = input.InitialText;
            InputEntry.MaxLength = input.MaxLength;
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
        if (Microsoft.Maui.Controls.Application.Current?.Windows.FirstOrDefault() is { Height: > 0, Width: > 0 } window)
        {
            // Cap the scroll area independently so short dialogs shrink to their content.
            MessageScroll.MaximumHeightRequest = Math.Max(1, Math.Min(420, window.Height * 0.55));
            if (_input is not null)
            {
                DialogCard.WidthRequest = Math.Min(320, Math.Max(1, window.Width - DialogCardHost.Margin.HorizontalThickness));
            }
        }

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
        try
        {
            await UiAnimations.AnimateAlertPopOutAsync(DialogCardHost);
        }
        finally
        {
            await CloseAsync();
        }
    }
}
