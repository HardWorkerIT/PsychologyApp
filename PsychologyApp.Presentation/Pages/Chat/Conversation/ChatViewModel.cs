using System.Collections.ObjectModel;
using System.Windows.Input;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;

namespace PsychologyApp.Presentation.Pages.Chat.Conversation;

/// <param name="TimeText">Clock time shown inside the bubble.</param>
/// <param name="DateText">Set on the first message of a day: the divider shown above it ("Today", "21 September").</param>
/// <param name="StartsGroup">First bubble of a run from the same sender: gets more space above it, like in real messengers.</param>
public sealed record ChatBubble(string Text, bool IsUser, string TimeText, string? DateText = null, bool StartsGroup = true)
{
    public LayoutOptions Alignment => IsUser ? LayoutOptions.End : LayoutOptions.Start;

    public long? MessageId { get; init; }

    public DateTime CreatedUtc { get; init; }

    /// <summary>True for a message that has just arrived: the page slides it in once, then clears the flag. History is never animated.</summary>
    public bool Animate { get; set; }

    public bool HasDate => DateText is not null;

    public Thickness OuterMargin => new(0, StartsGroup ? 10 : 2, 0, 0);
}

/// <summary>A suggestion chip under the last companion message. Carries its own command so the template needs no ancestor binding.</summary>
public sealed record QuickReplyItem(ChatQuickReply Reply, ICommand Command)
{
    public string Label => Reply.Label;

    /// <summary>A practice offer is the main step of the message: it is drawn filled, the other chips stay outlined.</summary>
    public bool IsPractice => Reply.Kind == ChatQuickReplyKinds.Practice;
}

/// <summary>One conversation in the messenger. Every message is persisted by <see cref="IChatService"/> before it is shown, so leaving the page never loses anything.</summary>
public sealed class ChatViewModel : BaseViewModel
{
    private const int MinTypingDelayMs = 500;
    private const int MaxTypingDelayMs = 1500;
    private const int PerCharacterDelayMs = 8;
    private const int HandOverDelayMs = 500;
    private const int HistoryPageSize = 100;

    private readonly IChatService _chat;
    private readonly IChatLanguageProvider _language;
    private readonly TimeProvider _time;
    private readonly CancellationTokenSource _lifetime = new();

    private long? _sessionId;

    /// <summary>A chat opened on a topic (trauma, from its articles) starts with that topic's choices instead of a plain greeting.</summary>
    private readonly string? _topic;

    /// <summary>Words picked on the empty chat list; sent once, as the person's first message, when the new chat has loaded.</summary>
    private string? _opener;
    private Task? _loading;
    private bool _isLoading = true;
    private bool _busy;
    private string _title = string.Empty;
    private string _draftText = string.Empty;
    private bool _isTyping;
    private bool _isComposerFocused;
    private bool _hasOlderMessages;
    private bool _isLoadingOlder;
    private bool _isOlderMessagesLoadFailed;
    private bool _isInitialLoadFailed;
    private long? _oldestLoadedMessageId;
    private DateTime? _lastCreatedUtc;
    private bool? _lastWasUser;

    public ChatViewModel(
        IChatService chat,
        INavigationService navigationService,
        IChatLanguageProvider language,
        TimeProvider time,
        long? sessionId,
        string? topic = null,
        string? opener = null)
    {
        _topic = topic;
        _opener = string.IsNullOrWhiteSpace(opener) ? null : opener;
        ModuleName = AppStrings.ChatsTitle;
        PageName = AppStrings.ChatHeroTitle;
        _chat = chat;
        _language = language;
        _time = time;
        _sessionId = sessionId;
        _title = AppStrings.ChatProfileTitle;

        BindNavigation(navigationService);
        BackCommand = new AsyncCommand(GoBackAsync);
        // The header of an open chat leads to that chat's page; before the chat exists there is only the companion to show.
        OpenProfileCommand = new AsyncCommand(() => _sessionId is { } id
            ? NavigationService!.GoToChatInfoAsync(id)
            : NavigationService!.GoToCompanionProfileAsync());
        SendCommand = new Command(() => Run(SendDraftAsync));
        QuickReplyCommand = new Command<ChatQuickReply>(reply => Run(() => SendQuickReplyAsync(reply)));
        LoadOlderMessagesCommand = new AsyncCommand(RetryOlderMessagesAsync);
        RetryInitialLoadCommand = new AsyncCommand(RetryInitialLoadAsync);
    }

    public RangeObservableCollection<ChatBubble> Messages { get; } = [];

    public ObservableCollection<QuickReplyItem> QuickReplies { get; } = [];

    public ICommand BackCommand { get; }
    public ICommand OpenProfileCommand { get; }
    public ICommand SendCommand { get; }
    public ICommand QuickReplyCommand { get; }
    public ICommand LoadOlderMessagesCommand { get; }
    public ICommand RetryInitialLoadCommand { get; }

    public string Title
    {
        get => _title;
        private set
        {
            if (SetProperty(ref _title, value))
            {
                OnPropertyChanged(nameof(StatusText));
            }
        }
    }

    public string DraftText
    {
        get => _draftText;
        set
        {
            if (SetProperty(ref _draftText, value))
            {
                OnPropertyChanged(nameof(CanSend));
            }
        }
    }

    public bool IsTyping
    {
        get => _isTyping;
        private set
        {
            if (SetProperty(ref _isTyping, value))
            {
                OnPropertyChanged(nameof(StatusText));
            }
        }
    }

    public bool HasQuickReplies => QuickReplies.Count > 0;
    public bool HasOlderMessages
    {
        get => _hasOlderMessages;
        private set => SetProperty(ref _hasOlderMessages, value);
    }

    public bool IsLoadingOlderMessages
    {
        get => _isLoadingOlder;
        private set => SetProperty(ref _isLoadingOlder, value);
    }

    public bool IsOlderMessagesLoadFailed
    {
        get => _isOlderMessagesLoadFailed;
        private set => SetProperty(ref _isOlderMessagesLoadFailed, value);
    }

    public bool IsInitialLoadFailed
    {
        get => _isInitialLoadFailed;
        private set
        {
            if (SetProperty(ref _isInitialLoadFailed, value))
            {
                OnPropertyChanged(nameof(HasLoaded));
            }
        }
    }

    /// <summary>The reply is the 0..10 tension question: one slider is shown instead of eleven chips.</summary>
    public bool IsRatingMode => QuickReplies.Count >= 11 && QuickReplies.All(q => q.Reply.Kind == ChatQuickReplyKinds.Rating);

    /// <summary>The chips are shown unless the question is the tension scale.</summary>
    public bool ShowChips => HasQuickReplies && !IsRatingMode;

    /// <summary>Choices give the conversation more room while the person is typing; they return as soon as the editor closes.</summary>
    public bool ShowQuickReplies => ShowChips && !_isComposerFocused;

    public bool ShowTensionPicker => IsRatingMode && !_isComposerFocused;

    public bool ShowReplyOptionsToggle => _isComposerFocused && (ShowChips || IsRatingMode);

    public string ReplyOptionsText => AppStrings.ChatShowReplyOptions;

    internal void SetComposerFocused(bool focused)
    {
        if (_isComposerFocused == focused)
        {
            return;
        }

        _isComposerFocused = focused;
        OnPropertyChanged(nameof(ShowQuickReplies));
        OnPropertyChanged(nameof(ShowTensionPicker));
        OnPropertyChanged(nameof(ShowReplyOptionsToggle));
    }

    /// <summary>The tension the person gave last in this chat, so the slider can show "was 8 -> now 5" after a practice.</summary>
    public int? RatingReference { get; private set; }

    /// <summary>True only after the first session and history load has succeeded.</summary>
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

    public bool HasLoaded => !IsLoading && !IsInitialLoadFailed;
    public string LoadingText => AppStrings.ChatLoadingText;

    /// <summary>The send button is lit only when there is something to send.</summary>
    public bool CanSend => !string.IsNullOrWhiteSpace(_draftText);

    /// <summary>Subtitle under the chat name: "typing..." while the companion answers, otherwise a privacy reminder.</summary>
    /// <summary>Under the companion's own name the status is only "offline"; under a chat's name it says whose chat it is.</summary>
    public string StatusText => IsTyping
        ? AppStrings.DialogueTyping
        : Title == AppStrings.ChatProfileTitle ? AppStrings.ChatStatusOffline : AppStrings.ChatStatusIdle;

    /// <summary>
    /// A chat not named yet shows the companion's name: "New chat" said nothing about who is on the other side. The chat's own
    /// name takes over once its feeling is heard or the person names it.
    /// </summary>
    private static string HeaderTitle(string title) => ChatService.HasDefaultTitle(title) ? AppStrings.ChatProfileTitle : title;

    public string OpenProfileText => AppStrings.ChatProfileOpen;
    public string Placeholder => AppStrings.ChatInputPlaceholder;
    public string SendText => AppStrings.Send;
    public string TypingText => AppStrings.DialogueTyping;
    public string ScrollToNewestText => AppStrings.ChatScrollToNewest;
    public string ScrollToOldestText => AppStrings.ChatScrollToOldest;
    public string OlderMessagesLoadFailedText => AppStrings.LoadFailed;
    public string RetryOlderMessagesText => AppStrings.RetryQuestion;

    /// <summary>Loads the history (or starts a new chat) once; safe to call on every appearing, also concurrently. A failed load can be retried.</summary>
    public async Task LoadAsync()
    {
        Task load = _loading ??= LoadCoreAsync();
        try
        {
            await load;
            IsInitialLoadFailed = false;
        }
        catch
        {
            _loading = null;
            IsInitialLoadFailed = true;
            throw;
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task LoadCoreAsync()
    {
        long id = _sessionId ?? (await Task.Run(() => _topic is { } topic
            ? _chat.StartTopicChatAsync(topic, _lifetime.Token)
            : _chat.StartNewChatAsync(_lifetime.Token))).Session.Id;
        // Keep the new id even if reading its history fails, so retry does not create another empty chat.
        _sessionId = id;

        // The session and its history do not depend on each other: read both at once instead of waiting twice.
        Task<ChatSessionDTO?> sessionTask = _chat.GetChatAsync(id, _lifetime.Token);
        Task<ChatMessagePage> historyTask = LoadMessagePageAsync(id, beforeMessageId: null, _lifetime.Token);
        await Task.WhenAll(sessionTask, historyTask);

        ChatSessionDTO? session = await sessionTask;
        if (session is null)
        {
            throw new InvalidOperationException("The chat session could not be loaded.");
        }

        ChatMessagePage history = await historyTask;

        // Visible history changes only after both the session and its first page have loaded.
        Title = HeaderTitle(session.Title);
        Messages.AddRange(history.Messages.Select(m => CreateBubble(m.Text, m.Role == ChatRole.User, m.CreatedAt, animate: false, m.Id)).ToList());
        _oldestLoadedMessageId = history.Messages.FirstOrDefault()?.Id;
        HasOlderMessages = history.HasOlderMessages;

        ChatMessageDTO? last = history.Messages.LastOrDefault();
        SetQuickReplies(last is { Role: ChatRole.Companion } ? last.QuickReplies : []);
    }

    public async Task LoadOlderMessagesAsync()
    {
        if (!HasOlderMessages || IsLoadingOlderMessages || IsOlderMessagesLoadFailed
            || _sessionId is not { } sessionId || _oldestLoadedMessageId is not { } beforeMessageId)
        {
            return;
        }

        IsLoadingOlderMessages = true;
        try
        {
            ChatMessagePage page = await LoadMessagePageAsync(sessionId, beforeMessageId, _lifetime.Token);
            if (_lifetime.IsCancellationRequested || page.Messages.Count == 0)
            {
                HasOlderMessages = page.Messages.Count > 0 && page.HasOlderMessages;
                return;
            }

            // Build the older page without assuming a predecessor, then repair the one grouping boundary with the loaded page.
            DateTime? newestCreatedUtc = _lastCreatedUtc;
            bool? newestWasUser = _lastWasUser;
            _lastCreatedUtc = null;
            _lastWasUser = null;
            List<ChatBubble> older = page.Messages
                .Select(message => CreateBubble(message.Text, message.Role == ChatRole.User, message.CreatedAt, animate: false, message.Id))
                .ToList();
            _lastCreatedUtc = newestCreatedUtc;
            _lastWasUser = newestWasUser;

            ChatBubble existingOldest = Messages[0];
            ChatBubble olderLast = older[^1];
            bool newDay = !ChatTimeFormatter.SameDay(olderLast.CreatedUtc, existingOldest.CreatedUtc);
            ChatBubble correctedOldest = existingOldest with
            {
                DateText = newDay ? ChatTimeFormatter.DayLabel(existingOldest.CreatedUtc, Now(), _language.IsEnglish) : null,
                StartsGroup = newDay || olderLast.IsUser != existingOldest.IsUser
            };
            Messages.InsertRangeAndReplace(0, older, older.Count, correctedOldest);
            _oldestLoadedMessageId = page.Messages[0].Id;
            HasOlderMessages = page.HasOlderMessages;
            IsOlderMessagesLoadFailed = false;
        }
        catch (OperationCanceledException)
        {
            // The page was unloaded while the older page was being read.
        }
        catch (Exception loadError)
        {
            BestEffort.Report(loadError);
            IsOlderMessagesLoadFailed = true;
        }
        finally
        {
            IsLoadingOlderMessages = false;
        }
    }

    private async Task<ChatMessagePage> LoadMessagePageAsync(long sessionId, long? beforeMessageId, CancellationToken cancellationToken)
    {
        Task<ChatMessagePage>? paged = _chat.GetMessagesPageAsync(sessionId, beforeMessageId, HistoryPageSize, cancellationToken);
        if (paged is not null)
        {
            return await paged;
        }

        // Older test doubles and third-party hosts that have not implemented paging retain the original API behavior.
        IReadOnlyList<ChatMessageDTO> all = await _chat.GetMessagesAsync(sessionId, cancellationToken);
        IEnumerable<ChatMessageDTO> candidates = beforeMessageId is { } before
            ? all.Where(message => message.Id < before)
            : all;
        List<ChatMessageDTO> newestFirst = candidates.OrderByDescending(message => message.Id).Take(HistoryPageSize + 1).ToList();
        bool hasOlder = newestFirst.Count > HistoryPageSize;
        return new ChatMessagePage(newestFirst.Take(HistoryPageSize).Reverse().ToList(), hasOlder);
    }

    private async Task RetryOlderMessagesAsync()
    {
        if (!IsOlderMessagesLoadFailed || IsLoadingOlderMessages)
        {
            return;
        }

        IsOlderMessagesLoadFailed = false;
        await LoadOlderMessagesAsync();
    }

    private async Task RetryInitialLoadAsync()
    {
        if (!IsInitialLoadFailed || _busy || _lifetime.IsCancellationRequested)
        {
            return;
        }

        IsInitialLoadFailed = false;
        IsLoading = true;
        await OnAppearedAsync();
    }

    /// <summary>Called whenever the page appears: after a practice is finished the companion asks how the person feels.</summary>
    public async Task OnAppearedAsync()
    {
        if (_busy)
        {
            return;
        }

        _busy = true;
        try
        {
            try
            {
                await LoadAsync();
            }
            catch (Exception loadError) when (loadError is not OperationCanceledException)
            {
                BestEffort.Report(loadError);
                return;
            }

            if (_sessionId is not { } id)
            {
                return;
            }

            ChatTurnResult? followUp = await Task.Run(() => _chat.CheckPracticeFollowUpAsync(id, _lifetime.Token));
            if (followUp is not null)
            {
                Title = HeaderTitle(followUp.Session.Title);
                await RevealAsync(followUp.NewMessages);
            }

            // The same path as a typed message, so the crisis check and the engine read it as the person's own words.
            if (_opener is { } opener)
            {
                _opener = null;
                await TakeTurnAsync(opener, () => _chat.SendTextAsync(id, opener, CancellationToken.None));
            }
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            _busy = false;
        }
    }

    /// <summary>Stops pending typing delays when the page is unloaded. Nothing is lost: messages are already stored.</summary>
    public void Close() => _lifetime.Cancel();

    protected override void RefreshLocalizedProperties() =>
        Notify(nameof(Placeholder), nameof(SendText), nameof(TypingText), nameof(StatusText), nameof(OpenProfileText),
            nameof(LoadingText), nameof(ScrollToNewestText), nameof(ScrollToOldestText),
            nameof(OlderMessagesLoadFailedText), nameof(RetryOlderMessagesText));

    private void Run(Func<Task> action)
    {
        if (_busy || _sessionId is null || !HasLoaded)
        {
            return;
        }

        _busy = true;
        _ = RunGuardedAsync(action);
    }

    private async Task RunGuardedAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (OperationCanceledException)
        {
            // Page closed while the companion was "typing".
        }
        catch (Exception ex)
        {
            IsTyping = false;
            AsyncCommandExtensions.DefaultErrorHandler?.Invoke(ex);
        }
        finally
        {
            _busy = false;
        }
    }

    private Task SendDraftAsync()
    {
        string text = ChatText.Capitalize(DraftText);
        if (text.Length == 0)
        {
            return Task.CompletedTask;
        }

        DraftText = string.Empty;
        return TakeTurnAsync(text, () => _chat.SendTextAsync(_sessionId!.Value, text, CancellationToken.None));
    }

    private async Task SendQuickReplyAsync(ChatQuickReply reply)
    {
        // The value just given is what the next slider shows as "was N".
        int? picked = reply.Kind == ChatQuickReplyKinds.Rating && int.TryParse(reply.Payload, out int value) ? value : null;
        int? previousRating = RatingReference;
        IReadOnlyList<ChatQuickReply> retryReplies = QuickReplies.Select(item => item.Reply).ToList();
        RatingReference = picked ?? previousRating;
        try
        {
            await TakeTurnAsync(reply.Label, () => _chat.SendQuickReplyAsync(_sessionId!.Value, reply, CancellationToken.None), retryReplies);
        }
        catch
        {
            RatingReference = previousRating;
            throw;
        }
    }

    private async Task TakeTurnAsync(
        string userText,
        Func<Task<ChatTurnResult>> send,
        IReadOnlyList<ChatQuickReply>? retryReplies = null)
    {
        DateTime? previousCreatedUtc = _lastCreatedUtc;
        bool? previousWasUser = _lastWasUser;
        ChatBubble userBubble = CreateBubble(userText, isUser: true, Now(), animate: true);
        Messages.Add(userBubble);
        SetQuickReplies([]);
        IsTyping = true;

        // The service awaits without ConfigureAwait(false), so understanding the message would run on the UI thread.
        ChatTurnResult result;
        try
        {
            result = await Task.Run(send);
        }
        catch
        {
            if (!_lifetime.IsCancellationRequested)
            {
                Messages.Remove(userBubble);
                _lastCreatedUtc = previousCreatedUtc;
                _lastWasUser = previousWasUser;
                if (retryReplies is null)
                {
                    DraftText = userText;
                }
                else
                {
                    SetQuickReplies(retryReplies);
                }
            }

            throw;
        }

        if (_lifetime.IsCancellationRequested)
        {
            return;
        }

        Title = HeaderTitle(result.Session.Title);

        // NewMessages[0] is the user's own message, which is already on screen.
        await RevealAsync(result.NewMessages.Skip(1).ToList());
        await HandleActionAsync(result.Action);
    }

    private async Task RevealAsync(IReadOnlyList<ChatMessageDTO> companionMessages)
    {
        foreach (ChatMessageDTO message in companionMessages)
        {
            IsTyping = true;
            await Task.Delay(Math.Clamp(message.Text.Length * PerCharacterDelayMs, MinTypingDelayMs, MaxTypingDelayMs), _lifetime.Token);
            IsTyping = false;
            Messages.Add(CreateBubble(message.Text, message.Role == ChatRole.User, message.CreatedAt, animate: true, message.Id));
        }

        IsTyping = false;
        SetQuickReplies(companionMessages.LastOrDefault()?.QuickReplies ?? []);
    }

    private async Task HandleActionAsync(DialogueAction? action)
    {
        switch (action)
        {
            case { Kind: DialogueActionKind.StartTechnique, TechniqueId: { } technique }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToTechniqueAsync(technique);
                break;

            case { Kind: DialogueActionKind.OpenCrisisHub }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToCrisisHubAsync();
                break;

            case { Kind: DialogueActionKind.OpenTests }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToTestsTabAsync();
                break;

            case { Kind: DialogueActionKind.OpenSomatic }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToArticleAsync(PsychologyApp.Application.Articles.ArticleIds.BodyAndStress);
                break;

            case { Kind: DialogueActionKind.OpenTest, TestId: { } questionnaire }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToTestAsync(questionnaire);
                break;

            case { Kind: DialogueActionKind.OpenArticle, ArticleId: { } articleId }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToArticleAsync(articleId);
                break;

            case { Kind: DialogueActionKind.OpenPrayers }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToPrayersAsync();
                break;

            case { Kind: DialogueActionKind.OpenQuotes }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToQuotesAsync();
                break;

            case { Kind: DialogueActionKind.OpenTestHistory, TestId: { } testId }:
                await Task.Delay(HandOverDelayMs, _lifetime.Token);
                await NavigationService!.GoToTestHistoryAsync(testId, AppStrings.ChatStressTestTitle);
                break;
        }
    }

    private void SetQuickReplies(IReadOnlyList<ChatQuickReply> replies)
    {
        QuickReplies.Clear();
        foreach (ChatQuickReply reply in replies)
        {
            QuickReplies.Add(new QuickReplyItem(reply, QuickReplyCommand));
        }

        OnPropertyChanged(nameof(HasQuickReplies));
        OnPropertyChanged(nameof(IsRatingMode));
        OnPropertyChanged(nameof(ShowChips));
        OnPropertyChanged(nameof(ShowQuickReplies));
        OnPropertyChanged(nameof(ShowTensionPicker));
        OnPropertyChanged(nameof(ShowReplyOptionsToggle));
        OnPropertyChanged(nameof(RatingReference));
    }

    /// <summary>Builds a bubble with a day divider above the first message of a day and tighter spacing inside a run from one sender. Bubbles must be created in display order.</summary>
    private ChatBubble CreateBubble(string text, bool isUser, DateTime createdUtc, bool animate, long? messageId = null)
    {
        bool newDay = _lastCreatedUtc is not { } last || !ChatTimeFormatter.SameDay(last, createdUtc);
        ChatBubble bubble = new(
            text,
            isUser,
            ChatTimeFormatter.Clock(createdUtc),
            newDay ? ChatTimeFormatter.DayLabel(createdUtc, Now(), _language.IsEnglish) : null,
            StartsGroup: newDay || _lastWasUser != isUser)
        {
            Animate = animate,
            MessageId = messageId,
            CreatedUtc = createdUtc
        };
        _lastCreatedUtc = createdUtc;
        _lastWasUser = isUser;
        return bubble;
    }

    private DateTime Now() => _time.GetUtcNow().UtcDateTime;
}
