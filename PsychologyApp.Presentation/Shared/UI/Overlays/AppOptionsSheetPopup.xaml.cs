using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Devices;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Services.Dialogs;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class AppOptionsSheetPopup : Popup
{
    private readonly HashSet<string> _selectedValues = new(StringComparer.Ordinal);
    // Preserve the saved order while the user edits the selection.
    private readonly List<string> _selectionOrder = [];
    private readonly Dictionary<string, CheckBox> _selectionCheckboxes = new(StringComparer.Ordinal);
    private bool _isMultiSelect;
    private bool _isRestoringCheckbox;
    private bool _isClosing;
    private int _maximumSelectionCount;
    private string _selectionHint = string.Empty;
    private string _selectedItemHint = string.Empty;
    private string _selectionLimitMessage = string.Empty;
    private Func<int, string> _selectionSummaryFactory = _ => string.Empty;

    public AppOptionsSheetPopup(string title, IReadOnlyList<string> options, string cancelLabel)
        : this(title, options.Select(option => new DialogOptionItem(option, option)).ToArray(), cancelLabel)
    {
    }

    public AppOptionsSheetPopup(string title, IReadOnlyList<DialogOptionItem> options, string cancelLabel)
    {
        InitializeComponent();
        Configure(title, options, cancelLabel);
    }

    public AppOptionsSheetPopup(
        string title,
        IReadOnlyList<DialogOptionItem> options,
        IReadOnlyCollection<string> selectedValues,
        int maximumSelectionCount,
        Func<int, string> selectionSummaryFactory,
        string selectionHint,
        string selectedItemHint,
        string selectionLimitMessage,
        string acceptLabel,
        string cancelLabel)
    {
        ArgumentNullException.ThrowIfNull(selectedValues);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(selectionSummaryFactory);
        if (maximumSelectionCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumSelectionCount));
        }

        _isMultiSelect = true;
        _maximumSelectionCount = maximumSelectionCount;
        _selectionSummaryFactory = selectionSummaryFactory;
        _selectionHint = selectionHint;
        _selectedItemHint = selectedItemHint;
        _selectionLimitMessage = selectionLimitMessage;
        HashSet<string> availableValues = options
            .Where(option => !option.IsSectionHeader)
            .Select(option => option.Value)
            .ToHashSet(StringComparer.Ordinal);
        foreach (string value in selectedValues)
        {
            if (_selectionOrder.Count >= maximumSelectionCount)
            {
                break;
            }

            if (availableValues.Contains(value) && _selectedValues.Add(value))
            {
                _selectionOrder.Add(value);
            }
        }

        InitializeComponent();
        AcceptLabel.Text = acceptLabel;
        AcceptHost.IsVisible = true;
        Grid.SetColumn(CancelHost, 1);
        Configure(title, options, cancelLabel);
    }

    private void Configure(string title, IReadOnlyList<DialogOptionItem> options, string cancelLabel)
    {
        TitleLabel.Text = title;
        CancelLabel.Text = cancelLabel;
        SemanticProperties.SetDescription(CancelHost, cancelLabel);
        SelectionSummaryLabel.IsVisible = _isMultiSelect;
        UpdateSelectionSummary();
        if (!_isMultiSelect)
        {
            Grid.SetColumn(CancelHost, 0);
            Grid.SetColumnSpan(CancelHost, 2);
        }
        else
        {
            SemanticProperties.SetDescription(AcceptHost, AcceptLabel.Text);
        }

        for (int index = 0; index < options.Count; index++)
        {
            DialogOptionItem option = options[index];
            if (option.IsSectionHeader)
            {
                OptionsStack.Add(new Label
                {
                    Text = option.Title,
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["CaptionStyle"],
                    FontFamily = (string)Microsoft.Maui.Controls.Application.Current!.Resources["SemiBoldFontFamily"],
                    Margin = new Thickness(12, index == 0 ? 8 : 14, 12, 4),
                    InputTransparent = true
                });
                continue;
            }

            if (index > 0 && !options[index - 1].IsSectionHeader && HasSupportingText(option))
            {
                OptionsStack.Add(new BoxView
                {
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogDividerStyle"],
                    Margin = new Thickness(12, 2)
                });
            }

            AddOptionRow(option);
        }

        Loaded += OnLoaded;
    }

    public string? SelectedValue { get; private set; }
    public IReadOnlyList<string>? SelectedValues { get; private set; }

    private void OnLoaded(object? sender, EventArgs e)
    {
        ApplyHostSize();
        UiAnimations.AnimateToastPopInAsync(SheetCardHost, slideOffset: 12).FireAndForget();
    }

    private void ApplyHostSize()
    {
        // Use the MAUI window (usable area), not raw display pixels — full display
        // height pushes the bottom Auto row under the system gesture/nav inset.
        if (GetUsableWindowSize() is (double width, double height))
        {
            SheetHost.WidthRequest = width;
            SheetHost.HeightRequest = height;
            OptionsScroll.MaximumHeightRequest = GetOptionsMaximumHeight(height);
            return;
        }

        DisplayInfo display = DeviceDisplay.MainDisplayInfo;
        SheetHost.WidthRequest = display.Width / display.Density;
        SheetHost.HeightRequest = display.Height / display.Density;
        OptionsScroll.MaximumHeightRequest = GetOptionsMaximumHeight(display.Height / display.Density);
    }

    private static double GetOptionsMaximumHeight(double windowHeight) =>
        Math.Max(96, Math.Min(520, windowHeight - 180));

    private static (double Width, double Height)? GetUsableWindowSize()
    {
        Window? window = Microsoft.Maui.Controls.Application.Current?.Windows.FirstOrDefault();
        if (window is null || window.Width <= 0 || window.Height <= 0)
        {
            return null;
        }

        return (window.Width, window.Height);
    }

    private void AddOptionRow(DialogOptionItem option)
    {
        bool hasSupportingText = HasSupportingText(option);
        var row = new Border
        {
            BackgroundColor = Colors.Transparent,
            Stroke = Colors.Transparent,
            MinimumHeightRequest = _isMultiSelect ? (hasSupportingText ? 68 : 56) : (hasSupportingText ? 68 : 48),
            Padding = _isMultiSelect || hasSupportingText ? new Thickness(12, 8) : new Thickness(0, 4),
        };

        if (_isMultiSelect)
        {
            var content = new Grid
            {
                ColumnDefinitions =
                [
                    new ColumnDefinition(GridLength.Star),
                    new ColumnDefinition(GridLength.Auto)
                ],
                ColumnSpacing = 12,
                VerticalOptions = LayoutOptions.Center
            };
            var labels = new VerticalStackLayout
            {
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill
            };
            labels.Add(new Label
            {
                Text = option.Title,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogPrimaryActionLabelStyle"],
                HorizontalTextAlignment = TextAlignment.Start,
                LineBreakMode = LineBreakMode.WordWrap,
                InputTransparent = true
            });
            if (!string.IsNullOrWhiteSpace(option.Description))
            {
                labels.Add(new Label
                {
                    Text = option.Description,
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["CaptionStyle"],
                    LineBreakMode = LineBreakMode.WordWrap,
                    InputTransparent = true
                });
            }

            if (!string.IsNullOrWhiteSpace(option.Detail))
            {
                labels.Add(new Label
                {
                    Text = option.Detail,
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["CaptionStyle"],
                    LineBreakMode = LineBreakMode.WordWrap,
                    InputTransparent = true
                });
            }

            content.Add(labels, 0, 0);
            bool selected = _selectedValues.Contains(option.Value);
            var checkbox = new CheckBox
            {
                IsChecked = selected,
                WidthRequest = 48,
                HeightRequest = 48,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };
            checkbox.SetDynamicResource(CheckBox.ColorProperty, "Primary");
            string description = string.Join(". ", new[] { option.Title, option.Description, option.Detail }
                .Where(value => !string.IsNullOrWhiteSpace(value)));
            SemanticProperties.SetDescription(checkbox, description);
            SemanticProperties.SetHint(checkbox, selected ? _selectedItemHint : _selectionHint);
            checkbox.CheckedChanged += (_, args) => OnOptionCheckedChanged(option.Value, args.Value);
            content.Add(checkbox, 1, 0);
            row.Content = content;
            _selectionCheckboxes[option.Value] = checkbox;

            var labelTap = new TapGestureRecognizer();
            labelTap.Tapped += (_, _) => ToggleOption(option.Value);
            labels.GestureRecognizers.Add(labelTap);
        }
        else if (!hasSupportingText)
        {
            row.Content = new Label
            {
                Text = option.Title,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogActionLabelStyle"],
                InputTransparent = true,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
            };
        }
        else
        {
            var content = new Grid
            {
                ColumnDefinitions =
                [
                    new ColumnDefinition(GridLength.Star),
                    new ColumnDefinition(GridLength.Auto)
                ],
                RowDefinitions =
                [
                    new RowDefinition(GridLength.Auto),
                    new RowDefinition(GridLength.Auto)
                ],
                ColumnSpacing = 12,
                RowSpacing = 2
            };
            content.Add(new Label
            {
                Text = option.Title,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogPrimaryActionLabelStyle"],
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.Fill,
                LineBreakMode = LineBreakMode.WordWrap,
                InputTransparent = true
            }, 0, 0);
            if (!string.IsNullOrWhiteSpace(option.Detail))
            {
                var detail = new Label
                {
                    Text = option.Detail,
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["CaptionStyle"],
                    HorizontalTextAlignment = TextAlignment.End,
                    VerticalTextAlignment = TextAlignment.Center,
                    InputTransparent = true
                };
                content.Add(detail, 1, 0);
            }

            if (!string.IsNullOrWhiteSpace(option.Description))
            {
                var description = new Label
                {
                    Text = option.Description,
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["CaptionStyle"],
                    HorizontalOptions = LayoutOptions.Fill,
                    LineBreakMode = LineBreakMode.WordWrap,
                    InputTransparent = true
                };
                Grid.SetColumnSpan(description, 2);
                content.Add(description, 0, 1);
            }

            row.Content = content;
        }

        if (!_isMultiSelect)
        {
            SemanticProperties.SetDescription(row, string.Join(". ", new[] { option.Title, option.Description, option.Detail }
                .Where(value => !string.IsNullOrWhiteSpace(value))));
            string captured = option.Value;
            var tap = new TapGestureRecognizer();
            tap.Tapped += (_, _) => SelectOption(captured);
            row.GestureRecognizers.Add(tap);
        }

        OptionsStack.Add(row);
    }

    private static bool HasSupportingText(DialogOptionItem option) =>
        !string.IsNullOrWhiteSpace(option.Description) || !string.IsNullOrWhiteSpace(option.Detail);

    private void SelectOption(string value)
    {
        if (_isClosing)
        {
            return;
        }

        SelectedValue = value;
        ClosePopup();
    }

    private void ToggleOption(string value)
    {
        if (_selectionCheckboxes.TryGetValue(value, out CheckBox? checkbox) && checkbox is not null)
        {
            checkbox.IsChecked = !checkbox.IsChecked;
        }
    }

    private void OnOptionCheckedChanged(string value, bool isChecked)
    {
        if (_isRestoringCheckbox)
        {
            return;
        }

        if (isChecked)
        {
            if (_selectedValues.Contains(value))
            {
                return;
            }

            if (_selectedValues.Count >= _maximumSelectionCount)
            {
                if (_selectionCheckboxes.TryGetValue(value, out CheckBox? checkbox) && checkbox is not null)
                {
                    try
                    {
                        _isRestoringCheckbox = true;
                        checkbox.IsChecked = false;
                    }
                    finally
                    {
                        _isRestoringCheckbox = false;
                    }
                }

                SelectionLimitLabel.Text = _selectionLimitMessage;
                SelectionLimitLabel.IsVisible = true;
                return;
            }

            _selectedValues.Add(value);
            _selectionOrder.Add(value);
        }
        else
        {
            _selectedValues.Remove(value);
            _selectionOrder.Remove(value);
        }

        UpdateOptionSelection(value, isChecked);
        SelectionLimitLabel.IsVisible = false;
    }

    private void UpdateOptionSelection(string value, bool isSelected)
    {
        if (_selectionCheckboxes.TryGetValue(value, out CheckBox? checkbox) && checkbox is not null)
        {
            SemanticProperties.SetHint(checkbox, isSelected ? _selectedItemHint : _selectionHint);
        }

        UpdateSelectionSummary();
    }

    private void UpdateSelectionSummary() =>
        SelectionSummaryLabel.Text = _selectionSummaryFactory(_selectedValues.Count);

    private void OnAcceptTapped(object? sender, TappedEventArgs e)
    {
        if (!_isMultiSelect || _isClosing)
        {
            return;
        }

        SelectedValues = _selectionOrder.ToArray();
        ClosePopup();
    }

    private void OnCancelTapped(object? sender, TappedEventArgs e) => ClosePopup();

    private void OnDismissTapped(object? sender, TappedEventArgs e) => ClosePopup();

    private void ClosePopup()
    {
        if (_isClosing)
        {
            return;
        }

        _isClosing = true;
        SafeAsync.Run(async () => await CloseAsync());
    }
}
