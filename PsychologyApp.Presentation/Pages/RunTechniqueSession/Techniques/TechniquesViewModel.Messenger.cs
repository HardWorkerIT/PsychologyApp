using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Features.RunTechniqueSession;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    private bool _subscribedToTechniqueChanges;

    internal void SubscribeToTechniqueChanges()
    {
        if (_subscribedToTechniqueChanges)
        {
            return;
        }

        _techniqueMessenger.Subscribe(this, OnTechniqueMessage);
        _subscribedToTechniqueChanges = true;
    }

    internal void UnsubscribeFromTechniqueChanges()
    {
        _techniqueMessenger.Unsubscribe(this);
        _subscribedToTechniqueChanges = false;
    }

    private void OnTechniqueMessage(TechniqueMessage message) =>
        ApplyTechniqueMessageAsync(message).FireAndForget();

    public async Task RefreshOnAppearAsync()
    {
        if (!_initialized)
        {
            await EnsureInitializedAsync();
        }

        await RefreshDashboardOnAppearAsync();
    }

    public async Task TryOpenPendingTechniqueAsync()
    {
        if (_dashboardLoader.ConsumePendingTechnique() is not TechniqueId techniqueId)
        {
            return;
        }

        await _navigationService.GoToTechniqueAsync(techniqueId);
    }

    public async Task TryOpenPendingJournalAsync()
    {
        if (!_preferences.ConsumePendingOpenJournal())
        {
            return;
        }

        await _navigationService.GoToJournalAsync();
    }
}
