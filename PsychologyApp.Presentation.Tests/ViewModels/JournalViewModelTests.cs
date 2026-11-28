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
    public async Task OpeningATimelineEntryEditsThatEntryEvenWhenTheDayHasOtherCheckIns()
    {
        var context = new JournalEditorContext();
        var (viewModel, progress, _) = await CreateWithSavedMoodAsync(editorContext: context);
        var day = DateOnly.FromDateTime(DateTime.Today).AddDays(-1);
        progress.Setup(p => p.GetMoodsAsync(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([
                new() { MoodEntryId = 11, MoodLevel = 2, RecordedAt = day.ToDateTime(new TimeOnly(9, 0)).ToUniversalTime(), Note = "Morning" },
                new() { MoodEntryId = 12, MoodLevel = 4, RecordedAt = day.ToDateTime(new TimeOnly(19, 0)).ToUniversalTime(), Note = "Selected entry" },
                new() { MoodEntryId = 13, MoodLevel = 3, RecordedAt = day.ToDateTime(new TimeOnly(21, 0)).ToUniversalTime(), Note = "Later entry" }
            ]);
        context.PendingTarget = (day, 12);

        await viewModel.ReloadAsync();

        Assert.True(viewModel.IsEveningSelected);
        Assert.Equal("Selected entry", viewModel.JournalNote);
        viewModel.JournalNote = "Edit the selected entry";
        await viewModel.FlushPendingNoteSaveAsync();
        progress.Verify(p => p.UpdateMoodNoteAsync(12, "Edit the selected entry", It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task AJourneyToUrgentHelpDoesNotWaitForANoteWrite()
    {
        var (viewModel, progress, navigation) = await CreateWithSavedMoodAsync();
        TaskCompletionSource write = new(TaskCreationOptions.RunContinuationsAsynchronously);
        progress.Setup(p => p.UpdateMoodNoteAsync(1, "My note", It.IsAny<CancellationToken>())).Returns(write.Task);
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
    public async Task AFailedCrisisNoteWriteStillOffersUrgentHelpAndKeepsTheDraft()
    {
        const string note = "Не хочу жить";
        Mock<IDialogService> dialogs = new();
        dialogs.Setup(d => d.AskAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(true);
        var (viewModel, progress, navigation) = await CreateWithSavedMoodAsync(dialogs.Object);
        progress.Setup(p => p.UpdateMoodNoteAsync(1, note, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Journal storage unavailable"));

        viewModel.JournalNote = note;
        await Assert.ThrowsAsync<IOException>(() => viewModel.FlushPendingNoteSaveAsync());

        navigation.Verify(n => n.GoToCrisisHubAsync(), Times.Once);
        Assert.False(viewModel.ShowLowMoodPractices);
        Assert.Empty(viewModel.MoodSavedStatus);
        Assert.Equal(note, viewModel.JournalNote);
    }

    [Fact]
    public async Task AFailedNoteWriteDoesNotSaySavedAndCanBeRetriedWithTheSameText()
    {
        var (viewModel, progress, _) = await CreateWithSavedMoodAsync();
        progress.SetupSequence(p => p.UpdateMoodNoteAsync(1, "My note", It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Journal storage unavailable"))
            .Returns(Task.CompletedTask);
        Assert.NotEmpty(viewModel.MoodSavedStatus);

        viewModel.JournalNote = "My note";
        await Assert.ThrowsAsync<IOException>(() => viewModel.FlushPendingNoteSaveAsync());

        Assert.Empty(viewModel.MoodSavedStatus);
        Assert.True(viewModel.MoodSaveFailed);
        Assert.Equal("My note", viewModel.JournalNote);

        await VmTestHelpers.RunAsync(viewModel.FlushNoteCommand);

        Assert.NotEmpty(viewModel.MoodSavedStatus);
        Assert.False(viewModel.MoodSaveFailed);
        progress.Verify(p => p.UpdateMoodNoteAsync(1, "My note", It.IsAny<CancellationToken>()), Times.Exactly(2));
        progress.Verify(p => p.UpdateMoodEntryAsync(It.IsAny<long>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task RetryingTheJournalEditorLoadsThePreviouslySelectedDay()
    {
        var (viewModel, progress, _) = await CreateWithSavedMoodAsync();
        DateOnly day = DateOnly.FromDateTime(DateTime.Today).AddDays(-1);
        progress.SetupSequence(p => p.GetMoodsAsync(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Journal storage unavailable"))
            .ReturnsAsync(new List<MoodEntryDTO>());

        viewModel.SelectDayCommand.Execute(day);
        await VmTestHelpers.WaitUntilAsync(() => viewModel.IsEditorLoadFailed);
        bool wasMorning = viewModel.IsMorningSelected;

        await VmTestHelpers.RunAsync(viewModel.RetryEditorLoadCommand);

        Assert.True(viewModel.IsEditorReady);
        Assert.Equal(AppStrings.JournalEditorDayTitle(day), viewModel.DayHeaderText);
        Assert.Equal(wasMorning, viewModel.IsMorningSelected);
    }

    private static async Task<(JournalViewModel ViewModel, Mock<IUserProgressService> Progress, Mock<INavigationService> Navigation)>
        CreateWithSavedMoodAsync(IDialogService? dialogs = null, JournalEditorContext? editorContext = null)
    {
        var progress = new Mock<IUserProgressService>();
        progress.Setup(p => p.GetMoodsAsync(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<MoodEntryDTO> { new() { MoodEntryId = 1, MoodLevel = 2, RecordedAt = DateTime.UtcNow } });
        progress.Setup(p => p.GetRecentTechniqueCompletionsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync([]);
        var navigation = new Mock<INavigationService>();
        navigation.Setup(n => n.GoToCrisisHubAsync()).Returns(Task.CompletedTask);
        JournalViewModel viewModel = new(new JournalMoodLoader(progress.Object, new KeywordCrisisDetector()),
            editorContext ?? new JournalEditorContext(), dialogs ?? Mock.Of<IDialogService>(), navigation.Object);
        await viewModel.ReloadAsync();
        return (viewModel, progress, navigation);
    }
}
