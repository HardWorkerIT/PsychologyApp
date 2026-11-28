namespace PsychologyApp.Presentation.Shared.Services.Dialogs;

public readonly record struct DialogSelection<T>(T? Value, bool CancelledWithButton) where T : class;

public sealed record DialogOptionItem(
    string Value,
    string Title,
    string? Description = null,
    string? Detail = null,
    bool IsSectionHeader = false)
{
    public static DialogOptionItem SectionHeader(string title) => new(string.Empty, title, IsSectionHeader: true);
}
