using PsychologyApp.Presentation.Entities.Test;
using PsychologyApp.Presentation.Pages.RunTests.LuscherTest;
using System.Collections.ObjectModel;

namespace PsychologyApp.Presentation.Widgets.Test;

public partial class LuscherStandardResultsView : ContentView
{
    public LuscherStandardResultsView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(LuscherStandardResultsView), string.Empty);

    public static readonly BindableProperty ResultItemsProperty =
        BindableProperty.Create(
            nameof(ResultItems),
            typeof(ObservableCollection<ResultItem>),
            typeof(LuscherStandardResultsView),
            null);

    public static readonly BindableProperty FirstPassTitleProperty =
        BindableProperty.Create(nameof(FirstPassTitle), typeof(string), typeof(LuscherStandardResultsView), string.Empty);

    public static readonly BindableProperty SecondPassTitleProperty =
        BindableProperty.Create(nameof(SecondPassTitle), typeof(string), typeof(LuscherStandardResultsView), string.Empty);

    public static readonly BindableProperty FirstPassColorsProperty =
        BindableProperty.Create(
            nameof(FirstPassColors),
            typeof(IReadOnlyList<LuscherColorDisplayItem>),
            typeof(LuscherStandardResultsView),
            Array.Empty<LuscherColorDisplayItem>());

    public static readonly BindableProperty SecondPassColorsProperty =
        BindableProperty.Create(
            nameof(SecondPassColors),
            typeof(IReadOnlyList<LuscherColorDisplayItem>),
            typeof(LuscherStandardResultsView),
            Array.Empty<LuscherColorDisplayItem>());

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ObservableCollection<ResultItem>? ResultItems
    {
        get => (ObservableCollection<ResultItem>?)GetValue(ResultItemsProperty);
        set => SetValue(ResultItemsProperty, value);
    }

    public string FirstPassTitle
    {
        get => (string)GetValue(FirstPassTitleProperty);
        set => SetValue(FirstPassTitleProperty, value);
    }

    public string SecondPassTitle
    {
        get => (string)GetValue(SecondPassTitleProperty);
        set => SetValue(SecondPassTitleProperty, value);
    }

    public IReadOnlyList<LuscherColorDisplayItem> FirstPassColors
    {
        get => (IReadOnlyList<LuscherColorDisplayItem>)GetValue(FirstPassColorsProperty);
        set => SetValue(FirstPassColorsProperty, value);
    }

    public IReadOnlyList<LuscherColorDisplayItem> SecondPassColors
    {
        get => (IReadOnlyList<LuscherColorDisplayItem>)GetValue(SecondPassColorsProperty);
        set => SetValue(SecondPassColorsProperty, value);
    }
}
