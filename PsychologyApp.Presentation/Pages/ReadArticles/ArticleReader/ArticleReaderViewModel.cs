using System.Windows.Input;
using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using PsychologyApp.Presentation.Widgets.ArticleBlocks;

namespace PsychologyApp.Presentation.Pages.ReadArticles.ArticleReader;

/// <summary>One article: the blocks, saving it, listening to it, and "read" once it has been scrolled to the end.</summary>
public sealed class ArticleReaderViewModel : BaseViewModel
{
    private readonly INavigationService _navigation;
    private readonly IReadingService _reading;
    private readonly IDatabaseReadySignal _databaseReady;
    private readonly string _articleId;
    private readonly ReadAloud _readAloud = new();
    private IReadOnlyList<ArticleBlockItem> _blocks = [];
    private IReadOnlyList<string> _spoken = [];
    private string _title = string.Empty;
    private string _summary = string.Empty;
    private bool _isSaved;
    private bool _isRead;
    private bool _isMarkingRead;
    private bool _readSaveFailed;

    public ArticleReaderViewModel(INavigationService navigation, IReadingService reading, IDatabaseReadySignal databaseReady, string articleId)
    {
        BindNavigation(navigation);
        _navigation = navigation;
        _reading = reading;
        _databaseReady = databaseReady;
        _articleId = articleId;
        BackCommand = new AsyncCommand(() => _navigation.GoBackAsync());
        SaveCommand = new AsyncCommand(ToggleSavedAsync);
        RetryReadSaveCommand = new AsyncCommand(async () =>
        {
            _databaseReady.RequestRetry();
            await MarkReadAsync();
        });
        // This command must remain executable during speech so the same control can stop playback.
        ListenCommand = new Command(() => _readAloud.ToggleAsync(_spoken).FireAndForget());
        _readAloud.Changed += () => UiThread.RunAsync(() => Notify(
            nameof(ListenText), nameof(ListenIcon), nameof(ListenError), nameof(HasListenError))).FireAndForget();
        Load();
        LoadStateAsync().FireAndForget();
    }

    public ICommand BackCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand ListenCommand { get; }
    public ICommand RetryReadSaveCommand { get; }

    public string Title
    {
        get => _title;
        private set => SetProperty(ref _title, value);
    }

    public string Summary
    {
        get => _summary;
        private set => SetProperty(ref _summary, value);
    }

    public IReadOnlyList<ArticleBlockItem> Blocks
    {
        get => _blocks;
        private set => SetProperty(ref _blocks, value);
    }

    public string SaveText => _isSaved ? AppStrings.ArticleSaved : AppStrings.ArticleSave;
    public string SaveIcon => _isSaved ? "Bookmarks" : "BookmarkBorder";
    public string ListenText => _readAloud.IsSpeaking ? AppStrings.ArticleStopListening : AppStrings.ArticleListen;
    public string ListenIcon => _readAloud.IsSpeaking ? "StopCircle" : "VolumeUp";
    public string? ListenError => _readAloud.HasError ? AppStrings.ArticleListenUnavailable : null;
    public bool HasListenError => _readAloud.HasError;
    public string ReadMarkText => AppStrings.ArticleReadMark;
    public string ReadSaveFailedText => AppStrings.ArticleReadSaveFailed;
    public string RetryReadSaveText => AppStrings.RetryQuestion;
    public bool ShowReadSaveFailure => _readSaveFailed && !IsRead;

    public bool IsRead
    {
        get => _isRead;
        private set => SetProperty(ref _isRead, value);
    }

    /// <summary>The page calls this when the end of the article is on screen.</summary>
    public Task ReachedEndAsync() => _readSaveFailed ? Task.CompletedTask : MarkReadAsync();

    private async Task MarkReadAsync()
    {
        if (IsRead || _isMarkingRead)
        {
            return;
        }

        _isMarkingRead = true;
        try
        {
            await _databaseReady.WaitAsync();
            await _reading.MarkReadAsync(_articleId);
            IsRead = true;
            _readSaveFailed = false;
        }
        catch (Exception error)
        {
            _readSaveFailed = true;
            BestEffort.Report(error);
        }
        finally
        {
            _isMarkingRead = false;
            OnPropertyChanged(nameof(ShowReadSaveFailure));
        }
    }

    public void StopListening() => _readAloud.Stop();

    private void Load()
    {
        if (ArticleContent.Find(_articleId, AppStrings.Language) is not { } article)
        {
            return;
        }

        Title = article.Title;
        Summary = article.Summary;
        Blocks = ArticleBlockItems.Build(article.Blocks, _navigation);
        _spoken = ArticleSpeech.Parts(article.Title, article.Summary, article.Blocks);
    }

    private async Task LoadStateAsync()
    {
        await _databaseReady.WaitAsync();
        await _reading.OpenedAsync(_articleId);
        ReadingState state = await _reading.GetAsync();
        await UiThread.RunAsync(() =>
        {
            _isSaved = state.Saved.Contains(_articleId);
            IsRead |= state.Read.Contains(_articleId);
            Notify(nameof(SaveText), nameof(SaveIcon), nameof(ShowReadSaveFailure));
        });
    }

    private async Task ToggleSavedAsync()
    {
        _isSaved = await _reading.ToggleSavedAsync(_articleId);
        UiHaptics.Tick();
        Notify(nameof(SaveText), nameof(SaveIcon));
    }

    protected override void RefreshLocalizedProperties()
    {
        Load();
        Notify(nameof(SaveText), nameof(ListenText), nameof(ListenError), nameof(ReadMarkText),
            nameof(ReadSaveFailedText), nameof(RetryReadSaveText));
    }
}
