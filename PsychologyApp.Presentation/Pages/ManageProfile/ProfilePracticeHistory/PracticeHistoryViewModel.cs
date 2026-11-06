using PsychologyApp.Presentation.Entities.Profile;
using PsychologyApp.Presentation.Features.ManageProfile;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfilePracticeHistory;

public sealed class PracticeHistoryViewModel : BaseViewModel
{
    private readonly ProfilePracticeHistoryLoader _loader;
    private readonly INavigationService _navigationService;
    private readonly SemaphoreSlim _loadGate = new(1, 1);
    private bool _isLoaded;
    private bool _isLoading;
    private bool _hasLoadError;
    private int _languageGeneration;
    private int _reloadAfterCurrentLoad;
    private string _languageKey = AppStrings.Language;

    public PracticeHistoryViewModel(
        ProfilePracticeHistoryLoader loader,
        INavigationService navigationService)
    {
        _loader = loader;
        _navigationService = navigationService;
        BindNavigation(navigationService);
        BackCommand = new AsyncCommand(() => navigationService.GoBackAsync());
        RetryCommand = new AsyncCommand(LoadAsync);
        LoadAsync().FireAndForget();
    }

    public string PageTitle => AppStrings.PracticeHistoryPageTitle;
    public string EmptyText => AppStrings.PracticeHistoryEmpty;
    public ICommand BackCommand { get; }
    public ICommand RetryCommand { get; }

    public bool IsLoading
    {
        get => _isLoading;
        private set
        {
            if (SetProperty(ref _isLoading, value))
            {
                Notify(nameof(ShowInitialLoading));
            }
        }
    }

    public bool HasLoadError
    {
        get => _hasLoadError;
        private set
        {
            if (SetProperty(ref _hasLoadError, value))
            {
                Notify(nameof(ShowLoadError));
            }
        }
    }

    public bool ShowInitialLoading => IsLoading && !_isLoaded;
    public bool ShowLoadError => HasLoadError && !_isLoaded;
    public string LoadErrorText => AppStrings.LoadError;
    public string RetryText => AppStrings.RetryQuestion;
    public string LoadingText => AppStrings.SkeletonLoadingLabel;

    private ObservableCollection<PracticeHistoryItem> _items = [];
    public ObservableCollection<PracticeHistoryItem> Items
    {
        get => _items;
        private set
        {
            if (SetProperty(ref _items, value))
            {
                OnPropertyChanged(nameof(HasItems));
                OnPropertyChanged(nameof(ShowEmpty));
            }
        }
    }

    public bool HasItems => Items.Count > 0;
    public bool ShowEmpty => _isLoaded && !HasItems;

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle), nameof(EmptyText), nameof(HasItems), nameof(ShowEmpty),
            nameof(LoadErrorText), nameof(RetryText), nameof(LoadingText));

        string language = AppStrings.Language;
        if (string.Equals(_languageKey, language, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        _languageKey = language;
        Interlocked.Increment(ref _languageGeneration);
        if (_loadGate.CurrentCount == 0)
        {
            Interlocked.Exchange(ref _reloadAfterCurrentLoad, 1);
            return;
        }

        LoadAsync().FireAndForget();
    }

    private async Task LoadAsync()
    {
        if (!await _loadGate.WaitAsync(0))
        {
            return;
        }

        try
        {
            int languageGeneration = Volatile.Read(ref _languageGeneration);
            await UiThread.RunAsync(() =>
            {
                IsLoading = true;
                HasLoadError = false;
            });

            IReadOnlyList<PracticeHistoryItem> loaded = await _loader.LoadAsync(40);
            await UiThread.RunAsync(() =>
            {
                if (languageGeneration != Volatile.Read(ref _languageGeneration))
                {
                    Interlocked.Exchange(ref _reloadAfterCurrentLoad, 1);
                    return;
                }

                Items = new ObservableCollection<PracticeHistoryItem>(
                    loaded.Select(item => ProfilePracticeHistoryTapFactory.WithTapCommand(item, _navigationService)));
                _isLoaded = true;
                OnPropertyChanged(nameof(ShowEmpty));
                IsLoading = false;
                HasLoadError = false;
            });
        }
        catch (Exception loadError)
        {
            BestEffort.Report(loadError);
            await UiThread.RunAsync(() =>
            {
                IsLoading = false;
                // Preserve an existing snapshot if a later reload fails.
                HasLoadError = !_isLoaded;
            });
        }
        finally
        {
            _loadGate.Release();
            if (Interlocked.Exchange(ref _reloadAfterCurrentLoad, 0) != 0)
            {
                LoadAsync().FireAndForget();
            }
        }
    }
}
