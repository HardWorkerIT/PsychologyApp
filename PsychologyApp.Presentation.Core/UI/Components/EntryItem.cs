using System.ComponentModel;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Presentation.UI.Components;

public class EntryItem : INotifyPropertyChanged
{
    private static readonly PropertyChangedEventArgs TitleChanged = new(nameof(Title));
    private static readonly PropertyChangedEventArgs PlaceholderChanged = new(nameof(Placeholder));
    private static readonly PropertyChangedEventArgs TextChanged = new(nameof(Text));
    private static readonly PropertyChangedEventArgs KindChanged = new(nameof(Kind));
    private static readonly PropertyChangedEventArgs RecentTextChanged = new(nameof(RecentText));
    private static readonly PropertyChangedEventArgs AssistSuggestionsChanged = new(nameof(AssistSuggestions));

    private string _title = string.Empty;
    private string _placeholder = string.Empty;
    private string _text = string.Empty;
    private EntryFieldKind _kind = EntryFieldKind.Text;
    private string _recentText = string.Empty;
    private IReadOnlyList<string> _assistSuggestions = [];

    public string Title
    {
        get => _title;
        set => SetField(ref _title, value, TitleChanged);
    }

    public string Placeholder
    {
        get => _placeholder;
        set => SetField(ref _placeholder, value, PlaceholderChanged);
    }

    public string Text
    {
        get => _text;
        set => SetField(ref _text, value, TextChanged);
    }

    public EntryFieldKind Kind
    {
        get => _kind;
        set => SetField(ref _kind, value, KindChanged);
    }

    /// <summary>Typical short answers offered as chips under the field.</summary>
    public IReadOnlyList<string> Suggestions { get; init; } = [];

    /// <summary>What the field is about: decides which extra help the field shows.</summary>
    public EntryFieldRole Role { get; init; }

    /// <summary>The problem the person worked on last time, offered as a one-tap chip while this field is empty.</summary>
    public string RecentText
    {
        get => _recentText;
        set => SetField(ref _recentText, value, RecentTextChanged);
    }

    /// <summary>Ready phrases picked for what the person wrote earlier in the same practice (balanced thoughts, kind words).</summary>
    public IReadOnlyList<string> AssistSuggestions
    {
        get => _assistSuggestions;
        set
        {
            if (ReferenceEquals(_assistSuggestions, value))
            {
                return;
            }

            _assistSuggestions = value;
            PropertyChanged?.Invoke(this, AssistSuggestionsChanged);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void SetField<T>(ref T field, T value, PropertyChangedEventArgs args)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return;
        }

        field = value;
        PropertyChanged?.Invoke(this, args);
    }

    public EntryItem CloneEmpty() => new()
    {
        Title = Title,
        Placeholder = Placeholder,
        Kind = Kind,
        Suggestions = Suggestions,
        Role = Role,
        Text = string.Empty
    };
}
