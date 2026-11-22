using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.UI.Converters;
using System.Collections;
using System.Globalization;

namespace PsychologyApp.Presentation.Shared.UI.Components;

public partial class SettingPickerRowView : ContentView
{
    private static readonly PreferenceLabelConverter LabelConverter = new();

    public event EventHandler? SelectionRequested;

    public SettingPickerRowView()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, EventArgs e)
    {
        VisualElementPressFeedback.Attach(SettingLabel);
        VisualElementPressFeedback.Attach(SelectionTapArea);
        RefreshSelectedValue();
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        RefreshSelectedValue();
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName is nameof(ItemsSource) or nameof(LabelKind))
        {
            RefreshSelectedValue();
            return;
        }

        if (propertyName is nameof(SelectedItem) or nameof(PickerTitle) or nameof(LabelText) or nameof(IsRowEnabled))
        {
            RefreshSelectedValue();
            return;
        }

    }

    private void RefreshSelectedValue()
    {
        if (SelectionTapArea is null)
        {
            return;
        }

        string value = GetDisplayLabel(SelectedItem);
        SelectedValueLabel.Text = string.IsNullOrEmpty(value) ? PickerTitle : value;
        OnPropertyChanged(nameof(PickerAccessibilityDescription));
    }

    public string PickerAccessibilityDescription => $"{LabelText}: {SelectedValueLabel?.Text}";

    public string SelectedOptionLabel => GetDisplayLabel(SelectedItem);

    private void OnSelectionAreaTapped(object? sender, TappedEventArgs e)
    {
        if (!IsRowEnabled || ItemsSource is not { Count: > 0 })
        {
            return;
        }

        SelectionRequested?.Invoke(this, EventArgs.Empty);
    }

    public IReadOnlyList<string> GetOptionLabels()
    {
        if (ItemsSource is null)
        {
            return [];
        }

        var labels = new List<string>(ItemsSource.Count);
        foreach (object? item in ItemsSource)
        {
            labels.Add(GetDisplayLabel(item));
        }

        return labels;
    }

    public void SelectOption(string label)
    {
        if (ItemsSource is null)
        {
            return;
        }

        foreach (object? item in ItemsSource)
        {
            if (string.Equals(GetDisplayLabel(item), label, StringComparison.Ordinal))
            {
                SelectedItem = item;
                return;
            }
        }
    }

    private string GetDisplayLabel(object? value) =>
        LabelConverter.Convert(value, typeof(string), LabelKind, CultureInfo.CurrentCulture)?.ToString() ?? string.Empty;

    public static readonly BindableProperty LabelTextProperty =
        BindableProperty.Create(nameof(LabelText), typeof(string), typeof(SettingPickerRowView), string.Empty);

    public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    public static readonly BindableProperty PickerTitleProperty =
        BindableProperty.Create(nameof(PickerTitle), typeof(string), typeof(SettingPickerRowView), string.Empty);

    public string PickerTitle
    {
        get => (string)GetValue(PickerTitleProperty);
        set => SetValue(PickerTitleProperty, value);
    }

    public static readonly BindableProperty LabelKindProperty =
        BindableProperty.Create(
            nameof(LabelKind),
            typeof(PreferenceLabelKind),
            typeof(SettingPickerRowView),
            PreferenceLabelKind.PassThrough);

    public PreferenceLabelKind LabelKind
    {
        get => (PreferenceLabelKind)GetValue(LabelKindProperty);
        set => SetValue(LabelKindProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(SettingPickerRowView), null);

    public IList? ItemsSource
    {
        get => (IList?)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(SettingPickerRowView), null, BindingMode.TwoWay);

    public object? SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public static readonly BindableProperty IsRowEnabledProperty =
        BindableProperty.Create(nameof(IsRowEnabled), typeof(bool), typeof(SettingPickerRowView), true);

    public bool IsRowEnabled
    {
        get => (bool)GetValue(IsRowEnabledProperty);
        set => SetValue(IsRowEnabledProperty, value);
    }

}
