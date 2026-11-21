using PsychologyApp.Domain.Tests;
using PsychologyApp.Presentation.Common;
using PsychologyApp.Presentation.Shared.Common;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

[Collection("Localization")]
public sealed class TestScoreLabelMapperTests
{
    public TestScoreLabelMapperTests()
    {
        AppStrings.LanguageOverride = AppStrings.DefaultLanguage;
    }

    [Fact]
    public void GetSummary_Beck_UsesDomainBands()
    {
        string? low = TestScoreLabelMapper.GetSummary("beck", 9);
        string? mild = TestScoreLabelMapper.GetSummary("beck", 10);

        Assert.Equal(AppStrings.BeckScore(TestScoreBandClassifier.ClassifyBeck(9)), low);
        Assert.Equal(AppStrings.BeckScore(TestScoreBandClassifier.ClassifyBeck(10)), mild);
        Assert.NotEqual(low, mild);
    }

    [Fact]
    public void GetSummary_UnknownAnalyzer_ReturnsNull()
    {
        Assert.Null(TestScoreLabelMapper.GetSummary("unknown", 5));
    }

    [Fact]
    public void TestLastResultDated_IncludesDateAndSummary()
    {
        string text = AppStrings.TestLastResultDated("mild", "26.07.2026");
        Assert.Contains("mild", text, StringComparison.Ordinal);
        Assert.Contains("26.07.2026", text, StringComparison.Ordinal);
    }

    [Fact]
    public void PreferenceProfileResult_UsesLocalizedInspectorNameAndReflectionDetail()
    {
        string? previous = AppStrings.LanguageOverride;
        try
        {
            AppStrings.LanguageOverride = "en";
            Assert.Equal("ISTJ", TestScoreLabelMapper.GetProfileCode("preferences16", 3));
            Assert.Equal(AppStrings.Personality16TypeName("ISTJ"), TestScoreLabelMapper.GetProfileName("preferences16", 3));
            Assert.Equal(
                AppStrings.Personality16TypeResult(AppStrings.Personality16TypeName("ISTJ"), "ISTJ"),
                TestScoreLabelMapper.GetSummary("preferences16", 3));
            Assert.Contains("reflection", TestScoreLabelMapper.GetDetail("preferences16", 3)!, StringComparison.OrdinalIgnoreCase);
        }
        finally
        {
            AppStrings.LanguageOverride = previous;
        }
    }

    [Fact]
    public void AllProfilesAndPreferenceLabels_ResolveInEverySupportedLanguage()
    {
        string? previous = AppStrings.LanguageOverride;
        string[] codes = ["ISTJ", "ISFJ", "INFJ", "INTJ", "ISTP", "ISFP", "INFP", "INTP", "ESTP", "ESFP", "ENFP", "ENTP", "ESTJ", "ESFJ", "ENFJ", "ENTJ"];
        try
        {
            foreach (string language in AppLanguages.All)
            {
                AppStrings.LanguageOverride = language;
                foreach (string code in codes)
                {
                    Assert.NotEqual("Personality16Unknown", AppStrings.Personality16TypeName(code));
                }

                foreach (char preference in "IESNFTPJ")
                {
                    Assert.False(string.IsNullOrWhiteSpace(AppStrings.Personality16PreferenceLabel(preference)));
                }

                Assert.False(string.IsNullOrWhiteSpace(AppStrings.Personality16TypeResult("Inspector", "ISTJ")));
                Assert.False(string.IsNullOrWhiteSpace(AppStrings.Personality16ResultDetail("a preference")));
            }
        }
        finally
        {
            AppStrings.LanguageOverride = previous;
        }
    }
}
