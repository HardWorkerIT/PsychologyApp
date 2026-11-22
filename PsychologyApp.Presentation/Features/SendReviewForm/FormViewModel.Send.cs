using PsychologyApp.Application.Configuration;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Features.SendReviewForm;

public partial class FormViewModel
{
    internal static FeedbackChannel ResolveChannel(AppSettings _) => FeedbackChannel.Email;

    private async Task SendAsync()
    {
        if (string.IsNullOrWhiteSpace(MessageText))
        {
            await _dialogService.ShowAsync(null, AppStrings.ReviewMessageRequired);
            return;
        }

        // The composer is pre-addressed; the user still reviews and sends the message themselves.
        await OpenEmailComposerAsync(MessageText, _settings.ReviewEmailAddress);
    }
}
