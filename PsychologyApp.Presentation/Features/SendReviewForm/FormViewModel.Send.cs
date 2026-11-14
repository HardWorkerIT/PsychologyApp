using PsychologyApp.Application.Configuration;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Features.SendReviewForm;

public partial class FormViewModel
{
    internal static FeedbackChannel ResolveChannel(AppSettings settings)
    {
        if (!string.IsNullOrWhiteSpace(settings.ReviewEmailAddress))
        {
            return FeedbackChannel.Email;
        }

        if (!string.IsNullOrWhiteSpace(settings.ReviewSmsRecipient))
        {
            return FeedbackChannel.Sms;
        }

        return FeedbackChannel.Share;
    }

    private async Task SendAsync()
    {
        if (string.IsNullOrWhiteSpace(MessageText))
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewMessageRequired);
            return;
        }

        // The platform can open a composer, but it cannot confirm that the person sent the message.
        Task composerTask = ResolveChannel(_settings) switch
        {
            FeedbackChannel.Email => OpenEmailComposerAsync(MessageText, _settings.ReviewEmailAddress),
            FeedbackChannel.Sms => OpenSmsComposerAsync(MessageText, _settings.ReviewSmsRecipient),
            FeedbackChannel.Share => OpenShareSheetAsync(MessageText),
            _ => Task.CompletedTask
        };
        await composerTask;
    }
}
