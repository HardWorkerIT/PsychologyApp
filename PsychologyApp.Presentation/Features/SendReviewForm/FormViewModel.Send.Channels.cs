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

    private async Task OpenSmsComposerAsync(string messageText, string recipient)
    {
        try
        {
            SmsMessage message = new(messageText, [recipient]);
            await Sms.Default.ComposeAsync(message);
        }
        catch (FeatureNotSupportedException)
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewSmsNotSupported);
        }
        catch (Exception)
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewSmsFailed);
        }
    }

    private async Task OpenShareSheetAsync(string messageText)
    {
        try
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Title = AppStrings.ReviewShareTitle,
                Text = messageText
            });
        }
        catch (Exception)
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewShareFailed);
        }
    }
}
