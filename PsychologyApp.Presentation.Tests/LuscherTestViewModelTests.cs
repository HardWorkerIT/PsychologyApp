using Moq;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Domain.Colour.ValueObjects;
using PsychologyApp.Presentation.Entities.Test;
using PsychologyApp.Presentation.Features.RunTests;
using PsychologyApp.Presentation.Pages.RunTests.LuscherTest;
using PsychologyApp.Presentation.Pages.RunTests.TestsList;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

[Collection("Localization")]
public sealed class LuscherTestViewModelTests
{
    public LuscherTestViewModelTests()
    {
        AppStrings.LanguageOverride = UserPreferences.DefaultLanguage;
    }

    // A missing name translation must not fall back to an untranslated code in the self-reflection result.
    [Theory]
    [InlineData("ru")]
    [InlineData("en")]
    [InlineData("fr")]
    [InlineData("de")]
    [InlineData("es")]
    [InlineData("pt")]
    [InlineData("zh")]
    public void Every_colour_has_a_localized_name(string language)
    {
        ColourValue[] colours = [ColourValue.Black, ColourValue.Red, ColourValue.Blue, ColourValue.Purple, ColourValue.Yellow, ColourValue.Brown, ColourValue.Green, ColourValue.Gray];
        AppStrings.LanguageOverride = language;
        List<string?> names = [.. colours.Select(colour => ColourStrings.NameOfCode(colour.Code))];
        AppStrings.LanguageOverride = UserPreferences.DefaultLanguage;

        Assert.All(names, name => Assert.False(string.IsNullOrWhiteSpace(name)));
        Assert.Equal(colours.Length, names.Distinct().Count());
    }

    [Theory]
    [InlineData("ru")]
    [InlineData("en")]
    public void Brief_summary_reports_selected_colours_without_interpreting_them(string language)
    {
        AppStrings.LanguageOverride = language;
        string expected = $"{ColourStrings.GetColorName(ColourValue.Blue)} / {ColourStrings.GetColorName(ColourValue.Red)}";
        string? summary = ColourStrings.BriefSummary(ColourValue.Blue.Code, ColourValue.Red.Code);
        AppStrings.LanguageOverride = UserPreferences.DefaultLanguage;

        Assert.Equal(expected, summary);
    }

    [Fact]
    public void BriefFinish_ExposesRoleLabels()
    {
        var navigation = new Mock<INavigation>();
        LuscherTestViewModel viewModel = new(
            LuscherMode.Brief,
            new TestNavigationService(navigation.Object),
            null,
            new LuscherResultService());

        InvokeColorHandler(viewModel, ColourValue.Red);
        InvokeColorHandler(viewModel, ColourValue.Blue);

        Assert.True(viewModel.IsFinish);
        Assert.Equal(AppStrings.TestsLuscherWantedRole, viewModel.FirstColorRoleLabel);
        Assert.Equal(AppStrings.TestsLuscherUnwantedRole, viewModel.SecondColorRoleLabel);
        Assert.False(string.IsNullOrWhiteSpace(viewModel.ResultsTitle));
    }

    [Fact]
    public void The_step_header_is_hidden_once_the_result_shows()
    {
        // The page reads the flag only when it is announced: without the event, "Pick the colour you like least" stayed above the result.
        LuscherTestViewModel viewModel = new(LuscherMode.Brief, new TestNavigationService(new Mock<INavigation>().Object), null, new LuscherResultService());
        List<string?> changed = [];
        InvokeColorHandler(viewModel, ColourValue.Red);
        viewModel.PropertyChanged += (_, e) => changed.Add(e.PropertyName);

        InvokeColorHandler(viewModel, ColourValue.Blue);

        Assert.False(viewModel.ShowBriefProgress);
        Assert.Contains(nameof(LuscherTestViewModel.ShowBriefProgress), changed);
    }

    [Fact]
    public void StandardFinish_ExposesEightColorPassRows()
    {
        var navigation = new Mock<INavigation>();
        LuscherTestViewModel viewModel = new(
            LuscherMode.Standard,
            new TestNavigationService(navigation.Object),
            null,
            new LuscherResultService());

        ColourValue[] colors =
        [
            ColourValue.Red,
            ColourValue.Blue,
            ColourValue.Green,
            ColourValue.Yellow,
            ColourValue.Purple,
            ColourValue.Brown,
            ColourValue.Gray,
            ColourValue.Black
        ];

        foreach (ColourValue color in colors)
        {
            InvokeColorHandler(viewModel, color);
        }

        foreach (ColourValue color in colors.Reverse())
        {
            InvokeColorHandler(viewModel, color);
        }

        Assert.True(viewModel.IsFinish);
        Assert.Equal(8, viewModel.StandardFirstPassDisplay.Count);
        Assert.Equal(8, viewModel.StandardSecondPassDisplay.Count);
    }

    [Fact]
    public async Task StandardMode_AfterTwoPasses_PersistsWithStandardTestId()
    {
        var navigation = new Mock<INavigation>();
        var progress = new Mock<IUserProgressService>();
        progress
            .Setup(p => p.SaveTestResultAsync(TestIds.LuscherStandard, It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string?>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        LuscherTestViewModel viewModel = new(
            LuscherMode.Standard,
            new TestNavigationService(navigation.Object),
            progress.Object,
            new LuscherResultService());

        ColourValue[] colors =
        [
            ColourValue.Red,
            ColourValue.Blue,
            ColourValue.Green,
            ColourValue.Yellow,
            ColourValue.Purple,
            ColourValue.Brown,
            ColourValue.Gray,
            ColourValue.Black
        ];

        foreach (ColourValue color in colors)
        {
            InvokeColorHandler(viewModel, color);
        }

        Assert.False(viewModel.IsFinish);
        Assert.Equal(2, viewModel.StandardPassNumber);

        foreach (ColourValue color in colors.Reverse())
        {
            InvokeColorHandler(viewModel, color);
        }

        Assert.True(viewModel.IsFinish);
        Assert.Equal(2, viewModel.ResultItems.Count);
        await Task.Delay(50);

        progress.Verify(
            p => p.SaveTestResultAsync(
                TestIds.LuscherStandard,
                It.IsAny<int?>(),
                It.Is<string>(summary => summary.Contains(':') || summary.Length > 0),
                It.IsAny<string?>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public void BriefStepLabel_ReflectsCurrentStep()
    {
        var navigation = new Mock<INavigation>();
        LuscherTestViewModel viewModel = new(
            LuscherMode.Brief,
            new TestNavigationService(navigation.Object),
            null,
            new LuscherResultService());

        Assert.Equal(AppStrings.TestsStepOf(1, 2), viewModel.BriefStepLabel);

        InvokeColorHandler(viewModel, ColourValue.Red);

        Assert.Equal(AppStrings.TestsStepOf(2, 2), viewModel.BriefStepLabel);
    }

    [Fact]
    public async Task BriefMode_AfterTwoSelections_PersistsWithBriefTestId()
    {
        var navigation = new Mock<INavigation>();
        var progress = new Mock<IUserProgressService>();
        progress
            .Setup(p => p.SaveTestResultAsync(TestIds.LuscherBrief, null, It.IsAny<string>(), It.IsAny<string?>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        LuscherTestViewModel viewModel = new(
            LuscherMode.Brief,
            new TestNavigationService(navigation.Object),
            progress.Object,
            new LuscherResultService());

        InvokeColorHandler(viewModel, ColourValue.Red);
        InvokeColorHandler(viewModel, ColourValue.Blue);

        Assert.True(viewModel.IsFinish);
        await Task.Delay(50);

        progress.Verify(
            p => p.SaveTestResultAsync(
                TestIds.LuscherBrief,
                null,
                It.IsAny<string>(),
                It.IsAny<string?>(),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    private static void InvokeColorHandler(LuscherTestViewModel viewModel, ColourValue color)
    {
        switch (color.Code)
        {
            case "#FF0000":
                viewModel.RedHandler!.Execute(null);
                break;
            case "#0000FF":
                viewModel.BlueHandler!.Execute(null);
                break;
            case "#00FF00":
                viewModel.GreenHandler!.Execute(null);
                break;
            case "#FFFF00":
                viewModel.YellowHandler!.Execute(null);
                break;
            case "#964B00":
                viewModel.BrownHandler!.Execute(null);
                break;
            case "#888888":
                viewModel.GrayHandler!.Execute(null);
                break;
            case "#FF00FF":
                viewModel.PurpleHandler!.Execute(null);
                break;
            case "#000000":
                viewModel.BlackHandler!.Execute(null);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(color), color, "Unsupported test color.");
        }
    }
}
