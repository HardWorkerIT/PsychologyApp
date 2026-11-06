using Microsoft.Extensions.Logging;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Entities.Technique;
using PsychologyApp.Presentation.Features;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    private bool _hasMoreCustomTechniques;
    private int _customTechniquesOffset;
    private TechniqueGroup? _customTechniquesGroup;
    private bool _isLoadingMoreCustomTechniques;

    public bool IsLoadingMoreCustomTechniques
    {
        get => _isLoadingMoreCustomTechniques;
        private set
        {
            if (SetProperty(ref _isLoadingMoreCustomTechniques, value))
            {
                OnPropertyChanged(nameof(LoadMoreFooterHeight));
            }
        }
    }

    /// <summary>
    /// Collapses CollectionView.Footer when idle — IsVisible=false alone often leaves reserved space.
    /// </summary>
    public double LoadMoreFooterHeight => IsLoadingMoreCustomTechniques ? 72 : 0;

    public async Task LoadMoreCustomTechniquesAsync()
    {
        if (!_hasMoreCustomTechniques
            || IsLoadingMoreCustomTechniques
            || _customTechniquesGroup is null)
        {
            return;
        }

        IsLoadingMoreCustomTechniques = true;
        bool initGateHeld = false;
        try
        {
            // Keep offsets and the visible custom group in sync with reloads and add/remove messages.
            using CancellationTokenSource timeoutSource = OperationCancellation.CreateSmallTimeoutSource(_settings);
            CancellationToken cancellationToken = timeoutSource.Token;
            await _initGate.WaitAsync(cancellationToken);
            initGateHeld = true;

            if (!_hasMoreCustomTechniques || _customTechniquesGroup is null)
            {
                return;
            }

            int pageSize = CatalogListPolicy.CustomTechniquesPageSize;
            int requestedOffset = _customTechniquesOffset;
            TechniqueGroup requestedGroup = _customTechniquesGroup;
            List<TechniqueDTO> page = (await _techniqueService.GetTechniquesPageAsync(
                requestedOffset,
                pageSize + 1,
                cancellationToken)).ToList();
            bool hasMore = page.Count > pageSize;
            List<TechniqueItem> items = _techniqueListBuilder.MapCustomItems(
                    page.Take(pageSize),
                    _navigationService)
                .ToList();

            await UiThread.RunAsync(() =>
            {
                if (!ReferenceEquals(_customTechniquesGroup, requestedGroup)
                    || _customTechniquesOffset != requestedOffset)
                {
                    return;
                }

                foreach (TechniqueItem item in items)
                {
                    requestedGroup.Add(item);
                }

                _customTechniquesOffset += items.Count;
                _hasMoreCustomTechniques = hasMore;
            });
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to load more custom techniques.");
            _toastService.ShortToast(AppStrings.PracticeLoadMoreError);
        }
        finally
        {
            if (initGateHeld)
            {
                _initGate.Release();
            }

            IsLoadingMoreCustomTechniques = false;
        }
    }

    private void ApplyCustomTechniquesPagingState(TechniquesInitSnapshot snapshot)
    {
        _hasMoreCustomTechniques = snapshot.HasMoreCustomTechniques;
        _customTechniquesOffset = snapshot.CustomTechniquesLoadedCount;
        _customTechniquesGroup = TechniqueGroups.LastOrDefault(group => group.IsCustom);
    }
}
