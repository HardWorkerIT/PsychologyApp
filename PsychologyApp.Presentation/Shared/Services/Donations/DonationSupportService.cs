using CommunityToolkit.Maui.Extensions;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Clipboard;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.UI.Overlays;

namespace PsychologyApp.Presentation.Shared.Services.Donations;

public sealed class DonationSupportService(
    IPageHost pageHost,
    IAppClipboardService clipboardService) : IDonationSupportService
{
    public bool CanSupportProject => DonationConfiguration.HasSberTransferPhoneNumber;

    public async Task ShowTransferInstructionsAsync()
    {
        if (!CanSupportProject || pageHost.GetActivePage() is not { } page)
        {
            return;
        }

        await page.ShowPopupAsync(new DonationSupportPopup(clipboardService), AppPopupOptions.OptionsSheet);
    }
}
