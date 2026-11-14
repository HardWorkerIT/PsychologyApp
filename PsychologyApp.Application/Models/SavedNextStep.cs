namespace PsychologyApp.Application.Models;

public enum SavedNextStep
{
    Grounding,
    ThoughtRecord,
    SmallStep,
    MoodCheckIn
}

public static class SavedNextStepCollection
{
    public const int MaximumCount = 3;

    public static IReadOnlyList<SavedNextStep> Parse(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return [];
        }

        List<SavedNextStep> result = [];
        foreach (string name in value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (result.Count == MaximumCount)
            {
                break;
            }

            if (Enum.TryParse(name, out SavedNextStep nextStep)
                && Enum.IsDefined(nextStep)
                && string.Equals(nextStep.ToString(), name, StringComparison.Ordinal)
                && !result.Contains(nextStep))
            {
                result.Add(nextStep);
            }
        }

        return result.ToArray();
    }

    public static IReadOnlyList<SavedNextStep> Validate(IReadOnlyList<SavedNextStep> nextSteps)
    {
        ArgumentNullException.ThrowIfNull(nextSteps);

        if (nextSteps.Count > MaximumCount)
        {
            throw new ArgumentOutOfRangeException(nameof(nextSteps), nextSteps.Count, $"At most {MaximumCount} actions can be saved.");
        }

        HashSet<SavedNextStep> unique = [];
        foreach (SavedNextStep nextStep in nextSteps)
        {
            if (!Enum.IsDefined(nextStep))
            {
                throw new ArgumentOutOfRangeException(nameof(nextSteps), nextStep, "The saved action is not supported.");
            }

            if (!unique.Add(nextStep))
            {
                throw new ArgumentException("Saved actions must be unique.", nameof(nextSteps));
            }
        }

        return nextSteps.ToArray();
    }

    public static string? Serialize(IReadOnlyList<SavedNextStep> nextSteps)
    {
        IReadOnlyList<SavedNextStep> validated = Validate(nextSteps);
        return validated.Count == 0
            ? null
            : string.Join(",", validated.Select(nextStep => nextStep.ToString()));
    }
}
