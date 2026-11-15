namespace PsychologyApp.Presentation.Shared.Services.Dialogs;

public sealed record DialogOptionItem(
    string Value,
    string Title,
    string? Description = null,
    string? Detail = null);
