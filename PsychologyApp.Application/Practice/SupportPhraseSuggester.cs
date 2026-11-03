using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice;

public interface ISupportPhraseSuggester
{
    /// <summary>
    /// A few ready phrases for a "balanced thought" or "kind words" field, picked to fit what the person wrote before it.
    /// Empty for other fields, and empty when the context reads as a crisis: then a ready phrase would only sound dismissive.
    /// </summary>
    /// <param name="context">What the person wrote in the earlier fields of the same practice (the automatic thought, the self-criticism).</param>
    Task<IReadOnlyList<string>> SuggestAsync(EntryFieldRole role, string? context, string? language, CancellationToken cancellationToken = default);
}

/// <summary>
/// Returns reviewed, deterministic phrases selected to match the thought and app language.
/// </summary>
public sealed class SupportPhraseSuggester(ICrisisDetector crisisDetector) : ISupportPhraseSuggester
{
    public const int MaxSuggestions = 6;

    public Task<IReadOnlyList<string>> SuggestAsync(EntryFieldRole role, string? context, string? language, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (role is not (EntryFieldRole.Reframe or EntryFieldRole.Kindness or EntryFieldRole.SelfKindness)
            || crisisDetector.IsCrisis(context))
        {
            return Task.FromResult<IReadOnlyList<string>>([]);
        }

        IReadOnlyList<string> suggestions = SupportPhraseContent.Pick(role, context, language)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Take(MaxSuggestions)
            .ToList();

        return Task.FromResult(suggestions);
    }
}
