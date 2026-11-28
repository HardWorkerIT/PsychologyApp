namespace PsychologyApp.Presentation.Shared.Services.Dialogs;

public interface IDialogService
{
    Task ShowAsync(string? title, string message);
    Task<bool> AskAsync(string? title, string message, string accept, string cancel);
    Task<bool> AskSheetAsync(string? title, string message, string accept, string cancel, bool isDestructive = false);
    Task<string?> PickOptionAsync(string title, IReadOnlyList<string> options, string cancel);
    Task<string?> PickOptionAsync(string title, IReadOnlyList<DialogOptionItem> options, string cancel);
    Task<DialogSelection<string>> PickOptionStepAsync(string title, IReadOnlyList<DialogOptionItem> options, string back);
    Task<string?> PickOptionWithConfirmationAsync(string title, IReadOnlyList<string> options, string accept, string? cancel = null);
    /// <summary>Returns accepted values in their retained order and distinguishes the cancel button from dismissing the sheet.</summary>
    Task<DialogSelection<IReadOnlyList<string>>> PickMultipleOptionsAsync(
        string title,
        IReadOnlyList<DialogOptionItem> options,
        IReadOnlyCollection<string> selectedValues,
        int maximumSelectionCount,
        Func<int, string> selectionSummaryFactory,
        string selectionHint,
        string selectedItemHint,
        string selectionLimitMessage,
        string accept,
        string cancel);

    /// <summary>Asks for a line of text in the app's own dialog, filled with <paramref name="initialText"/>; null when cancelled or when
    /// another dialog is on screen. An accepted empty field is an empty string.</summary>
    Task<string?> PromptTextAsync(string? title, string message, string accept, string cancel, string initialText, int maxLength);

    /// <summary>Asks for a secret (masked) in the app's existing options sheet; null when cancelled or when another dialog is on screen.</summary>
    Task<string?> PromptPasswordAsync(string? title, string message, string placeholder, string accept, string cancel);
    Task<string?> PromptPasswordSheetAsync(string? title, string message, string placeholder, string accept, string cancel);
}
