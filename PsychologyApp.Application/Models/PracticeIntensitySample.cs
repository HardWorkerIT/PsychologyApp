namespace PsychologyApp.Application.Models;

public sealed class PracticeIntensitySample
{
    public string ItemKey { get; init; } = string.Empty;
    public int? PreIntensity { get; init; }
    public int? PostIntensity { get; init; }
}
