using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.UI.Overlays;

namespace PsychologyApp.Presentation.Shared.Services.Dialogs;

public class DialogService(IPageHost pageHost) : IDialogService
{
    // One dialog or sheet at a time: a double tap on the button that opens one would otherwise stack two identical popups.
    private int _isShowing;

    public async Task ShowAsync(string? title, string message)
    {
        if (!TryEnter())
        {
            return;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppDialogPopup(title, message, AppStrings.Ok, cancel: null);
            await page.ShowPopupAsync(popup, CreateDialogOptions(popup));
        }
        finally
        {
            Leave();
        }
    }

    public async Task<bool> AskAsync(string? title, string message, string accept, string cancel)
    {
        // A question that is already on screen: this duplicate answers "no", the safe default for a confirmation.
        if (!TryEnter())
        {
            return false;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppDialogPopup(title, message, accept, cancel);
            IPopupResult popupResult = await page.ShowPopupAsync(popup, CreateDialogOptions(popup));
            if (popupResult.WasDismissedByTappingOutsideOfPopup)
            {
                return false;
            }

            return popup.DialogResult == true;
        }
        finally
        {
            Leave();
        }
    }

    public async Task<bool> AskSheetAsync(string? title, string message, string accept, string cancel, bool isDestructive = false)
    {
        if (!TryEnter())
        {
            return false;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppOptionsSheetPopup(title, message, accept, cancel, isDestructive: isDestructive);
            IPopupResult popupResult = await page.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
            return !popupResult.WasDismissedByTappingOutsideOfPopup && popup.DialogResult == true;
        }
        finally
        {
            Leave();
        }
    }

    public async Task<string?> PromptTextAsync(string? title, string message, string accept, string cancel, string initialText, int maxLength)
    {
        if (!TryEnter())
        {
            return null;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppDialogPopup(title, message, accept, cancel, new AppDialogInput(string.Empty, IsPassword: false, initialText, maxLength));
            IPopupResult popupResult = await page.ShowPopupAsync(popup, CreateDialogOptions(popup));
            if (popupResult.WasDismissedByTappingOutsideOfPopup || popup.DialogResult != true)
            {
                return null;
            }

            return popup.InputText;
        }
        finally
        {
            Leave();
        }
    }

    public async Task<string?> PromptPasswordAsync(string? title, string message, string placeholder, string accept, string cancel)
    {
        if (!TryEnter())
        {
            return null;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppDialogPopup(title, message, accept, cancel, new AppDialogInput(placeholder, IsPassword: true));
            IPopupResult popupResult = await page.ShowPopupAsync(popup, CreateDialogOptions(popup));
            if (popupResult.WasDismissedByTappingOutsideOfPopup || popup.DialogResult != true)
            {
                return null;
            }

            return popup.InputText;
        }
        finally
        {
            Leave();
        }
    }

    public Task<string?> PromptPasswordSheetAsync(string? title, string message, string placeholder, string accept, string cancel) =>
        PromptInputSheetAsync(title, message, accept, cancel, new AppDialogInput(placeholder, IsPassword: true));

    public Task<string?> PromptPinSheetAsync(string? title, string message, string placeholder, string accept, string cancel) =>
        PromptInputSheetAsync(title, message, accept, cancel, new AppDialogInput(placeholder, IsPassword: true, IsPin: true));

    private async Task<string?> PromptInputSheetAsync(string? title, string message, string accept, string cancel, AppDialogInput input)
    {
        if (!TryEnter())
        {
            return null;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppOptionsSheetPopup(
                title,
                message,
                accept,
                cancel,
                input);
            IPopupResult popupResult = await page.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
            if (popupResult.WasDismissedByTappingOutsideOfPopup || popup.DialogResult != true)
            {
                return null;
            }

            return popup.InputText;
        }
        finally
        {
            Leave();
        }
    }

    public async Task<string?> PickOptionAsync(string title, IReadOnlyList<string> options, string cancel)
    {
        DialogOptionItem[] items = options.Select(option => new DialogOptionItem(option, option)).ToArray();
        return await PickOptionAsync(title, items, cancel);
    }

    public async Task<string?> PickOptionAsync(string title, IReadOnlyList<DialogOptionItem> options, string cancel) =>
        (await PickOptionStepAsync(title, options, cancel)).Value;

    public async Task<DialogSelection<string>> PickOptionStepAsync(
        string title, IReadOnlyList<DialogOptionItem> options, string back)
    {
        if (!TryEnter())
        {
            return default;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppOptionsSheetPopup(title, options, back);
            await page.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
            return new(popup.SelectedValue, popup.CancelledWithButton);
        }
        finally
        {
            Leave();
        }
    }

    public async Task<string?> PickOptionWithConfirmationAsync(string title, IReadOnlyList<string> options, string accept, string? cancel = null)
    {
        if (options.Count == 0 || !TryEnter())
        {
            return null;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppOptionsSheetPopup(title, options, null, accept, cancel);
            await page.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
            return popup.SelectedValue;
        }
        finally
        {
            Leave();
        }
    }

    public async Task<DialogSelection<IReadOnlyList<string>>> PickMultipleOptionsAsync(
        string title,
        IReadOnlyList<DialogOptionItem> options,
        IReadOnlyCollection<string> selectedValues,
        int maximumSelectionCount,
        Func<int, string> selectionSummaryFactory,
        string selectionHint,
        string selectedItemHint,
        string selectionLimitMessage,
        string accept,
        string cancel)
    {
        if (!TryEnter())
        {
            return default;
        }

        try
        {
            Page page = RequireActivePage();
            var popup = new AppOptionsSheetPopup(
                title,
                options,
                selectedValues,
                maximumSelectionCount,
                selectionSummaryFactory,
                selectionHint,
                selectedItemHint,
                selectionLimitMessage,
                accept,
                cancel);
            await page.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
            return new(popup.SelectedValues, popup.CancelledWithButton);
        }
        finally
        {
            Leave();
        }
    }

    private bool TryEnter() => Interlocked.CompareExchange(ref _isShowing, 1, 0) == 0;

    private void Leave() => Volatile.Write(ref _isShowing, 0);

    private static PopupOptions CreateDialogOptions(AppDialogPopup popup) =>
        new()
        {
            PageOverlayColor = AppPopupOptions.Dialog.PageOverlayColor,
            CanBeDismissedByTappingOutsideOfPopup = true,
            Shape = null,
            Shadow = null,
            OnTappingOutsideOfPopup = popup.MarkDismissedOutside,
        };

    private Page RequireActivePage() =>
        pageHost.GetActivePage()
        ?? throw new InvalidOperationException("No active page available for dialog.");
}
