using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Practice;
using PsychologyApp.Application.Recommendations;
using PsychologyApp.Application.Technique;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using PsychologyApp.Presentation.Features.RunTechniqueSession.Index;
using PsychologyApp.Presentation.Pages.RunTechniqueSession.PracticeCompletion;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.Services.Donations;
using PsychologyApp.Presentation.Shared.Services.Notifications;
using PsychologyApp.Presentation.Shared.Services.Preferences;
using System.Text.Json;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

public sealed class TechniqueSessionCompletionServiceTests
{
    private static TechniqueSessionCompletionService CreateService(Mock<IClinicalCareService>? clinicalCare = null)
    {
        Mock<IClinicalCareService> clinical = clinicalCare ?? new Mock<IClinicalCareService>();
        clinical.Setup(s => s.GetActiveProgramAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync((TherapyProgramStateDTO?)null);
        return new TechniqueSessionCompletionService(Mock.Of<IPracticeReminderCoordinator>(), clinical.Object);
    }

    [Fact]
    public async Task CompleteStandardSessionAsync_RecordsProgress_DeletesDraft_AndNavigates()
    {
        Mock<IUserProgressService> progress = new();
        progress.Setup(p => p.GetActiveDaysThisWeekAsync(It.IsAny<CancellationToken>())).ReturnsAsync(3);
        progress.Setup(p => p.GetSessionDraftAsync("Paper", It.IsAny<CancellationToken>())).ReturnsAsync((string?)null);
        progress.Setup(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(42L);
        Mock<INavigationService> navigation = new();
        navigation.Setup(n => n.GoToPracticeCompletionAsync(It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<long?>())).ReturnsAsync(NavigationRunStatus.Completed);
        TechniqueSessionCompletionService service = CreateService();
        DateTime startedAt = DateTime.UtcNow.AddMinutes(-2);

        await service.CompleteStandardSessionAsync(
            progress.Object,
            navigation.Object,
            "Paper",
            "Practice",
            "Paper technique",
            startedAt,
            new PracticeSessionCompletionState(),
            preIntensity: 7,
            postIntensity: 2);

        progress.Verify(
            p => p.RecordSessionOutcomeAsync(
                It.Is<SessionOutcomeRequest>(request =>
                    request.ItemKey == "Paper"
                    && request.ModuleName == "Practice"
                    && request.PageName == "Paper technique"
                    && request.PreIntensity == 7
                    && request.PostIntensity == 2
                    && request.DeleteDraft
                    && request.DurationSeconds >= 110 && request.DurationSeconds <= 130),
                It.IsAny<CancellationToken>()),
            Times.Once);
        progress.Verify(p => p.UpdateSessionResultPostIntensityAsync(It.IsAny<long>(), It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        navigation.Verify(n => n.GoToPracticeCompletionAsync(3, "Paper", 42L), Times.Once);
    }

    [Fact]
    public async Task AFailedCompletionKeepsTheCurrentAnswersForRetryWithoutReadingAnOlderDraft()
    {
        const string currentAnswers = "{\"Fields\":{\"0\":\"current answer\"}}";
        var progress = new Mock<IUserProgressService>();
        var navigation = new Mock<INavigationService>();
        var completion = new PracticeSessionCompletionState();
        var service = CreateService();
        progress.SetupSequence(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Storage unavailable"))
            .ReturnsAsync(42L);
        navigation.Setup(n => n.GoToPracticeCompletionAsync(It.IsAny<int>(), "Paper", 42L)).ReturnsAsync(NavigationRunStatus.Completed);

        Task CompleteAsync() => service.CompleteStandardSessionAsync(progress.Object, navigation.Object, "Paper", "Practice",
            "Paper", DateTime.UtcNow, completion, sessionPayloadJson: currentAnswers);

        await Assert.ThrowsAsync<IOException>(CompleteAsync);
        Assert.False(completion.HasSavedResult);
        navigation.Verify(n => n.GoToPracticeCompletionAsync(It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<long?>()), Times.Never);

        await CompleteAsync();

        Assert.True(completion.HasSavedResult);
        progress.Verify(p => p.GetSessionDraftAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        progress.Verify(p => p.RecordSessionOutcomeAsync(It.Is<SessionOutcomeRequest>(request =>
            request.PayloadJson == currentAnswers && request.DeleteDraft), It.IsAny<CancellationToken>()), Times.Exactly(2));
        navigation.Verify(n => n.GoToPracticeCompletionAsync(It.IsAny<int>(), "Paper", 42L), Times.Once);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SavedPracticeShowsItsResultWhenOptionalWorkFails(bool weeklyActivityFails)
    {
        var progress = new Mock<IUserProgressService>();
        var reminder = new Mock<IPracticeReminderCoordinator>();
        var navigation = new Mock<INavigationService>();
        progress.Setup(p => p.GetSessionDraftAsync("Paper", It.IsAny<CancellationToken>())).ReturnsAsync((string?)null);
        progress.Setup(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(42L);
        if (weeklyActivityFails)
        {
            progress.Setup(p => p.GetActiveDaysThisWeekAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new IOException("Weekly activity unavailable"));
        }
        else
        {
            progress.Setup(p => p.GetActiveDaysThisWeekAsync(It.IsAny<CancellationToken>())).ReturnsAsync(3);
            reminder.Setup(r => r.SyncAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new IOException("Reminder unavailable"));
        }

        var service = new TechniqueSessionCompletionService(reminder.Object, Mock.Of<IClinicalCareService>());
        await service.CompleteStandardSessionAsync(progress.Object, navigation.Object, "Paper", "Practice", "Paper", DateTime.UtcNow, new());

        navigation.Verify(n => n.GoToPracticeCompletionAsync(weeklyActivityFails ? 0 : 3, "Paper", 42L), Times.Once);
        reminder.Verify(r => r.SyncAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CompletingAPracticeAfterLeavingTheScreenKeepsTheSaveAndDoesNotRetryNavigation()
    {
        var progress = new Mock<IUserProgressService>();
        var navigation = new Mock<INavigationService>();
        progress.Setup(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(42L);
        navigation.Setup(n => n.GoToPracticeCompletionAsync(0, "Paper", 42L))
            .ReturnsAsync(NavigationRunStatus.DroppedInactiveSource);
        PracticeSessionCompletionState completion = new();

        await CreateService().CompleteStandardSessionAsync(
            progress.Object, navigation.Object, "Paper", "Practice", "Paper", DateTime.UtcNow, completion);

        Assert.True(completion.HasSavedResult);
        navigation.Verify(n => n.GoToPracticeCompletionAsync(0, "Paper", 42L), Times.Once);
    }

    [Fact]
    public async Task TryingToOpenASavedPracticeAgainDoesNotRecordASecondCompletion()
    {
        var progress = new Mock<IUserProgressService>();
        var navigation = new Mock<INavigationService>();
        progress.Setup(p => p.GetActiveDaysThisWeekAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        progress.Setup(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(42L);
        navigation.SetupSequence(n => n.GoToPracticeCompletionAsync(1, "Paper", 42L))
            .ReturnsAsync(NavigationRunStatus.Failed)
            .ReturnsAsync(NavigationRunStatus.DroppedTimeout)
            .ReturnsAsync(NavigationRunStatus.Failed)
            .ReturnsAsync(NavigationRunStatus.Completed);
        ListTechniqueSessionHelper session = new(CreateService(), progress.Object, navigation.Object);
        DateTime startedAt = DateTime.UtcNow;

        await Assert.ThrowsAsync<InvalidOperationException>(() => session.CompleteAsync("Paper", "Practice", "Paper", startedAt));
        Assert.True(session.HasSavedResult);
        await session.CompleteAsync("Paper", "Practice", "Paper", startedAt);

        progress.Verify(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        navigation.Verify(n => n.GoToPracticeCompletionAsync(1, "Paper", 42L), Times.Exactly(4));
    }

    [Fact]
    public async Task CompleteStandardSessionAsync_SkipsDraftDelete_WhenDisabled()
    {
        Mock<IUserProgressService> progress = new();
        progress.Setup(p => p.GetActiveDaysThisWeekAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        progress.Setup(p => p.GetSessionDraftAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync((string?)null);
        progress.Setup(p => p.RecordSessionOutcomeAsync(It.IsAny<SessionOutcomeRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(7L);
        Mock<INavigationService> navigation = new();
        navigation.Setup(n => n.GoToPracticeCompletionAsync(It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<long?>())).ReturnsAsync(NavigationRunStatus.Completed);
        TechniqueSessionCompletionService service = CreateService();

        await service.CompleteStandardSessionAsync(
            progress.Object,
            navigation.Object,
            "custom_5",
            "Practice",
            "Custom",
            DateTime.UtcNow,
            new PracticeSessionCompletionState(),
            deleteDraft: false);

        progress.Verify(
            p => p.RecordSessionOutcomeAsync(
                It.Is<SessionOutcomeRequest>(request => request.ItemKey == "custom_5" && !request.DeleteDraft),
                It.IsAny<CancellationToken>()),
            Times.Once);
        navigation.Verify(n => n.GoToPracticeCompletionAsync(1, "custom_5", 7L), Times.Once);
    }
}

public sealed class PracticeCompletionViewModelSafetyTests
{
    [Fact]
    public async Task TensionRatingKeepsTheLatestChoiceAndCanRetryAFailedWrite()
    {
        var outcome = new TaskCompletionSource<SessionResultDTO?>(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstWrite = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var latestWrite = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var progress = new Mock<IUserProgressService>();
        progress.Setup(p => p.GetSessionResultAsync(42, It.IsAny<CancellationToken>())).Returns(outcome.Task);
        progress.Setup(p => p.GetRecentMoodsAsync(3, It.IsAny<CancellationToken>())).ReturnsAsync([]);
        progress.Setup(p => p.UpdateSessionResultPostIntensityAsync(42, 8, It.IsAny<CancellationToken>())).Returns(firstWrite.Task);
        progress.SetupSequence(p => p.UpdateSessionResultPostIntensityAsync(42, 3, It.IsAny<CancellationToken>()))
            .Returns(latestWrite.Task)
            .Returns(Task.CompletedTask);
        var resolver = new NextPracticeResolver(progress.Object, Mock.Of<IUserPreferencesStore>(),
            Mock.Of<ITechniqueRecommendationService>(), new TechniqueCatalogGateway(Mock.Of<ITechniqueCatalogService>()),
            Mock.Of<IClinicalCareService>());
        var viewModel = new PracticeCompletionViewModel(Mock.Of<INavigationService>(), progress.Object, resolver,
            Mock.Of<ICrisisDetector>(), Mock.Of<IDonationSupportService>(), 1, sessionResultId: 42);

        viewModel.PostIntensityText = "8";
        viewModel.PostIntensityText = "3";
        progress.Verify(p => p.UpdateSessionResultPostIntensityAsync(42, 3, It.IsAny<CancellationToken>()), Times.Never);
        outcome.SetResult(new SessionResultDTO { PreIntensity = 9, PostIntensity = 8 });
        await ViewModels.VmTestHelpers.WaitUntilAsync(() => viewModel.HasSudsDelta);
        Assert.Equal("3", viewModel.PostIntensityText);

        firstWrite.SetResult();
        latestWrite.SetException(new IOException("Storage unavailable"));
        await ViewModels.VmTestHelpers.WaitUntilAsync(() => viewModel.HasPostIntensitySaveError);
        await ViewModels.VmTestHelpers.RunAsync(viewModel.RetryPostIntensityCommand);

        Assert.False(viewModel.HasPostIntensitySaveError);
        Assert.Equal("3", viewModel.PostIntensityText);
        progress.Verify(p => p.UpdateSessionResultPostIntensityAsync(42, 3, It.IsAny<CancellationToken>()), Times.Exactly(2));
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task FinishingSavesReflectionAndKeepsPageOpenIfSavingFails(bool moodAlreadySaved)
    {
        var progress = new Mock<IUserProgressService>();
        progress.Setup(p => p.GetRecentMoodsAsync(3, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<MoodEntryDTO>());
        progress.Setup(p => p.RecordMoodAsync(3, null, null, It.IsAny<CancellationToken>()))
            .ReturnsAsync(7L);
        progress.SetupSequence(p => p.UpdateSessionResultNoteAsync(42, "A short reflection", It.IsAny<CancellationToken>()))
            .ThrowsAsync(new IOException("Storage unavailable"))
            .Returns(Task.CompletedTask);
        var navigation = new Mock<INavigationService>();
        var catalog = Mock.Of<ITechniqueCatalogService>();
        var resolver = new NextPracticeResolver(progress.Object, Mock.Of<IUserPreferencesStore>(),
            Mock.Of<ITechniqueRecommendationService>(), new TechniqueCatalogGateway(catalog),
            Mock.Of<IClinicalCareService>());
        var viewModel = new PracticeCompletionViewModel(navigation.Object, progress.Object, resolver,
            Mock.Of<ICrisisDetector>(), Mock.Of<IDonationSupportService>(), 1, sessionResultId: 42);

        if (moodAlreadySaved)
        {
            var moodSaved = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            viewModel.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName == nameof(viewModel.SelectedMoodLevel))
                {
                    moodSaved.TrySetResult();
                }
            };
            viewModel.RecordMoodCommand.Execute(3);
            await moodSaved.Task.WaitAsync(TimeSpan.FromSeconds(3));
        }

        viewModel.ReflectionNote = "A short reflection";
        await viewModel.FinishAsync();

        Assert.Equal("A short reflection", viewModel.ReflectionNote);
        Assert.False(string.IsNullOrWhiteSpace(viewModel.ReflectionSaveStatus));
        navigation.Verify(n => n.GoBackAsync(), Times.Never);

        await viewModel.FinishAsync();

        progress.Verify(p => p.UpdateSessionResultNoteAsync(42, "A short reflection", It.IsAny<CancellationToken>()), Times.Exactly(2));
        progress.Verify(p => p.UpdateMoodEntryAsync(7, 3, "A short reflection", It.IsAny<CancellationToken>()),
            moodAlreadySaved ? Times.Once() : Times.Never());
        navigation.Verify(n => n.GoBackAsync(), Times.Once);
    }

    [Fact]
    public async Task CompletionWaitsForSavedAnswersAndDoesNotOfferAnotherPracticeOnCrisis()
    {
        const string answer = "Crisis in the saved answer";
        var result = new TaskCompletionSource<SessionResultDTO?>(TaskCreationOptions.RunContinuationsAsynchronously);
        var progress = new Mock<IUserProgressService>();
        progress.Setup(p => p.GetSessionResultAsync(42, It.IsAny<CancellationToken>()))
            .Returns(result.Task);
        progress.Setup(p => p.GetRecentMoodsAsync(3, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<MoodEntryDTO>());

        var catalog = new Mock<ITechniqueCatalogService>();
        var paper = new BuiltInTechniqueDefinition(
            "Practice", "Paper", [], "", PsychologyApp.Domain.Practice.TechniqueUiKind.Entry,
            "", "", "Paper", "", "", "", 3, "");
        catalog.Setup(c => c.GetAsync(PsychologyApp.Domain.Practice.TechniqueId.Paper, It.IsAny<CancellationToken>()))
            .ReturnsAsync(paper);

        var detector = new Mock<ICrisisDetector>();
        detector.Setup(d => d.IsCrisis(answer)).Returns(true);
        var preferences = new Mock<IUserPreferencesStore>();
        var resolver = new NextPracticeResolver(progress.Object, preferences.Object,
            Mock.Of<ITechniqueRecommendationService>(),
            new TechniqueCatalogGateway(catalog.Object),
            Mock.Of<IClinicalCareService>());
        var viewModel = new PracticeCompletionViewModel(
            Mock.Of<INavigationService>(), progress.Object, resolver, detector.Object,
            Mock.Of<IDonationSupportService>(),
            1, "Paper", 42, catalog.Object);

        Assert.False(viewModel.HasNextPractice);
        preferences.Verify(p => p.Load(), Times.Never);

        var crisisShown = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        viewModel.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(viewModel.IsCrisis) && viewModel.IsCrisis)
            {
                crisisShown.TrySetResult();
            }
        };
        result.SetResult(new SessionResultDTO
        {
            ItemKey = "Paper",
            PayloadJson = """{"Items":[{"Text":"Crisis in the saved answer"}]}"""
        });
        await crisisShown.Task.WaitAsync(TimeSpan.FromSeconds(3));

        Assert.False(viewModel.HasNextPractice);
        preferences.Verify(p => p.Load(), Times.Never);
    }
}

public sealed class EntryDraftCoordinatorTests
{
    [Fact]
    public async Task LoadAsync_RestoresSavedFieldValues()
    {
        TechniqueId techniqueId = TechniqueId.Spin;
        string key = techniqueId.ToString();
        string json = JsonSerializer.Serialize(new { Fields = new Dictionary<string, string> { ["0"] = "Saved text" } });
        Mock<IUserProgressService> progress = new();
        progress.Setup(p => p.GetSessionDraftAsync(key, It.IsAny<CancellationToken>())).ReturnsAsync(json);
        List<EntryItem> entries = [new EntryItem { Title = "Episode" }];
        EntryDraftCoordinator coordinator = new(NullLogger<EntryDraftCoordinator>.Instance);
        coordinator.Attach(techniqueId, entries, progress.Object);

        await coordinator.LoadAsync(() => { });

        Assert.Equal("Saved text", entries[0].Text);
    }

    [Fact]
    public async Task SaveAsync_PersistsNonEmptyFields()
    {
        TechniqueId techniqueId = TechniqueId.Spin;
        string key = techniqueId.ToString();
        Mock<IUserProgressService> progress = new();
        progress.Setup(p => p.SaveSessionDraftAsync(key, It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        List<EntryItem> entries =
        [
            new EntryItem { Title = "Episode", Text = "Draft value" },
            new EntryItem { Title = "Feeling" }
        ];
        EntryDraftCoordinator coordinator = new(NullLogger<EntryDraftCoordinator>.Instance);
        coordinator.Attach(techniqueId, entries, progress.Object);

        await coordinator.SaveAsync();

        progress.Verify(
            p => p.SaveSessionDraftAsync(
                key,
                It.Is<string>(payload => payload.Contains("Draft value", StringComparison.Ordinal)),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}

public sealed class CustomTechniqueSessionOperationsTests
{
    [Fact]
    public async Task RemoveAsync_WhenConfirmed_DeletesAndSendsRemoveMessage()
    {
        Mock<ITechniqueService> techniqueService = new();
        TechniqueDTO dto = new() { TechniqueId = 9, Header = "Custom" };
        techniqueService.Setup(s => s.GetTechniqueByIdAsync(9, It.IsAny<CancellationToken>())).ReturnsAsync(dto);
        techniqueService.Setup(s => s.DeleteTechniqueAsync(dto, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        Mock<ITechniqueMessenger> messenger = new();
        Mock<IDialogService> dialog = new();
        dialog.Setup(d => d.AskAsync(It.IsAny<string>(), AppStrings.PracticeDeleteConfirm, AppStrings.Yes, AppStrings.No))
            .ReturnsAsync(true);
        CustomTechniqueSessionOperations operations = new();

        bool removed = await operations.RemoveAsync(
            9,
            techniqueService.Object,
            messenger.Object,
            dialog.Object,
            CancellationToken.None);

        Assert.True(removed);
        techniqueService.Verify(s => s.DeleteTechniqueAsync(dto, It.IsAny<CancellationToken>()), Times.Once);
        messenger.Verify(
            m => m.Send(It.Is<TechniqueMessage>(msg => msg.MessageType == TechniqueMessageType.Remove && msg.Technique.TechniqueId == 9)),
            Times.Once);
    }

    [Fact]
    public async Task RemoveAsync_WhenCancelled_DoesNotDelete()
    {
        Mock<ITechniqueService> techniqueService = new();
        Mock<ITechniqueMessenger> messenger = new();
        Mock<IDialogService> dialog = new();
        dialog.Setup(d => d.AskAsync(It.IsAny<string>(), AppStrings.PracticeDeleteConfirm, AppStrings.Yes, AppStrings.No))
            .ReturnsAsync(false);
        CustomTechniqueSessionOperations operations = new();

        bool removed = await operations.RemoveAsync(
            9,
            techniqueService.Object,
            messenger.Object,
            dialog.Object,
            CancellationToken.None);

        Assert.False(removed);
        techniqueService.Verify(s => s.DeleteTechniqueAsync(It.IsAny<TechniqueDTO>(), It.IsAny<CancellationToken>()), Times.Never);
        messenger.Verify(m => m.Send(It.IsAny<TechniqueMessage>()), Times.Never);
    }
}
