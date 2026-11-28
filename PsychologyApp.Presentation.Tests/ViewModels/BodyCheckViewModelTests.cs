using Moq;
using PsychologyApp.Application.Body;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Presentation.Pages.ClinicalCare.BodyCheck;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

public sealed class BodyCheckViewModelTests
{
    [Fact]
    public async Task UrgentHelpIsAvailableDuringAndAfterAFailedCheckInSave()
    {
        const string note = "A note requiring urgent help";
        var pending = new TaskCompletionSource<BodyCheckResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        var body = new Mock<IBodyService>();
        body.Setup(service => service.SaveAsync(It.IsAny<BodyArea>(), It.IsAny<BodySensation>(), null,
                It.IsAny<IReadOnlyList<BodyFeeling>>(), note, It.IsAny<CancellationToken>()))
            .Returns(pending.Task);
        var detector = new Mock<ICrisisDetector>();
        detector.Setup(service => service.IsCrisis(note)).Returns(true);
        var navigation = new Mock<INavigationService>();
        var viewModel = new BodyCheckViewModel(navigation.Object, body.Object, detector.Object,
            Mock.Of<IDialogService>(), Mock.Of<IDatabaseReadySignal>());
        viewModel.AreaChips[0].TapCommand.Execute(null);
        viewModel.SensationChips[0].TapCommand.Execute(null);
        viewModel.Note = note;

        viewModel.SaveCommand.Execute(null);

        Assert.True(viewModel.IsCrisis);
        Assert.False(viewModel.ShowPractices);
        await VmTestHelpers.RunAsync(viewModel.CrisisCommand);
        navigation.Verify(service => service.GoToCrisisHubAsync(), Times.Once);
        pending.SetException(new IOException("Check-in storage unavailable"));
        await VmTestHelpers.WaitUntilAsync(() => viewModel.SaveCommand.CanExecute(null));

        Assert.True(viewModel.IsCrisis);
        Assert.False(viewModel.IsSaved);
        Assert.Equal(note, viewModel.Note);
        body.Verify(service => service.GetLogAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}
