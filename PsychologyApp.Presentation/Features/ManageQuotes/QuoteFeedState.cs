using MvvmHelpers;
using PsychologyApp.Presentation.Entities.Quote;

namespace PsychologyApp.Presentation.Features.ManageQuotes;

public sealed class QuoteFeedState
{
    private const int AdPlacementAfterQuoteCount = 8;
    private const int BannerPlacementAfterQuoteCount = 3;

    public ObservableRangeCollection<QuoteItem> DisplayItems { get; } = [];
    public ObservableRangeCollection<QuoteFeedDisplayItem> DisplayRows { get; } = [];

    private List<QuoteItem> _feedItems = [];

    public int FeedItemCount => _feedItems.Count;

    public void ClearFeed()
    {
        _feedItems.Clear();
        DisplayItems.Clear();
        DisplayRows.Clear();
    }

    public void SetFeedItems(IReadOnlyList<QuoteItem> items)
    {
        _feedItems = items.ToList();
        SetDisplayItems(_feedItems, includeAds: true);
    }

    public void SetDisplayItems(IReadOnlyList<QuoteItem> items, bool includeAds = false)
    {
        DisplayItems.ReplaceRange(items);
        RebuildDisplayRows(items, includeAds);
    }

    public void RestoreFeedDisplay() => SetDisplayItems(_feedItems, includeAds: true);

    public void UpdateDisplayItem(int displayIndex, QuoteItem item)
    {
        if (displayIndex < 0 || displayIndex >= DisplayItems.Count)
        {
            return;
        }

        DisplayItems[displayIndex] = item;
        int rowIndex = GetDisplayRowIndex(displayIndex);
        if (rowIndex >= 0)
        {
            DisplayRows[rowIndex] = new QuoteFeedDisplayItem(item);
        }
    }

    public void AppendItems(IEnumerable<QuoteItem> items)
    {
        foreach (QuoteItem item in items)
        {
            _feedItems.Add(item);
            DisplayItems.Add(item);
            DisplayRows.Add(new QuoteFeedDisplayItem(item));
            if (DisplayItems.Count == BannerPlacementAfterQuoteCount)
            {
                DisplayRows.Add(new QuoteFeedDisplayItem(null, IsBannerPlacement: true));
            }
            if (DisplayItems.Count == AdPlacementAfterQuoteCount)
            {
                DisplayRows.Add(new QuoteFeedDisplayItem(isAdPlacement: true));
            }
        }
    }

    public bool TryUpdateFeedItem(QuoteItem quoteItem, bool isSearching)
    {
        int index = _feedItems.IndexOf(quoteItem);
        if (index < 0)
        {
            return false;
        }

        _feedItems[index] = quoteItem;
        if (!isSearching)
        {
            int displayIndex = DisplayItems.IndexOf(quoteItem);
            if (displayIndex >= 0)
            {
                UpdateDisplayItem(displayIndex, quoteItem);
            }
        }

        return true;
    }

    private void RebuildDisplayRows(IReadOnlyList<QuoteItem> items, bool includeAds)
    {
        DisplayRows.Clear();
        for (int index = 0; index < items.Count; index++)
        {
            DisplayRows.Add(new QuoteFeedDisplayItem(items[index]));
            if (includeAds && index + 1 == BannerPlacementAfterQuoteCount && items.Count >= BannerPlacementAfterQuoteCount)
            {
                DisplayRows.Add(new QuoteFeedDisplayItem(null, IsBannerPlacement: true));
            }
            if (includeAds && index + 1 == AdPlacementAfterQuoteCount && items.Count >= AdPlacementAfterQuoteCount)
            {
                DisplayRows.Add(new QuoteFeedDisplayItem(isAdPlacement: true));
            }
        }
    }

    private int GetDisplayRowIndex(int displayIndex)
    {
        int quoteIndex = 0;
        for (int rowIndex = 0; rowIndex < DisplayRows.Count; rowIndex++)
        {
            if (DisplayRows[rowIndex].Quote is null)
            {
                continue;
            }

            if (quoteIndex == displayIndex)
            {
                return rowIndex;
            }

            quoteIndex++;
        }

        return -1;
    }
}

public sealed record QuoteFeedDisplayItem(QuoteItem? Quote = null, bool IsAdPlacement = false, bool IsBannerPlacement = false)
{
    public QuoteFeedDisplayItem(bool isAdPlacement) : this(null, isAdPlacement)
    {
    }

}
