using Moq;
using PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.Services.Notifications;
using PsychologyApp.Presentation.Shared.Services.Preferences;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

/// <summary>The settings screen saves what the person picks (after a pause or on "Apply"), applies it, and puts the old look back when they leave without saving.</summary>
public sealed class SettingsViewModelTests
{
    private readonly Mock<IUserPreferencesStore> _store = new();
    private readonly Mock<INavigationService> _navigation = new();
    private readonly Mock<ILanguageContentReloader> _reloader = new();
    private readonly Mock<IPracticeReminderCoordinator> _practice = new();
    private readonly Mock<IQuoteReminderCoordinator> _quotes = new();
    private readonly Mock<IMoodReminderCoordinator> _mood = new();
    private readonly Mock<IChatReminderCoordinator> _chat = new();
    private readonly List<UserPreferencesState> _saved = [];
    private UserPreferencesState _state = new();

    private SettingsViewModel Create(bool remindersSupported = true)
    {
        _store.Setup(s => s.Load()).Returns(() => _state);
        _store.Setup(s => s.Save(It.IsAny<UserPreferencesState>())).Callback<UserPreferencesState>(s =>
        {
            _saved.Add(s);
            _state = s;
        });
        _reloader.Setup(r => r.EnsureReloadedAsync()).Returns(Task.CompletedTask);
        _practice.Setup(c => c.SyncAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _quotes.Setup(c => c.SyncAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mood.Setup(c => c.SyncAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _chat.Setup(c => c.SyncAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _practice.Setup(c => c.RescheduleAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _quotes.Setup(c => c.RescheduleAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mood.Setup(c => c.RescheduleAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _chat.Setup(c => c.RescheduleAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _navigation.Setup(n => n.GoBackAsync()).Returns(Task.CompletedTask);
        _navigation.Setup(n => n.ShowOnboardingAsync()).Returns(Task.CompletedTask);
        Mock<IPracticeReminderScheduler> scheduler = new();
        scheduler.SetupGet(s => s.IsSupported).Returns(remindersSupported);

        return new SettingsViewModel(
            _navigation.Object,
            _store.Object,
            new PsychologyApp.Presentation.Features.ManageProfile.SettingsPreferencesPresenter(),
            _reloader.Object,
            _practice.Object,
            _quotes.Object,
            _mood.Object,
            _chat.Object,
            scheduler.Object);
    }

    [Fact]
    public async Task AValidAdCodeIsSavedAndSurvivesOtherSettingChanges()
    {
        SettingsViewModel viewModel = Create();
        viewModel.AdCode = "  eisbrecher  ";
        viewModel.ApplyAdCodeCommand.Execute(null);
        Assert.True(viewModel.AdsDisabled);
        Assert.Equal(string.Empty, viewModel.AdCode);
        viewModel.Theme = "dark";
        await VmTestHelpers.WaitUntilAsync(() => _saved.Count > 0, 3000);
        Assert.True(_state.AdsDisabled);
        Assert.Equal("dark", _state.Theme);
        Assert.True(Create().AdsDisabled);
    }

    [Theory]
    [InlineData("")]
    [InlineData("EISBRECHERx")]
    [InlineData("wrong")]
    public void InvalidAdCodeDoesNotDisableAds(string code)
    {
        SettingsViewModel viewModel = Create();
        viewModel.AdCode = code;
        viewModel.ApplyAdCodeCommand.Execute(null);
        Assert.False(viewModel.AdsDisabled);
        Assert.False(_state.AdsDisabled);
        Assert.Equal(string.Empty, viewModel.AdCode);
    }

    [Fact]
    public void TheSavedChoicesAreShownWhenTheScreenOpens()
    {
        _state = new UserPreferencesState { Language = "en", Theme = "dark", Form = "square", Size = "large", IsBold = true, QuestionnaireAutoAdvance = false };

        SettingsViewModel viewModel = Create();

        Assert.Equal("en", viewModel.Language);
        Assert.Equal("dark", viewModel.Theme);
        Assert.Equal("square", viewModel.Form);
        Assert.Equal("large", viewModel.Size);
        Assert.True(viewModel.IsThick);
        Assert.False(viewModel.QuestionnaireAutoAdvance);
    }

    [Fact]
    public void RemindersAreHiddenWhereTheyAreNotSupported()
    {
        Assert.True(Create(remindersSupported: true).AreRemindersSupported);
        Assert.False(Create(remindersSupported: false).AreRemindersSupported);
    }

    [Fact]
    public async Task APickedLanguageIsSavedAfterAPauseAndEverythingIsRefreshed()
    {
        SettingsViewModel viewModel = Create();

        viewModel.Language = "English";
        Assert.Empty(_saved);
        await VmTestHelpers.WaitUntilAsync(() => _saved.Count == 1, 3000);
        await VmTestHelpers.WaitUntilAsync(() => _chat.Invocations.Count > 0, 3000);

        Assert.Equal("en", _saved[0].Language);
        _store.Verify(s => s.ApplyAll(), Times.AtLeastOnce);
        _reloader.Verify(r => r.EnsureReloadedAsync(), Times.Once);
        _practice.Verify(c => c.RescheduleAsync(It.IsAny<CancellationToken>()), Times.Once);
        _quotes.Verify(c => c.RescheduleAsync(It.IsAny<CancellationToken>()), Times.Once);
        _mood.Verify(c => c.RescheduleAsync(It.IsAny<CancellationToken>()), Times.Once);
        _chat.Verify(c => c.RescheduleAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task ChangingAppearanceDoesNotRequestNotificationPermission()
    {
        SettingsViewModel viewModel = Create();
        viewModel.Theme = "dark";
        await VmTestHelpers.WaitUntilAsync(() => _saved.Count == 1, 3000);
        await VmTestHelpers.RunAsync(viewModel.Finish);
        _practice.Verify(c => c.SyncAsync(It.IsAny<CancellationToken>()), Times.Never);
        _quotes.Verify(c => c.SyncAsync(It.IsAny<CancellationToken>()), Times.Never);
        _mood.Verify(c => c.SyncAsync(It.IsAny<CancellationToken>()), Times.Never);
        _chat.Verify(c => c.SyncAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task EnablingAReminderRequestsPermission()
    {
        SettingsViewModel viewModel = Create();
        viewModel.QuoteRemindersEnabled = true;
        await VmTestHelpers.WaitUntilAsync(() => _quotes.Invocations.Count > 0, 3000);
        _quotes.Verify(c => c.SyncAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task FailedReminderRescheduleIsRetriedOnNextSave()
    {
        SettingsViewModel viewModel = Create();
        _mood.SetupSequence(c => c.RescheduleAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new InvalidOperationException("temporary failure"))
            .Returns(Task.CompletedTask);
        viewModel.Language = "en";
        await VmTestHelpers.WaitUntilAsync(() => _mood.Invocations.Count == 1, 3000);
        viewModel.Form = "square";
        await VmTestHelpers.WaitUntilAsync(() => _mood.Invocations.Count == 2, 3000);
        _mood.Verify(c => c.RescheduleAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
        _chat.Verify(c => c.RescheduleAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task SeveralQuickChangesAreSavedOnceWithTheLastValues()
    {
        SettingsViewModel viewModel = Create();

        viewModel.Theme = "dark";
        await Task.Delay(100);
        viewModel.Form = "square";
        await Task.Delay(100);
        viewModel.Size = "large";
        await VmTestHelpers.WaitUntilAsync(() => _saved.Count >= 1, 3000);
        await Task.Delay(300);

        UserPreferencesState only = Assert.Single(_saved);
        Assert.Equal(("dark", "square", "large"), (only.Theme, only.Form, only.Size));
    }

    [Fact]
    public async Task EnglishDisplayTextsAreStoredAsTheirKeys()
    {
        SettingsViewModel viewModel = Create();

        viewModel.Form = "Square corners";
        viewModel.Theme = "Light";
        await VmTestHelpers.WaitUntilAsync(() => _saved.Count == 1, 3000);

        Assert.Equal("square", _saved[0].Form);
        Assert.Equal("light", _saved[0].Theme);
    }

    // There is no "Apply": a change just made and not saved yet must survive going back, not be undone.
    [Fact]
    public async Task LeavingKeepsAChangeStillWaitingForItsSave()
    {
        SettingsViewModel viewModel = Create();
        viewModel.Theme = "dark";

        await VmTestHelpers.RunAsync(viewModel.Finish);
        await Task.Delay(1000);

        Assert.Equal("dark", Assert.Single(_saved).Theme);
        _navigation.Verify(n => n.GoBackAsync(), Times.Once);
    }

    [Fact]
    public async Task LeavingWithNothingChangedSavesNothing()
    {
        SettingsViewModel viewModel = Create();

        await VmTestHelpers.RunAsync(viewModel.Finish);

        Assert.Empty(_saved);
        _navigation.Verify(n => n.GoBackAsync(), Times.Once);
    }

    [Fact]
    public async Task ReplayingTheOnboardingResetsItAndOpensIt()
    {
        SettingsViewModel viewModel = Create();

        await VmTestHelpers.RunAsync(viewModel.ReplayOnboardingCommand);

        _store.Verify(s => s.ResetOnboardingCompletion(), Times.Once);
        _navigation.Verify(n => n.ShowOnboardingAsync(), Times.Once);
    }

    [Fact]
    public async Task ReminderChoicesAreSavedAsHours()
    {
        SettingsViewModel viewModel = Create();

        viewModel.QuoteRemindersEnabled = true;
        viewModel.QuoteReminderHour = "10:00";
        viewModel.PracticeReminderHour = "21:00";
        await VmTestHelpers.WaitUntilAsync(() => _saved.Count == 1, 3000);

        Assert.True(_saved[0].QuoteRemindersEnabled);
        Assert.Equal(10, _saved[0].QuoteReminderHour);
        Assert.Equal(21, _saved[0].PracticeReminderHour);
    }
}
