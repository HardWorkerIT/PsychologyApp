using PsychologyApp.Presentation.Shared.Common.Diagnostics;
using Microsoft.Extensions.Logging;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Entities.Technique;
using PsychologyApp.Presentation.Features.RunTechniqueSession;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    private bool _initialized;

    public bool HasInitialized => _initialized;

    public async Task EnsureInitializedAsync()
    {
        if (_initialized)
        {
            return;
        }

        await InitializeAsync(showLoadingOverlay: true);
    }

    private async Task InitializeAsync(bool showLoadingOverlay)
    {
        await _initGate.WaitAsync();
        try
        {
            if (showLoadingOverlay)
            {
                await UiThread.RunAsync(SetInit);
            }

            // The first start opens, and on a fresh install creates, the encrypted database; on a slow phone that alone outlasted the
            // load timeout, and the catalog stayed "no practices yet" until a restart. The timeout bounds the load, not this wait.
            await _databaseReadySignal.WaitAsync(CancellationToken.None);
            using CancellationTokenSource timeoutSource = OperationCancellation.CreateMiddleTimeoutSource(_settings);
            await InitAsync(timeoutSource.Token, showLoadingOverlay: false);
        }
        finally
        {
            _initGate.Release();
        }
    }

    public async Task InitAsync(CancellationToken cancellationToken, bool showLoadingOverlay = true)
    {
        try
        {
            if (showLoadingOverlay)
            {
                await UiThread.RunAsync(SetInit);
            }

            await _databaseReadySignal.WaitAsync(cancellationToken);

            Task<TechniquesInitSnapshot> snapshotTask = _listInitializer.LoadAsync(
                _techniqueService,
                _techniqueListBuilder,
                _dashboardLoader,
                _navigationService,
                MyTechniquesLabel,
                cancellationToken);
            Task<TodayRecommendationResult> recommendationTask = _dashboardLoader.ResolveTodayRecommendationAsync(
                _navigationService,
                cancellationToken);

            await Task.WhenAll(snapshotTask, recommendationTask);

            TechniquesInitSnapshot snapshot = await snapshotTask;
            TodayRecommendationResult recommendation = await recommendationTask;
            Task<bool> hasDraftTask = _dashboardLoader.HasSessionDraftAsync(recommendation.TechniqueId, cancellationToken);
            await _todayRecommendationResolver.ApplyCatalogDateAsync(
                recommendation.Item,
                recommendation.TechniqueId,
                snapshot.StaticItems,
                cancellationToken);
            bool hasDraft = await hasDraftTask;

            await UiThread.RunAsync(() =>
            {
                long applyStarted = System.Diagnostics.Stopwatch.GetTimestamp();
                StreakDays = snapshot.StreakDays;
                IsReturning = snapshot.IsReturning;
                HasTodayDraft = hasDraft;
                _todayTechniqueId = recommendation.TechniqueId;
                TodayReasonText = recommendation.ReasonText;
                TodayTechniqueItem = recommendation.Item;
                OnPropertyChanged(nameof(TodayReasonText));
                OnPropertyChanged(nameof(TodayTechniqueItem));
                OnPropertyChanged(nameof(TodayActionText));
                ApplyUiState(snapshot.UiState);
                ApplyCustomTechniquesPagingState(snapshot);
                _hasLoadedList = true;
                _initialized = true;
                SetDone();
                PerfTrace.Measure("Techniques list applied", applyStarted);
            });
        }
        catch (OperationCanceledException)
        {
            await UiThread.RunAsync(() =>
            {
                if (_hasLoadedList)
                {
                    CancelProgress();
                }
                else
                {
                    SetFail();
                }

                _initialized = false;
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Practice tab initialization failed.");
            await UiThread.RunAsync(() =>
            {
                SetFail();
                _initialized = false;
            });
            _toastService.ShortToast(AppStrings.PracticeInitError);
        }
    }

    private void ReloadLocalizedContent() =>
        ReloadLocalizedContentAsync().FireAndForget();

    private async Task ReloadLocalizedContentAsync()
    {
        if (!_initialized)
        {
            return;
        }

        await _initGate.WaitAsync();
        try
        {
            using CancellationTokenSource timeoutSource = OperationCancellation.CreateMiddleTimeoutSource(_settings);
            await InitAsync(timeoutSource.Token, showLoadingOverlay: false);
        }
        finally
        {
            _initGate.Release();
        }
    }
}
