using PsychologyApp.Presentation.Features.ManageQuotes;

namespace PsychologyApp.Presentation.Pages.ManageQuotes.QuoteFeed;

public sealed class QuoteFeedDisplayTemplateSelector : DataTemplateSelector
{
    // The page resource dictionary assigns these before the collection view requests a template.
    public DataTemplate QuoteTemplate { get; set; } = null!;
    public DataTemplate AdTemplate { get; set; } = null!;

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container) =>
        item is QuoteFeedDisplayItem { IsAdPlacement: true } ? AdTemplate : QuoteTemplate;
}
