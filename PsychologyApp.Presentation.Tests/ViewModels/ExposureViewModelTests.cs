using Moq;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Exposure;
using PsychologyApp.Domain.Exposure;
using PsychologyApp.Presentation.Pages.ClinicalCare.Exposure;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

public sealed class ExposureViewModelTests
{
    private readonly Mock<INavigationService> _navigation = new();

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task CrisisScreeningOpensHelpWhenPlanStorageIsUnavailable(bool screeningWriteFails)
    {
        Mock<IExposureService> service = new();
        service.SetupSequence(s => s.GetPlanAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((ExposurePlan?)null)
            .ThrowsAsync(new IOException("Could not read the saved plan."));
        var screen = service.Setup(s => s.ScreenAsync(It.IsAny<ExposureScreeningAnswers>(), It.IsAny<CancellationToken>()));
        if (screeningWriteFails)
        {
            screen.ThrowsAsync(new IOException("Could not save the screening."));
        }
        else
        {
            screen.ReturnsAsync(ExposureScreeningResult.Crisis);
        }

        ExposureViewModel viewModel = new(_navigation.Object, service.Object);
        await VmTestHelpers.WaitUntilAsync(() => viewModel.IsScreening);
        foreach (ExposureQuestionItem question in viewModel.Questions)
        {
            question.Answer = false;
        }
        viewModel.Questions[0].Answer = true;

        await VmTestHelpers.RunAsync(viewModel.ScreenCommand);

        _navigation.Verify(n => n.GoToCrisisHubAsync(), Times.Once);
        Assert.False(viewModel.IsHome);
    }

    [Fact]
    public async Task ACrisisReportStillOpensHelpWhenItsWriteFails()
    {
        DateTime now = DateTime.UtcNow;
        ExposurePlan savedPlan = new()
        {
            Screening = ExposureScreeningResult.Allowed,
            ScreenedAt = now,
            Steps = [new ExposureStep("step", "Practice step", 30)],
            Sessions = [new ExposureSession { Id = "session", StepId = "step", CreatedAt = now }]
        };
        Mock<IExposureRepository> repository = new();
        repository.Setup(r => r.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync(savedPlan);
        repository.Setup(r => r.SaveAsync(It.IsAny<ExposurePlan>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Could not save the report."));
        ICrisisDetector detector = Mock.Of<ICrisisDetector>(d => d.IsCrisis("crisis signal"));
        ExposureService service = new(repository.Object, detector);
        ExposureViewModel viewModel = new(_navigation.Object, service);
        await VmTestHelpers.WaitUntilAsync(() => viewModel.IsHome);

        viewModel.ReportCommand.Execute(null);
        viewModel.WhatHappened = "crisis signal";
        viewModel.Outcomes[0].SelectCommand.Execute(null);
        viewModel.SafetyAnswerCommand.Execute("no");
        await VmTestHelpers.RunAsync(viewModel.SaveReportCommand);

        _navigation.Verify(n => n.GoToCrisisHubAsync(), Times.Once);
        Assert.True(viewModel.IsAfter);
        Assert.Equal("crisis signal", viewModel.WhatHappened);
    }
}
