namespace PsychologyApp.Presentation.Shared.Common;

public static class LocalizedContentView
{
    public static void SubscribePreferences(VisualElement view, Action refresh)
    {
        void Subscribe(object? sender, EventArgs e)
        {
            UserPreferences.Changed -= refresh;
            UserPreferences.Changed += refresh;
            refresh();
        }

        void Unsubscribe(object? sender, EventArgs e) => UserPreferences.Changed -= refresh;

        view.Loaded += Subscribe;
        view.Unloaded += Unsubscribe;
    }
}
