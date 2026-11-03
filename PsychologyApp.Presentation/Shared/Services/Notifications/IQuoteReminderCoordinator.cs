namespace PsychologyApp.Presentation.Shared.Services.Notifications;

public interface IQuoteReminderCoordinator
{
    Task SyncAsync(CancellationToken cancellationToken = default);
    Task RescheduleAsync(CancellationToken cancellationToken = default);
}
