namespace PsychologyApp.Presentation.Shared.Services.Donations;

public interface IDonationSupportService
{
    bool CanSupportProject { get; }

    Task ShowTransferInstructionsAsync();
}
