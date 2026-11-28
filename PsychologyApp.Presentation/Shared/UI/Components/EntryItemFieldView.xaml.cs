using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Presentation.Shared.UI.Components;

public partial class EntryItemFieldView : ContentView
{
    private EntryItem? _observedEntry;

    public EntryItemFieldView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty EntryProperty =
        BindableProperty.Create(nameof(Entry), typeof(EntryItem), typeof(EntryItemFieldView), null, propertyChanged: OnEntryChanged);

    public EntryItem? Entry
    {
        get => (EntryItem?)GetValue(EntryProperty);
        set => SetValue(EntryProperty, value);
    }

    public static readonly BindableProperty EmbeddedProperty =
        BindableProperty.Create(nameof(Embedded), typeof(bool), typeof(EntryItemFieldView), false);

    /// <summary>The field sits inside a step card: scales drop their own frame.</summary>
    public bool Embedded
    {
        get => (bool)GetValue(EmbeddedProperty);
        set => SetValue(EmbeddedProperty, value);
    }

    public bool IsTextField => Entry?.Kind == EntryFieldKind.Text;

    public bool IsRatingField => Entry?.Kind is EntryFieldKind.Rating0To10 or EntryFieldKind.RatingNeg10To10;

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        ObserveEntry(Handler is null ? null : Entry);
        if (Handler is not null)
        {
            NotifyFieldKind();
        }
    }

    private static void OnEntryChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (EntryItemFieldView)bindable;
        view.ObserveEntry(view.Handler is null ? null : newValue as EntryItem);
        view.NotifyFieldKind();
        view.RatingEntry.ForceSync();
    }

    private void ObserveEntry(EntryItem? entry)
    {
        if (ReferenceEquals(_observedEntry, entry))
        {
            return;
        }

        if (_observedEntry is not null)
        {
            _observedEntry.PropertyChanged -= OnEntryPropertyChanged;
        }

        _observedEntry = entry;
        if (entry is not null)
        {
            entry.PropertyChanged += OnEntryPropertyChanged;
        }
    }

    private void OnEntryPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(EntryItem.Kind))
        {
            NotifyFieldKind();
        }
    }

    private void NotifyFieldKind()
    {
        OnPropertyChanged(nameof(IsTextField));
        OnPropertyChanged(nameof(IsRatingField));
    }
}
