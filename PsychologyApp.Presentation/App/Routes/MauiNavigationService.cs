using PsychologyApp.Presentation.Shared.Services.Preferences;
﻿using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Features.ManageJournal;
using PsychologyApp.Presentation.Features.RunTests;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Entities.Test;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using AppShell = PsychologyApp.Presentation.App.AppShell;
#if ANDROID
using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Pages.ReadArticles.ArticleReader;
using PsychologyApp.Presentation.Pages.ReadArticles.Articles;
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.App.Routes;

public sealed class MauiNavigationService : INavigationService
{
    private readonly INavigation? _navigation;
    private readonly WeakReference<ContentPage>? _ownerPage;
    private readonly IPageFactory _pageFactory;
    private readonly IShellStartupCoordinator _shellStartupCoordinator;
    private readonly JournalScreenCoordinator _journalScreenCoordinator;
    private readonly IUserPreferencesStore _preferences;
    private readonly TestOpener _testOpener;

    public MauiNavigationService(
        NavigationContext context,
        IPageFactory pageFactory,
        IShellStartupCoordinator shellStartupCoordinator,
        JournalScreenCoordinator journalScreenCoordinator,
        IUserPreferencesStore preferences,
        TestOpener testOpener)
    {
        _testOpener = testOpener;
        _preferences = preferences;
        _navigation = context.Navigation;
        _ownerPage = context.OwnerPage is { } page ? new WeakReference<ContentPage>(page) : null;
        _pageFactory = pageFactory;
        _shellStartupCoordinator = shellStartupCoordinator;
        _journalScreenCoordinator = journalScreenCoordinator;
    }

    public INavigation Navigation => ResolveNavigation();

    public Task GoBackAsync() =>
#if ANDROID
        NavigationCoordinator.RunAsync(async () =>
        {
            INavigation navigation = ResolveNavigation();
            var reader = Shell.Current?.CurrentPage as ArticleReaderPage;
            await navigation.PopAsync(true);
            if (reader is not { CanShowInterstitialOnReturn: true })
            {
                return;
            }

            // Popping detaches the reader's navigation proxy. Check the page Shell actually presents.
            if (reader.HasReachedEnd
                && Shell.Current?.CurrentPage is ArticlesPage { IsBrowsingGeneralCatalog: true } catalog
                && catalog.Navigation.ModalStack.Count == 0)
            {
                VkInterstitialAds.ShowIfReady(_preferences.Load());
            }
            else
            {
                Android.Util.Log.Info("VkInterstitial", $"Reader return skipped: reachedEnd={reader.HasReachedEnd}.");
                VkInterstitialAds.DiscardPending();
            }
        });
#else
        NavigationCoordinator.RunAsync(() => ResolveNavigation().PopAsync(true));
#endif

    public Task GoToRootAsync() =>
        NavigationCoordinator.RunAsync(() => ResolveNavigation().PopToRootAsync(true));

    public Task GoToTechniqueAsync(TechniqueId techniqueId) =>
        NavigationCoordinator.RunPushAsync(() =>
        {
            INavigation hostNavigation = ResolveNavigation();
            return hostNavigation.PushAsync(
                PrepareSecondaryPage(_pageFactory.CreateTechniquePage(techniqueId, hostNavigation)),
                true);
        });

    public Task GoToCreatedAsync(long techniqueId) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateCreatedPage(techniqueId)), false));

    public Task GoToDesignerAsync(long techniqueId) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateDesignerPage(techniqueId)), false));

    public Task GoToUserProfileAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateUserPage()), true));

    public Task GoToPracticeHistoryAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreatePracticeHistoryPage()), true));

    public Task GoToJournalAsync() =>
        NavigationCoordinator.RunAsync(() =>
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.ShowTab(appShell.JournalShellTab);
            }

            return Task.CompletedTask;
        });

    public Task GoToJournalDayAsync(DateOnly day) =>
        _journalScreenCoordinator.OpenEditorDayAsync(day, this);

    public Task GoToJournalOverviewAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateJournalOverviewPage()), true));

    public Task GoToJournalTimelineAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateJournalTimelinePage()), true));

    public Task GoToOptionsAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateOptionsPage()), true));

    public Task GoToInfoAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateInfoPage()), true));

    public Task GoToFormAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateFormPage()), true));

    public Task GoToSettingsAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateSettingsPage()), true));

    public Task GoToTheoryAsync(string content, TechniqueId? techniqueId = null) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateTheoryPage(content, techniqueId)), false));

    public Task GoToFindProblemAsync(string? description, List<string> algorithm, string? comment, Func<Task> startTest, string? testId = null) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateFindProblemPage(description, algorithm, comment, startTest, testId)), false));

    public Task GoToQuestionPageAsync(List<Question> questions, Func<int, string> scoreAnalyzer, bool singleAnswer, TestSessionInfo? session = null) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateQuestionPage(questions, scoreAnalyzer, singleAnswer, session)), true));

    public Task GoToLuscherTestAsync(LuscherMode mode) =>
        NavigationCoordinator.RunPushAsync(() => mode switch
        {
            LuscherMode.Standard => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateStandardTestPage()), false),
            LuscherMode.Brief => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateAlternativeTestPage()), false),
            _ => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateAlternativeTestPage()), false)
        });

    public Task GoToStandardTestAsync() =>
        GoToLuscherTestAsync(LuscherMode.Standard);

    public Task GoToAlternativeTestAsync() =>
        GoToLuscherTestAsync(LuscherMode.Brief);

    public Task GoToTestHistoryAsync(string testId, string testTitle) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateTestHistoryPage(testId, testTitle)), true));

    public Task GoToTestsListAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateTestsListPage()), true));

    public Task<NavigationRunStatus> GoToTestResultAsync(
        TestResultInfo result,
        CancellationToken cancellationToken = default) =>
        ReplaceOwnerPageAsync(
            _ =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return _pageFactory.CreateTestResultPage(result);
            },
            nameof(GoToTestResultAsync),
            animated: false);

    /// <summary>
    /// The finished practice leaves the stack once its result is shown: Back from the result used to land on the practice again,
    /// and its "Finish" recorded the same session a second time.
    /// </summary>
    public Task<NavigationRunStatus> GoToPracticeCompletionAsync(int activeDays, string? completedItemKey = null, long? sessionResultId = null) =>
        ReplaceOwnerPageAsync(
            _ => _pageFactory.CreatePracticeCompletionPage(activeDays, completedItemKey, sessionResultId),
            $"{nameof(GoToPracticeCompletionAsync)}:{sessionResultId}");

    public Task<NavigationRunStatus> OpenNextPracticeAsync(TechniqueId techniqueId) =>
        ReplaceOwnerPageAsync(navigation => _pageFactory.CreateTechniquePage(techniqueId, navigation), nameof(OpenNextPracticeAsync));

    private Task<NavigationRunStatus> ReplaceOwnerPageAsync(
        Func<INavigation, ContentPage> createPage, string destination, bool animated = true) =>
        NavigationCoordinator.RunCompletionPushAsync(async () =>
        {
            if (_ownerPage is null || !_ownerPage.TryGetTarget(out ContentPage? owner))
            {
                return NavigationRunStatus.DroppedInactiveSource;
            }

            INavigation navigation = _navigation ?? owner.Navigation;
            if (navigation.NavigationStack.Count <= 1
                || !ReferenceEquals(navigation.NavigationStack[^1], owner)
                || navigation.ModalStack.Count != 0
                || (Shell.Current?.CurrentPage is { } current && !ReferenceEquals(current, owner)))
            {
                return NavigationRunStatus.DroppedInactiveSource;
            }

            await navigation.PushAsync(
                PrepareSecondaryPage(createPage(navigation)),
                animated);
            if (navigation.NavigationStack.Contains(owner))
            {
                try
                {
                    navigation.RemovePage(owner);
                }
                catch (Exception error)
                {
                    // The destination is already on screen. Retrying could open it twice.
                    BestEffort.Report(error);
                }
            }
            return NavigationRunStatus.Completed;
        }, destination);

    public Task GoToTestsTabAsync() =>
        NavigationCoordinator.RunAsync(() =>
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.ShowTab(appShell.TestsTab);
            }

            return Task.CompletedTask;
        });

    public Task GoToPracticeTabAsync() =>
        NavigationCoordinator.RunAsync(() =>
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.ShowTab(appShell.PracticeShellTab);
            }

            return Task.CompletedTask;
        });

    // The menu's sections open over the current tab and keep the tab bar: they are places of their own, not steps of a task.
    public Task GoToQuotesAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateQuotePage(), true));

    public Task GoToPrayersAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateMusicPlayerPage(), true));

    public Task GoToForYouAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateForYouPage(), true));

    public Task GoToCoursesAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateCoursesPage(), true));

    public Task GoToArticlesAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateArticlesPage(), true));

    public Task GoToAnchorThoughtsAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateAnchorThoughtsPage(), true));

    public Task GoToBodyAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateBodyCheckPage(), true));

    public Task GoToInsightsAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(_pageFactory.CreateInsightsPage(), true));

    public Task GoToQuotesFavoritesAsync()
    {
        _preferences.SetPendingQuoteFeed("favorites");
        return GoToQuotesAsync();
    }

    public Task ShowOnboardingAsync() =>
        NavigationCoordinator.RunAsync(() => _shellStartupCoordinator.ShowOnboardingAsync(
            ResolveNavigation(),
            CompleteOnboardingWithTechniqueAsync));


    public Task GoToChatListAsync() =>
        NavigationCoordinator.RunAsync(() =>
        {
            if (Shell.Current is AppShell appShell)
            {
                appShell.ShowTab(appShell.ChatShellTab);
            }

            return Task.CompletedTask;
        });

    // Every way into a chat (the tab, articles, reminders) passes here: in a language the chat cannot read for crisis words
    // the chat list opens instead, and says why.
    public Task GoToChatAsync(long? sessionId = null, string? topic = null, string? opener = null) =>
        !AppLanguages.HasChat(AppStrings.Language) ? GoToChatListAsync() : NavigationCoordinator.RunPushAsync(() =>
        {
            INavigation hostNavigation = ResolveNavigation();
            return hostNavigation.PushAsync(PrepareSecondaryPage(_pageFactory.CreateChatPage(sessionId, hostNavigation, topic, opener)), true);
        });

    public Task GoToCompanionProfileAsync() =>
        NavigationCoordinator.RunPushAsync(() =>
        {
            INavigation hostNavigation = ResolveNavigation();
            return hostNavigation.PushAsync(PrepareSecondaryPage(_pageFactory.CreateCompanionProfilePage(hostNavigation)), true);
        });

    public Task GoToChatInfoAsync(long sessionId) =>
        NavigationCoordinator.RunPushAsync(() =>
        {
            INavigation hostNavigation = ResolveNavigation();
            return hostNavigation.PushAsync(PrepareSecondaryPage(_pageFactory.CreateChatInfoPage(sessionId, hostNavigation)), true);
        });

    public async Task GoToCrisisHubAsync()
    {
        bool opened = await NavigationRetry.TryOpenPageAsync(
            () => Shell.Current?.CurrentPage is Pages.ClinicalCare.CrisisHub.CrisisHubPage,
            () =>
            {
                INavigation navigation = Shell.Current?.CurrentPage?.Navigation ?? ResolveNavigation();
                return navigation.PushAsync(PrepareSecondaryPage(_pageFactory.CreateCrisisHubPage()), true);
            });

        if (!opened)
        {
            throw new InvalidOperationException("The urgent help screen could not be opened.");
        }
    }

    public Task GoToRiskCheckAsync(string source) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateRiskCheckPage(source)), true));

    public Task GoToSafetyPlanAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateSafetyPlanPage()), true));

    public Task GoToExposureAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateExposurePage()), true));

    public Task GoToArticleAsync(string articleId) =>
#if ANDROID
        NavigationCoordinator.RunPushAsync(async () =>
        {
            INavigation navigation = ResolveNavigation();
            ArticleReaderPage reader = _pageFactory.CreateArticleReaderPage(articleId);
            // Only general reading can trigger an ad. Support and clinical articles stay outside this placement.
            reader.CanShowInterstitialOnReturn =
                articleId is ArticleIds.Sleep or ArticleIds.HabitFormation or ArticleIds.Procrastination
                    or ArticleIds.ValuesAction or ArticleIds.RestBreak
                && navigation.ModalStack.Count == 0
                && navigation.NavigationStack.LastOrDefault() is ArticlesPage { IsBrowsingGeneralCatalog: true };
            await navigation.PushAsync(PrepareSecondaryPage(reader), true);
            if (reader.CanShowInterstitialOnReturn
                && ReferenceEquals(navigation.NavigationStack.LastOrDefault(), reader))
            {
                VkInterstitialAds.Preload(_preferences.Load());
            }
        });
#else
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateArticleReaderPage(articleId)), true));
#endif

    public Task GoToTestAsync(string testId) => _testOpener.OpenAsync(testId, this);

    public Task GoToCourseAsync(string courseId) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateCoursePage(courseId)), true));

    public Task GoToCourseDayAsync(string courseId, int day) =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateCourseDayPage(courseId, day)), true));

    public Task GoToDataBackupAsync() =>
        NavigationCoordinator.RunPushAsync(() => ResolveNavigation().PushAsync(PrepareSecondaryPage(_pageFactory.CreateDataBackupPage()), true));

    /// <summary>
    /// A step inside a tab (a practice, a test, a chat, a form): no tab bar and no burger menu. A menu tap closes whatever is open over
    /// the tab, so the menu must not be reachable (also by an edge swipe) from a page with unsaved answers.
    /// </summary>
    internal static ContentPage PrepareSecondaryPage(ContentPage page)
    {
        Shell.SetTabBarIsVisible(page, false);
        Shell.SetFlyoutBehavior(page, FlyoutBehavior.Disabled);
        return page;
    }

    private Task CompleteOnboardingWithTechniqueAsync(TechniqueId? techniqueId)
    {
        if (techniqueId is null)
        {
            return Task.CompletedTask;
        }

        _preferences.SetPendingTechnique(techniqueId.Value);

        if (Shell.Current is AppShell appShell)
        {
            appShell.ShowTab(appShell.PracticeShellTab);
            appShell.OpenPendingTechniqueIfNeeded();
        }

        return Task.CompletedTask;
    }

    private INavigation ResolveNavigation()
    {
        if (_ownerPage?.TryGetTarget(out ContentPage? owner) == true && owner.Navigation is INavigation ownerNavigation)
        {
            return ownerNavigation;
        }

        Page? shellPage = Shell.Current?.CurrentPage;
        if (shellPage is not null && shellPage is not Shell && shellPage.Navigation is INavigation shellNavigation)
        {
            return shellNavigation;
        }

        if (ShellNavigationResolver.TryGetActiveTabStackNavigation() is INavigation tabStackNavigation)
        {
            return tabStackNavigation;
        }

        if (_navigation is not null)
        {
            return _navigation;
        }

        Page? windowPage = Microsoft.Maui.Controls.Application.Current?.Windows.FirstOrDefault()?.Page;
        if (windowPage?.Navigation is INavigation windowNavigation)
        {
            return windowNavigation;
        }

        throw new InvalidOperationException("Navigation is not available.");
    }
}
