using PsychologyApp.Presentation.Features.Chat.DependencyInjection;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Pages.Chat.ChatList;

public partial class ChatListPage : ContentPage
{
    private const int MaxStaggeredRows = 8;
    private const int RowStaggerMs = 45;

    private readonly ChatListViewModel _viewModel;
    private readonly HashSet<long> _revealed = [];
    private AppTheme _requestedTheme = GetRequestedTheme();

    public ChatListPage(IChatViewModelFactory viewModelFactory, INavigation? hostNavigation)
    {
        InitializeComponent();
        // As the Chat tab there is no host stack: the page pushes onto its own.
        _viewModel = viewModelFactory.CreateList(hostNavigation ?? Navigation);
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Microsoft.Maui.Controls.Application.Current is { } application)
        {
            application.RequestedThemeChanged -= OnRequestedThemeChanged;
            application.RequestedThemeChanged += OnRequestedThemeChanged;
        }

        AppTheme requestedTheme = GetRequestedTheme();
        bool themeChanged = requestedTheme != _requestedTheme;
        _requestedTheme = requestedTheme;
        _viewModel.RefreshAsync(forceReplace: themeChanged).FireAndForget();
    }

    protected override void OnDisappearing()
    {
        if (Microsoft.Maui.Controls.Application.Current is { } application)
        {
            application.RequestedThemeChanged -= OnRequestedThemeChanged;
        }

        base.OnDisappearing();
    }

    private void OnRequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        if (e.RequestedTheme == _requestedTheme)
        {
            return;
        }

        _requestedTheme = e.RequestedTheme;
        _viewModel.RefreshAsync(forceReplace: true).FireAndForget();
    }

    private static AppTheme GetRequestedTheme() =>
        Microsoft.Maui.Controls.Application.Current?.RequestedTheme ?? AppTheme.Light;

    /// <summary>Rows slide in one after another the first time they are shown. Rows already shown (recycled while scrolling, or rebuilt on refresh) stay put.</summary>
    private void OnChatRowContextChanged(object? sender, EventArgs e)
    {
        if (sender is not VisualElement row)
        {
            return;
        }

        if (row.BindingContext is not ChatListItem item || !_revealed.Add(item.Id) || ReduceMotion.IsEnabled)
        {
            UiAnimations.ResetVisualState(row);
            return;
        }

        row.Opacity = 0;
        int index = Math.Clamp(_viewModel.Chats.IndexOf(item), 0, MaxStaggeredRows);
        UiAnimations.SafeRevealLiteAsync(row, allowHidden: true, delayMs: 16 + (index * RowStaggerMs)).FireAndForget();
    }
}
