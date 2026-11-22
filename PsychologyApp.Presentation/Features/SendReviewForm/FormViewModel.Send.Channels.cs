using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Dialogs;

namespace PsychologyApp.Presentation.Features.SendReviewForm;

public partial class FormViewModel
{
    private async Task OpenEmailComposerAsync(string messageText, string recipient)
    {
        try
        {
            await Email.Default.ComposeAsync(new EmailMessage
            {
                Subject = AppStrings.ReviewEmailSubject,
                Body = messageText,
                To = [recipient]
            });
        }
        catch (FeatureNotSupportedException)
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewEmailNotSupported);
        }
        catch (Exception)
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewEmailFailed);
        }
    }

}
