using PsychologyApp.Application.Models.Tests;
using System.Text.Json;
using PsychologyApp.Application.Serialization;

namespace PsychologyApp.Application.Tests;

public sealed class LuscherDetailReader
{
    public LuscherStandardResultDetail? TryParseStandard(string? detailJson)
    {
        if (string.IsNullOrWhiteSpace(detailJson))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize(detailJson, TestJsonSerializerContext.Default.LuscherStandardResultDetail);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public LuscherBriefResultDetail? TryParseBrief(string? detailJson)
    {
        if (string.IsNullOrWhiteSpace(detailJson))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize(detailJson, TestJsonSerializerContext.Default.LuscherBriefResultDetail);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
