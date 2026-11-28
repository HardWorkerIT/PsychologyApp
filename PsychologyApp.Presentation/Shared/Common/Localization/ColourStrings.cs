using PsychologyApp.Domain.Colour.ValueObjects;
using PsychologyApp.Presentation.Common;

namespace PsychologyApp.Presentation.Shared.Common;

public static class ColourStrings
{
    /// <summary>The order of the localized name keys matches the stored colour codes.</summary>
    private static readonly ColourValue[] Order =
    [
        ColourValue.Black, ColourValue.Red, ColourValue.Blue, ColourValue.Purple,
        ColourValue.Yellow, ColourValue.Brown, ColourValue.Green, ColourValue.Gray
    ];

    private static readonly string[] NameKeys = ["Black", "Red", "Blue", "Purple", "Yellow", "Brown", "Green", "Gray"];

    private static int IndexOf(ColourValue colour) => Array.FindIndex(Order, value => value.Equals(colour));

    /// <summary>The localized name of a stored colour code (for example, "#0000FF").</summary>
    public static string? NameOfCode(string? code)
    {
        int index = IndexOfCode(code);
        return index < 0 ? null : AppStrings.In(AppStrings.Language, $"LuscherColour{NameKeys[index]}");
    }

    public static string GetColorName(ColourValue colour)
    {
        int index = IndexOf(colour);
        return index < 0 ? colour.ToString() : AppStrings.In(AppStrings.Language, $"LuscherColour{NameKeys[index]}");
    }

    /// <summary>Shows the selected colours without assigning psychological meaning to them.</summary>
    public static string? BriefSummary(string? firstCode, string? secondCode) =>
        NameOfCode(firstCode) is { } first && NameOfCode(secondCode) is { } second ? $"{first} / {second}" : null;

    private static int IndexOfCode(string? code) =>
        Array.FindIndex(Order, value => string.Equals(value.Code, code, StringComparison.OrdinalIgnoreCase));
}
