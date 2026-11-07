using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Features.RunTechniqueSession;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    // The singleton messenger keeps handlers weakly, so retain this delegate only while this page is subscribed.
    private Action<TechniqueMessage>? _techniqueMessageHandler;

    private void SubscribeToTechniqueChanges()
    {
        if (_techniqueMessageHandler is not null)
        {
            return;
        }

        Action<TechniqueMessage> handler = OnTechniqueMessage;
        _techniqueMessageHandler = handler;
        _techniqueMessenger.Subscribe(this, handler);
    }

    internal void UnsubscribeFromTechniqueChanges()
    {
        _techniqueMessenger.Unsubscribe(this);
        _techniqueMessageHandler = null;
    }

    private void OnTechniqueMessage(TechniqueMessage message) =>
        ApplyTechniqueMessageAsync(message).FireAndForget();

    public Task RefreshOnAppearAsync()
    {
        if (!_initialized)
        {
            return EnsureInitializedAsync();
        }

        return RefreshDashboardOnAppearAsync();
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
