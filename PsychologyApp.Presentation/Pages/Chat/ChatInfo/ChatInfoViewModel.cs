using System.Windows.Input;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Application.Practice;
using PsychologyApp.Domain.Practice;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.ViewModels;

namespace PsychologyApp.Presentation.Pages.Chat.ChatInfo;

/// <summary>
/// The page about one chat, laid out like the AI psychologist's page: its tile, name and dates, what the chat held
/// (<see cref="ChatInfoSummary"/>), then its actions as rows. Rows the chat never reached are left out. Everything is read from the stored chat on the phone.
/// </summary>
public sealed class ChatInfoViewModel : BaseViewModel
{
    private readonly IChatService _chat;
    private readonly IChatLanguageProvider _language;
    private readonly IDialogService _dialogs;
    private readonly TimeProvider _time;
    private readonly ITechniqueCatalogService? _techniqueCatalog;
    private readonly long _sessionId;

    private ChatSessionDTO? _session;
    private ChatInfoSummary _summary = new(null, null, null, null, null);
    private string? _practiceText;
    private bool _isLoading = true;
    private bool _isLoadFailed;
    private int _refreshRequestId;
    private int _practiceTitleRequestId;
    private string _practiceTitleLanguageKey = AppStrings.Language;

    public ChatInfoViewModel(
        IChatService chat,
        INavigationService navigationService,
        IChatLanguageProvider language,
        IDialogService dialogs,
        TimeProvider time,
        long sessionId,
        ITechniqueCatalogService? techniqueCatalog = null)
    {
        ModuleName = AppStrings.ChatsTitle;
        PageName = AppStrings.ChatInfoTitle;
        _chat = chat;
        _language = language;
        _dialogs = dialogs;
        _time = time;
        _sessionId = sessionId;
        _techniqueCatalog = techniqueCatalog;

        BindNavigation(navigationService);
        BackCommand = new AsyncCommand(GoBackAsync);
        ReloadCommand = new AsyncCommand(RefreshAsync);
        RenameCommand = new AsyncCommand(RenameAsync);
        DeleteCommand = new AsyncCommand(DeleteAsync);
        PracticeCommand = new AsyncCommand(OpenPracticeAsync);
        AboutCompanionCommand = new AsyncCommand(() => NavigationService!.GoToCompanionProfileAsync());
    }

    public ICommand BackCommand { get; }
    public ICommand ReloadCommand { get; }

    public ICommand RenameCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand PracticeCommand { get; }
    public ICommand AboutCompanionCommand { get; }

    public bool IsLoading
    {
        get => _isLoading;
        private set
        {
            if (SetProperty(ref _isLoading, value))
            {
                OnPropertyChanged(nameof(HasLoaded));
            }
        }
    }

    public bool HasLoaded => !IsLoading && !IsLoadFailed;
    public bool IsLoadFailed
    {
        get => _isLoadFailed;
        private set
        {
            if (SetProperty(ref _isLoadFailed, value))
            {
                OnPropertyChanged(nameof(HasLoaded));
            }
        }
    }

    public string PageTitle => AppStrings.ChatInfoTitle;
    public string Title => _session?.Title ?? string.Empty;

    public string DatesText => _session is null
        ? string.Empty
        : AppStrings.ChatInfoStarted(
            _session.CreatedAt.ToLocalTime().ToString("d MMMM"),
            ChatTimeFormatter.DayLabel(_session.UpdatedAt, _time.GetUtcNow().UtcDateTime, _language.IsEnglish).ToLower(System.Globalization.CultureInfo.CurrentCulture));

    /// <summary>The chat's icon and colour group, as in the chat list; a chat with no recognised state gets the conversation icon.</summary>
    public string IconName => ChatCardLook.For(_summary.Emotion).Icon ?? "Forum";
    public TechniqueFlavor Flavor => ChatCardLook.For(_summary.Emotion).Flavor;

    public string RenameText => AppStrings.ChatInfoRename;
    public string DeleteText => AppStrings.ChatInfoDelete;
    public string SectionText => AppStrings.ChatInfoSection;
    public string FeelingLabel => AppStrings.ChatInfoFeeling;
    public string TensionLabel => AppStrings.ChatInfoTension;
    public string PracticeLabel => AppStrings.ChatInfoPractice;
    public string StepLabel => AppStrings.ChatInfoStep;
    public string OnPhoneText => AppStrings.ChatInfoOnPhone;
    public string AboutCompanionText => AppStrings.ChatInfoAboutCompanion;
    public string LoadingText => AppStrings.ChatLoadingText;
    public string LoadFailedText => AppStrings.LoadFailed;
    public string RetryText => AppStrings.RetryQuestion;

    public string? FeelingText => AppStrings.ChatEmotion(_summary.Emotion);
    public string? TensionText => _summary.TensionText;
    public string? PracticeText => _summary.Practice is not null ? _practiceText : null;
    public string? StepText => _summary.Step;

    public bool HasFeeling => FeelingText is not null;
    public bool HasTension => TensionText is not null;
    public bool HasPractice => PracticeText is not null;
    public bool HasStep => StepText is not null;
    public bool HasSummary => !_summary.IsEmpty;

    /// <summary>Reloads the chat. Safe on every appearing: a rename from another page shows at once.</summary>
    public async Task RefreshAsync()
    {
        int requestId = Interlocked.Increment(ref _refreshRequestId);
        if (_session is null)
        {
            IsLoadFailed = false;
            IsLoading = true;
        }

        try
        {
            ChatSessionDTO? session = await _chat.GetChatAsync(_sessionId);
            if (requestId != Volatile.Read(ref _refreshRequestId))
            {
                return;
            }

            if (session is null)
            {
                // Deleted elsewhere: there is nothing left to describe.
                await NavigationService!.GoToRootAsync();
                return;
            }

            _session = session;
            _summary = ChatInfoSummary.From(session);
            _practiceText = _summary.Practice is { } practice ? FallbackPracticeTitle(practice) : null;
            int titleRequestId = Interlocked.Increment(ref _practiceTitleRequestId);
            string languageKey = AppStrings.Language;
            _practiceTitleLanguageKey = languageKey;
            NotifyAll();
            IsLoadFailed = false;
            IsLoading = false;

            if (_summary.Practice is { } practiceId)
            {
                SafeAsync.Run(() => LoadPracticeTextAsync(practiceId, titleRequestId, languageKey));
            }
        }
        catch (Exception loadError)
        {
            BestEffort.Report(loadError);
            if (requestId == Volatile.Read(ref _refreshRequestId) && _session is null)
            {
                IsLoadFailed = true;
                IsLoading = false;
            }
        }
    }

    private async Task LoadPracticeTextAsync(TechniqueId practice, int requestId, string languageKey)
    {
        string title;
        try
        {
            title = _techniqueCatalog is null
                ? await Task.Run(() => CompanionContent.TechniqueTitle(practice, languageKey))
                : (await _techniqueCatalog.GetAsync(practice)).ListTitle;
        }
        catch (Exception titleError)
        {
            BestEffort.Report(titleError);
            try
            {
                title = await Task.Run(() => CompanionContent.TechniqueTitle(practice, languageKey));
            }
            catch (Exception fallbackError)
            {
                BestEffort.Report(fallbackError);
                return;
            }
        }

        await UiThread.RunAsync(() =>
        {
            if (requestId == Volatile.Read(ref _practiceTitleRequestId) && _summary.Practice == practice)
            {
                _practiceText = title;
                Notify(nameof(PracticeText), nameof(HasPractice));
            }
        });
    }

    private static string FallbackPracticeTitle(TechniqueId id) =>
        CompanionContent.TechniqueTitle(id, !AppStrings.Language.StartsWith("ru", StringComparison.OrdinalIgnoreCase));

    private void NotifyAll() =>
        Notify(nameof(Title), nameof(DatesText), nameof(IconName), nameof(Flavor), nameof(FeelingText), nameof(TensionText), nameof(PracticeText),
            nameof(StepText), nameof(HasFeeling), nameof(HasTension), nameof(HasPractice), nameof(HasStep), nameof(HasSummary));

    private async Task RenameAsync()
    {
        if (_session is null)
        {
            return;
        }

        string? name = await _dialogs.PromptTextAsync(AppStrings.ChatRenameTitle, AppStrings.ChatRenameMessage, AppStrings.ChatRenameAccept, AppStrings.ChatCancel, _session.Title, maxLength: 30);
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        await _chat.RenameAsync(_sessionId, name);
        await RefreshAsync();
    }

    private async Task DeleteAsync()
    {
        bool confirmed = await _dialogs.AskAsync(AppStrings.ChatDeleteTitle, AppStrings.ChatDeleteBody, AppStrings.ChatDelete, AppStrings.ChatCancel);
        if (!confirmed)
        {
            return;
        }

        await _chat.DeleteAsync(_sessionId);
        // Past the deleted chat too, back to the list.
        await NavigationService!.GoToRootAsync();
    }

    private Task OpenPracticeAsync() =>
        _summary.Practice is TechniqueId practice ? NavigationService!.GoToTechniqueAsync(practice) : Task.CompletedTask;

    protected override void RefreshLocalizedProperties()
    {
        string languageKey = AppStrings.Language;
        if (!string.Equals(_practiceTitleLanguageKey, languageKey, StringComparison.Ordinal))
        {
            _practiceTitleLanguageKey = languageKey;
            int titleRequestId = Interlocked.Increment(ref _practiceTitleRequestId);
            if (_summary.Practice is { } practice)
            {
                _practiceText = FallbackPracticeTitle(practice);
                SafeAsync.Run(() => LoadPracticeTextAsync(practice, titleRequestId, languageKey));
            }
            else
            {
                _practiceText = null;
            }
        }

        Notify(nameof(PageTitle), nameof(RenameText), nameof(DeleteText), nameof(SectionText), nameof(FeelingLabel), nameof(TensionLabel),
            nameof(PracticeLabel), nameof(StepLabel), nameof(OnPhoneText), nameof(AboutCompanionText), nameof(LoadingText), nameof(LoadFailedText), nameof(RetryText));
        NotifyAll();
    }
}
