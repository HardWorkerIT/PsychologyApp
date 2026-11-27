using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Features.RunTechniqueSession;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.TechniqueSession.SubViewModels.PaperList;

public partial class PaperListViewModel
{
    private Task LoadDraftAsync() =>
        _draftCoordinator.LoadAsync(
            PapersObservableCollection,
            item => new Paper { Id = item.Id, Text = item.Text },
            SetCollection);

    private Task SaveDraftAsync() =>
        _sessionHelper.HasSavedResult ? Task.CompletedTask : _draftCoordinator.SaveAsync(
            PapersObservableCollection,
            paper => new PaperListDraftItem { Id = paper.Id, Text = paper.Text });

    private bool _completing;

    private async Task CompleteSessionAsync()
    {
        _completing = true;
        try
        {
            await SaveDraftAsync();
            await _sessionHelper.CompleteAsync(
                _techniqueId.ToString(),
                ModuleName,
                PageName,
                _sessionStartedAt,
                TryGetPreIntensity());
        }
        finally
        {
            _completing = false;
        }
    }

    private void SetCollection(bool visible)
    {
        IsFull = visible;
        OnPropertyChanged(nameof(EntryCountText));
        Notify(nameof(StageText), nameof(RepeatCount));
    }

    private void ToAdd(object obj)
    {
        if (_completing)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(Text))
        {
            return;
        }

        SetCollection(true);
        PapersObservableCollection.Add(new Paper
        {
            Id = AppStrings.RecordNumber(PapersObservableCollection.Count + 1),
            Text = Text
        });
        OnPropertyChanged(nameof(EntryCountText));
        Notify(nameof(StageText), nameof(RepeatCount));
        TechniqueEntryFeedback.PlayAddFeedback();

        if (_clearTextAfterAdd)
        {
            Text = string.Empty;
        }

        SaveDraftAsync().FireAndForget();
    }

    private void DeleteItem(Paper item)
    {
        if (_completing) return;
        if (item is null)
        {
            return;
        }

        PapersObservableCollection.Remove(item);
        SetCollection(PapersObservableCollection.Any());
        SaveDraftAsync().FireAndForget();
    }
}
