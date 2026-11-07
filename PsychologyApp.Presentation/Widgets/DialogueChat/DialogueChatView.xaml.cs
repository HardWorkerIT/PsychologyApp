using System.Collections.Specialized;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Widgets.DialogueChat;

public partial class DialogueChatView : ContentView
{
    private ChatViewModelBase? _viewModel;

    public DialogueChatView()
    {
        InitializeComponent();
        InputBar.Input.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence | KeyboardFlags.Spellcheck | KeyboardFlags.Suggestions);
        InputBar.Input.Focused += OnInputFocused;
        InputBar.Input.Unfocused += OnInputUnfocused;
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (_viewModel is not null)
        {
            _viewModel.SetComposerFocused(false);
            _viewModel.Messages.CollectionChanged -= OnMessagesChanged;
            _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }

        _viewModel = BindingContext as ChatViewModelBase;
        if (_viewModel is not null)
        {
            _viewModel.Messages.CollectionChanged += OnMessagesChanged;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
            _viewModel.SetComposerFocused(InputBar.Input.IsFocused);
        }
    }

    private void OnInputFocused(object? sender, FocusEventArgs e) => _viewModel?.SetComposerFocused(true);

    private void OnInputUnfocused(object? sender, FocusEventArgs e) => _viewModel?.SetComposerFocused(false);

    private void OnReplyOptionsTapped(object? sender, TappedEventArgs e)
    {
        UiHaptics.Tick();
        InputBar.Input.Unfocus();
    }

    /// <summary>The slider answers the 0..10 question with the same command the chips used.</summary>
    private void OnTensionChosen(object? sender, int value) =>
        _viewModel?.RatingItems.FirstOrDefault(item => item.Value == value)?.Command.Execute(value);

    /// <summary>
    /// When the answer area changes size (chips, the emotion palette, the slider), the last message would end up behind it:
    /// scroll again once the new layout is in place.
    /// </summary>
    private void OnViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ChatViewModelBase.IsTextInput) && _viewModel is { IsTextInput: false })
        {
            InputBar.Input.Unfocus();
        }

        if (e.PropertyName is nameof(ChatViewModelBase.HasSuggestions)
            or nameof(ChatViewModelBase.ShowSuggestions)
            or nameof(ChatViewModelBase.ShowEmotionPicker)
            or nameof(ChatViewModelBase.ShowReplyOptionsToggle)
            or nameof(ChatViewModelBase.OffersEmotions)
            or nameof(ChatViewModelBase.IsTextInput) or nameof(ChatViewModelBase.IsChoiceInput) or nameof(ChatViewModelBase.IsRatingInput))
        {
            Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(150), ScrollToLast);
        }
    }

    private void OnMessagesChanged(object? sender, NotifyCollectionChangedEventArgs e) => ScrollToLast();

    private void ScrollToLast()
    {
        int last = (_viewModel?.Messages.Count ?? 0) - 1;
        if (last >= 0)
        {
            MessageList.ScrollTo(last, position: ScrollToPosition.End, animate: true);
        }
    }
}
