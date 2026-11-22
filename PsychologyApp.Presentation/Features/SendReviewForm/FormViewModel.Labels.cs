using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Features.SendReviewForm;

public partial class FormViewModel
{
    public string PageTitle => AppStrings.ReviewTitle;
    public string ExplanationBody => AppStrings.ReviewExplanation;
    public string RecipientText => AppStrings.ReviewRecipient(_settings.ReviewEmailAddress);
    public string MessagePlaceholder => AppStrings.ReviewMessagePlaceholder;
    public string SendButtonText => AppStrings.Send;

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(ExplanationBody),
            nameof(RecipientText),
            nameof(MessagePlaceholder),
            nameof(SendButtonText));
    }
}
