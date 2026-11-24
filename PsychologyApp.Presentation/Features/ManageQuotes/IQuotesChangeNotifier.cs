using PsychologyApp.Presentation.Common;

namespace PsychologyApp.Presentation.Features.ManageQuotes;

public interface IQuotesChangeNotifier
{
    event Action? FavoritesChanged;

    void NotifyFavoritesChanged();
}

public sealed class QuotesChangeNotifier : IQuotesChangeNotifier
{
    private readonly WeakActionEvent _favoritesChanged = new();

    public event Action? FavoritesChanged
    {
        add
        {
            if (value is not null)
            {
                _favoritesChanged.Add(value);
            }
        }
        remove
        {
            if (value is not null)
            {
                _favoritesChanged.Remove(value);
            }
        }
    }

    public void NotifyFavoritesChanged() => _favoritesChanged.Raise();
}
