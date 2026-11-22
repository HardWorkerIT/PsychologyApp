using PsychologyApp.Presentation.Shared.Services.Preferences;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Abstractions.Startup;
using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Pages.Onboarding;
using PsychologyApp.Presentation.Features.Onboarding.DependencyInjection;
using PsychologyApp.Presentation.Shared.Services.Toasts;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.App.Routes;
using PsychologyApp.Presentation.Shared.UI.Overlays;

namespace PsychologyApp.Presentation.App;

public sealed class ShellStartupCoordinator(
    IAppStartupService startupService,
    IOnboardingViewModelFactory onboardingViewModelFactory,
    IClinicalCareService clinicalCareService,
    IPageFactory pageFactory,
    IDialogService dialogService,
    IOptions<AppSettings> settings,
    IDatabaseReadySignal databaseReadySignal,
    IToastService toastService,
    IUserPreferencesStore preferences,
    ILogger<ShellStartupCoordinator> logger) : IShellStartupCoordinator
{
    public async Task InitializeAsync()
    {
        try
        {
            using CancellationTokenSource timeoutSource = OperationCancellation.CreateLargeTimeoutSource(settings);
            await startupService.InitializeAsync(timeoutSource.Token);
            await preferences.RestoreOnboardingConcernAsync(timeoutSource.Token);
            databaseReadySignal.SignalReady();
            startupService.WarmupAsync().FireAndForget();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Application startup failed.");
            databaseReadySignal.SignalFailed(ex);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                toastService.ShortToast(AppStrings.StartupErrorMessage, AppToastKind.Error);
                return Task.CompletedTask;
            });

            throw;
        }
    }

    public Task ShowOnboardingIfNeededAsync(
        INavigation navigation,
        Func<TechniqueId?, Task> onTechniqueSelected)
    {
        if (preferences.Load().HasCompletedOnboarding)
        {
            return Task.CompletedTask;
        }

        return ShowOnboardingAsync(navigation, onTechniqueSelected);
    }

    public async Task ShowOnboardingAsync(
        INavigation navigation,
        Func<TechniqueId?, Task> onTechniqueSelected)
    {
        TaskCompletionSource onboardingCompleted = new(TaskCreationOptions.RunContinuationsAsynchronously);
        bool completingFromOnboarding = false;
        OnboardingPage? onboardingPage = null;

        void OnOnboardingPageDisappearing(object? sender, EventArgs args)
        {
            if (!completingFromOnboarding)
            {
                onboardingCompleted.TrySetResult();
            }
        }

        try
        {
            await Task.Delay(300);
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                onboardingPage = new(onboardingViewModelFactory, async techniqueId =>
                {
                    completingFromOnboarding = true;
                    try
                    {
                        await Task.Yield();
                        await navigation.PopModalAsync(false);
                        await onTechniqueSelected(techniqueId);
                    }
                    finally
                    {
                        onboardingCompleted.TrySetResult();
                    }
                }, dialogService);

                onboardingPage.Disappearing += OnOnboardingPageDisappearing;
                PressFeedbackHost.AttachToPage(onboardingPage);
                await navigation.PushModalAsync(onboardingPage, false);
            });

            if (onboardingPage is not null)
            {
                await onboardingCompleted.Task;
            }
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Onboarding presentation skipped.");
        }
        finally
        {
            if (onboardingPage is not null)
            {
                onboardingPage.Disappearing -= OnOnboardingPageDisappearing;
            }
        }
    }

    public async Task ShowClinicalGateIfNeededAsync(INavigation navigation)
    {
        if (!preferences.Load().HasCompletedOnboarding)
        {
            return;
        }

        await ShowClinicalGateAsync(navigation);
    }

    private async Task ShowClinicalGateAsync(INavigation navigation)
    {
        try
        {
            if (await clinicalCareService.ShouldRouteToCrisisHubAsync())
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await navigation.PushAsync(MauiNavigationService.PrepareSecondaryPage(pageFactory.CreateCrisisHubPage()), true);
                });
                return;
            }

            // Do not make a safety questionnaire the first screen after onboarding. The person can start one any time from Profile.
            RiskAssessmentDTO? latestAssessment = await clinicalCareService.GetLatestRiskAssessmentAsync();
            if (latestAssessment is null)
            {
                return;
            }

            if (await clinicalCareService.IsRiskCheckDueAsync(ClinicalCareService.DefaultRiskCheckInterval))
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await navigation.PushAsync(
                        MauiNavigationService.PrepareSecondaryPage(pageFactory.CreateRiskCheckPage(AppStrings.RiskCheckSourcePeriodic)),
                        true);
                });
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Clinical care gate failed, opening crisis fallback.");
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                toastService.ShortToast(AppStrings.StartupErrorMessage, AppToastKind.Error);
                await navigation.PushAsync(MauiNavigationService.PrepareSecondaryPage(pageFactory.CreateCrisisHubPage()), true);
            });
        }
    }
}
