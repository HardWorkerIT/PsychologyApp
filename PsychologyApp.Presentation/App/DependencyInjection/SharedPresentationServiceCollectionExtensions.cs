using PsychologyApp.Application.Abstractions.Persistence;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif
using PsychologyApp.Presentation.App.Routes;
using PsychologyApp.Presentation.Features.Chat;
using PsychologyApp.Presentation.Features.ClinicalCare;
using PsychologyApp.Presentation.Features.ManageJournal.DependencyInjection;
using PsychologyApp.Presentation.Features.ManageProfile;
using PsychologyApp.Presentation.Features.ManageQuotes.DependencyInjection;
using PsychologyApp.Presentation.Features.PlayMusic.DependencyInjection;
using PsychologyApp.Presentation.Features.ReadArticles;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using PsychologyApp.Presentation.Features.RunTests;
using PsychologyApp.Presentation.Features.SendReviewForm;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Common.Localization;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using PsychologyApp.Presentation.Shared.Services.Clipboard;
using PsychologyApp.Presentation.Shared.Services.Notifications;
using PsychologyApp.Presentation.Shared.Services.Preferences;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.Services.Toasts;
using PsychologyApp.Presentation.Shared.Services.Speech;
using PsychologyApp.Presentation.Shared.Services.Security;
using PsychologyApp.Presentation.Shared.Navigation;

namespace PsychologyApp.Presentation.App.DependencyInjection;

public static class SharedPresentationServiceCollectionExtensions
{
    public static IServiceCollection AddSharedPresentation(this IServiceCollection services)
    {
        services.AddSingleton<IDatabaseKeyProvider, PsychologyApp.Presentation.Shared.Platform.MauiDatabaseKeyProvider>();
        services.AddSingleton<IToastService, ToastService>();
        services.AddSingleton<IAppClipboardService, AppClipboardService>();
        services.AddSingleton<IPageHost, MauiPageHost>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<ISpeechInput, DeviceSpeechInput>();
        services.AddSingleton<ChipUsageStore>();
        services.AddSingleton<GlobalExceptionHandler>();
        services.AddSingleton<IPageViewModelActivator, PageViewModelActivator>();
        // AppShell resolves IPageFactory at startup; defer inactive feature graphs until their pages are requested.
        services.AddSingleton<Func<IProfilePageFactory>>(sp => () => sp.GetRequiredService<IProfilePageFactory>());
        services.AddSingleton<Func<IJournalPageFactory>>(sp => () => sp.GetRequiredService<IJournalPageFactory>());
        services.AddSingleton<Func<IReviewPageFactory>>(sp => () => sp.GetRequiredService<IReviewPageFactory>());
        services.AddSingleton<Func<ITestPageFactory>>(sp => () => sp.GetRequiredService<ITestPageFactory>());
        services.AddSingleton<Func<ITechniquePageFactory>>(sp => () => sp.GetRequiredService<ITechniquePageFactory>());
        services.AddSingleton<Func<IClinicalCarePageFactory>>(sp => () => sp.GetRequiredService<IClinicalCarePageFactory>());
        services.AddSingleton<Func<IReadArticlesPageFactory>>(sp => () => sp.GetRequiredService<IReadArticlesPageFactory>());
        services.AddSingleton<Func<IChatPageFactory>>(sp => () => sp.GetRequiredService<IChatPageFactory>());
        services.AddSingleton<Func<IPracticeTheoryNavigator>>(sp => () => sp.GetRequiredService<IPracticeTheoryNavigator>());
        services.AddSingleton<Func<IMusicPlayerViewModelFactory>>(sp => () => sp.GetRequiredService<IMusicPlayerViewModelFactory>());
        services.AddSingleton<Func<IQuoteViewModelFactory>>(sp => () => sp.GetRequiredService<IQuoteViewModelFactory>());
        services.AddSingleton<IPageFactory, PageRegistry>();
        services.AddSingleton<IShellStartupCoordinator, ShellStartupCoordinator>();
        services.AddSingleton<IUserPreferencesStore, MauiUserPreferencesStore>();
        services.AddSingleton<IPracticeReminderCoordinator, PracticeReminderCoordinator>();
        services.AddSingleton<IQuoteReminderCoordinator, QuoteReminderCoordinator>();
        services.AddSingleton<IMoodReminderCoordinator, MoodReminderCoordinator>();
        services.AddSingleton<IChatReminderCoordinator, ChatReminderCoordinator>();
#if ANDROID
        services.AddSingleton<IPracticeReminderScheduler, AndroidPracticeReminderScheduler>();
        services.AddSingleton<IQuoteReminderScheduler, AndroidQuoteReminderScheduler>();
        services.AddSingleton<IMoodReminderScheduler, AndroidMoodReminderScheduler>();
        services.AddSingleton<IChatReminderScheduler, AndroidChatReminderScheduler>();
        services.AddSingleton<IDeviceAuthenticator, AndroidDeviceAuthenticator>();
#else
        services.AddSingleton<IPracticeReminderScheduler, NullPracticeReminderScheduler>();
        services.AddSingleton<IQuoteReminderScheduler, NullQuoteReminderScheduler>();
        services.AddSingleton<IMoodReminderScheduler, NullMoodReminderScheduler>();
        services.AddSingleton<IChatReminderScheduler, NullChatReminderScheduler>();
        services.AddSingleton<IDeviceAuthenticator, UnavailableDeviceAuthenticator>();
#endif
        services.AddSingleton<IDatabaseReadySignal, DatabaseReadySignal>();
        services.AddSingleton<LanguageContentReloader>();
        services.AddSingleton<Func<NavigationContext, INavigationService>>(sp => context =>
            context.NavigationService ?? new MauiNavigationService(
                context,
                sp.GetRequiredService<IPageFactory>(),
                sp.GetRequiredService<IShellStartupCoordinator>(),
                sp.GetRequiredService<PsychologyApp.Presentation.Features.ManageJournal.JournalScreenCoordinator>(),
                sp.GetRequiredService<IUserPreferencesStore>(),
                sp.GetRequiredService<PsychologyApp.Presentation.Features.RunTests.TestOpener>()));

        return services;
    }

    internal static void AddTransientFactory<T>(IServiceCollection services) where T : class
    {
        services.AddTransient<T>();
        services.AddSingleton<Func<T>>(sp => () => sp.GetRequiredService<T>());
    }
}
