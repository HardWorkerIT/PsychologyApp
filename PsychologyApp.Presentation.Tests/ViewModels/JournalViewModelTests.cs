using Moq;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Features.ManageJournal;
using PsychologyApp.Presentation.Pages.ManageJournal.Journal;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

public sealed class JournalViewModelTests
{
    [Fact]
    public async Task AJourneyToUrgentHelpDoesNotWaitForANoteWrite()
    {
        var (viewModel, progress, navigation) = await CreateWithSavedMoodAsync();
        TaskCompletionSource write = new(TaskCreationOptions.RunContinuationsAsynchronously);
        progress.Setup(p => p.UpdateMoodEntryAsync(1, 2, "My note", It.IsAny<CancellationToken>())).Returns(write.Task);
        navigation.Setup(n => n.GoToCrisisHubAsync()).Returns(Task.CompletedTask);
        viewModel.JournalNote = "My note";
        Task flushing = viewModel.FlushPendingNoteSaveAsync();

        try
        {
            await VmTestHelpers.RunAsync(viewModel.OpenLowMoodHelpCommand);

            navigation.Verify(n => n.GoToCrisisHubAsync(), Times.Once);
            Assert.False(flushing.IsCompleted);
        }
        finally
        {
            write.TrySetResult();
            await flushing;
        }
    }

    [Fact]
    public async Task AFailedNoteWriteDoesNotSaySavedAndCanBeRetriedWithTheSameText()
    {
        var (viewModel, progress, _) = await CreateWithSavedMoodAsync();
        progress.SetupSequence(p => p.UpdateMoodEntryAsync(1, 2, "My note", It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Journal storage unavailable"))
            .Returns(Task.CompletedTask);
        Assert.NotEmpty(viewModel.MoodSavedStatus);

        viewModel.JournalNote = "My note";
        await Assert.ThrowsAsync<IOException>(() => viewModel.FlushPendingNoteSaveAsync());

        Assert.Empty(viewModel.MoodSavedStatus);
        Assert.Equal("My note", viewModel.JournalNote);

        await viewModel.FlushPendingNoteSaveAsync();

        Assert.NotEmpty(viewModel.MoodSavedStatus);
        progress.Verify(p => p.UpdateMoodEntryAsync(1, 2, "My note", It.IsAny<CancellationToken>()), Times.Exactly(2));
    }

    private static async Task<(JournalViewModel ViewModel, Mock<IUserProgressService> Progress, Mock<INavigationService> Navigation)>
        CreateWithSavedMoodAsync()
    {
        var progress = new Mock<IUserProgressService>();
        progress.Setup(p => p.GetMoodsAsync(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<MoodEntryDTO> { new() { MoodEntryId = 1, MoodLevel = 2, RecordedAt = DateTime.UtcNow } });
        progress.Setup(p => p.GetRecentTechniqueCompletionsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync([]);
        var navigation = new Mock<INavigationService>();
        JournalViewModel viewModel = new(new JournalMoodLoader(progress.Object, new KeywordCrisisDetector()),
            new JournalEditorContext(), Mock.Of<IDialogService>(), navigation.Object);
        await viewModel.ReloadAsync();
        return (viewModel, progress, navigation);
    }
}
