using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Controls.Shapes;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.Services.Security;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class AppOptionsSheetPopup : Popup
{
    private readonly HashSet<string> _selectedValues = new(StringComparer.Ordinal);
    // Preserve the saved order while the user edits the selection.
    private readonly List<string> _selectionOrder = [];
    private readonly Dictionary<string, CheckBox> _selectionCheckboxes = new(StringComparer.Ordinal);
    private readonly Dictionary<string, Border> _singleSelectionRows = new(StringComparer.Ordinal);
    private bool _isSingleSelectionConfirmation;
    private bool _isMultiSelect;
    private bool _isRestoringCheckbox;
    private bool _isClosing;
    private int _maximumSelectionCount;
    private string _selectionHint = string.Empty;
    private string _selectedItemHint = string.Empty;
    private string _selectionLimitMessage = string.Empty;
    private Func<int, string> _selectionSummaryFactory = _ => string.Empty;
    private string? _pendingValue;
    private Entry? _dialogInputEntry;
    private bool _requiresPin;
    private bool _isDecisionSheet;
    private bool? _dialogResult;

    public AppOptionsSheetPopup(
        string? title,
        string message,
        string acceptLabel,
        string? cancelLabel,
        AppDialogInput? input = null,
        bool isDestructive = false)
    {
        _isDecisionSheet = true;
        InitializeComponent();
        Configure(title ?? string.Empty, Array.Empty<DialogOptionItem>(), cancelLabel ?? string.Empty);

        TitleLabel.IsVisible = !string.IsNullOrWhiteSpace(title);
        AcceptLabel.Text = acceptLabel;
        AcceptHost.IsVisible = true;
        CancelHost.IsVisible = !string.IsNullOrWhiteSpace(cancelLabel);
        SemanticProperties.SetDescription(AcceptHost, acceptLabel);
        if (isDestructive)
        {
            AcceptLabel.Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogDestructiveActionLabelStyle"];
        }

        FooterActions.ColumnDefinitions.Clear();
        FooterActions.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        if (CancelHost.IsVisible)
        {
            FooterActions.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
            Grid.SetColumn(AcceptHost, 0);
            Grid.SetColumn(CancelHost, 1);
            Grid.SetColumnSpan(AcceptHost, 1);
            Grid.SetColumnSpan(CancelHost, 1);
        }
        else
        {
            Grid.SetColumn(AcceptHost, 0);
            Grid.SetColumnSpan(AcceptHost, 1);
        }

        if (!string.IsNullOrWhiteSpace(message))
        {
            OptionsStack.Add(new Label
            {
                Text = message,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogMessageStyle"],
                Margin = new Thickness(12, 8),
                LineBreakMode = LineBreakMode.WordWrap
            });
        }

        if (input is not null)
        {
            _requiresPin = input.IsPin;
            var entry = new Entry
            {
                IsPassword = input.IsPassword,
                Placeholder = input.Placeholder,
                Text = input.InitialText,
                MaxLength = _requiresPin ? AppPinPolicy.Length : input.MaxLength,
                ReturnType = ReturnType.Done,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["InputTextStyle"]
            };
            entry.Completed += OnInputCompleted;
            _dialogInputEntry = entry;
            if (_requiresPin)
            {
                var keyboardResize = new KeyboardResize();
                Loaded += (_, _) => keyboardResize.Enable();
                Unloaded += (_, _) => keyboardResize.Restore();
                SheetHost.SafeAreaEdges = Microsoft.Maui.SafeAreaEdges.All;
                entry.Keyboard = Keyboard.Numeric;
                entry.TextChanged += OnPinChanged;
                UpdatePinAcceptState();
            }
            OptionsStack.Add(new Border
            {
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["InputBorderStyle"],
                Padding = new Thickness(10, 2),
                Margin = new Thickness(12, 8),
                Content = entry
            });
        }
    }

    public AppOptionsSheetPopup(string title, IReadOnlyList<string> options, string cancelLabel)
        : this(title, options.Select(option => new DialogOptionItem(option, option)).ToArray(), cancelLabel)
    {
    }

    public AppOptionsSheetPopup(string title, IReadOnlyList<DialogOptionItem> options, string cancelLabel)
    {
        InitializeComponent();
        Configure(title, options, cancelLabel);
    }

    public AppOptionsSheetPopup(string title, IReadOnlyList<string> options, string? selectedValue, string acceptLabel, string? cancelLabel = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        _isSingleSelectionConfirmation = true;
        _pendingValue = !string.IsNullOrEmpty(selectedValue) && options.Contains(selectedValue, StringComparer.Ordinal)
            ? selectedValue
            : null;
        InitializeComponent();
        AcceptLabel.Text = acceptLabel;
        AcceptHost.IsVisible = true;
        Configure(title, options.Select(option => new DialogOptionItem(option, option)).ToArray(), cancelLabel ?? string.Empty);
        ConfigureSingleSelectionSheet();
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
        if (_isSingleSelectionConfirmation)
        {
            CancelHost.IsVisible = !string.IsNullOrWhiteSpace(cancelLabel);
            AcceptHost.IsVisible = true;
        }
        else if (!_isMultiSelect)
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

    private void ConfigureSingleSelectionSheet()
    {
        SheetCardHost.Margin = new Thickness(16, 0, 16, 48);
        SheetCardHost.VerticalOptions = LayoutOptions.End;
        SheetCardHost.HorizontalOptions = LayoutOptions.Fill;
        SheetCard.Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppOptionsSheetPopupCardStyle"];
        TitleLabel.HorizontalTextAlignment = TextAlignment.Center;
        TitleLabel.Margin = new Thickness(8, 0);
        TitleLabel.VerticalTextAlignment = TextAlignment.Center;
        FooterActions.ColumnDefinitions.Clear();
        FooterActions.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        if (!string.IsNullOrWhiteSpace(CancelLabel.Text))
        {
            FooterActions.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        }
        AcceptHost.IsVisible = true;
        CancelHost.IsVisible = !string.IsNullOrWhiteSpace(CancelLabel.Text);
        Grid.SetColumn(AcceptHost, 0);
        Grid.SetColumnSpan(AcceptHost, 1);
        Grid.SetColumn(CancelHost, 1);
        Grid.SetColumnSpan(CancelHost, 1);
        AcceptHost.SetDynamicResource(Border.BackgroundColorProperty, "PrimaryFill");
        AcceptHost.StrokeThickness = 0;
        AcceptHost.StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(12) };
        AcceptHost.Padding = new Thickness(12, 8);
        AcceptLabel.SetDynamicResource(Label.TextColorProperty, "OnPrimary");
        AcceptLabel.FontFamily = (string)Microsoft.Maui.Controls.Application.Current!.Resources["MediumFontFamily"];
        SemanticProperties.SetDescription(AcceptHost, AcceptLabel.Text);
        if (CancelHost.IsVisible)
        {
            SemanticProperties.SetDescription(CancelHost, CancelLabel.Text);
        }
        OptionsScroll.VerticalOptions = LayoutOptions.Fill;
    }

    public string? SelectedValue { get; private set; }
    public IReadOnlyList<string>? SelectedValues { get; private set; }
    public bool CancelledWithButton { get; private set; }
    public bool? DialogResult => _dialogResult;
    public string InputText => _dialogInputEntry?.Text ?? string.Empty;

    private void OnLoaded(object? sender, EventArgs e)
    {
        ApplyHostSize();
        UiAnimations.AnimateToastPopInAsync(SheetCardHost, slideOffset: 12).FireAndForget();
        if (_dialogInputEntry is { IsPassword: false } entry)
        {
            entry.Focus();
            entry.CursorPosition = entry.Text?.Length ?? 0;
        }
    }

    private void ApplyHostSize()
    {
        // Use the MAUI window (usable area), not raw display pixels — full display
        // height pushes the bottom Auto row under the system gesture/nav inset.
        if (GetUsableWindowSize() is (double width, double height))
        {
            SheetHost.WidthRequest = width;
            if (!_requiresPin)
            {
                SheetHost.HeightRequest = height;
            }
            OptionsScroll.MaximumHeightRequest = GetOptionsMaximumHeight(height);
            return;
        }

        DisplayInfo display = DeviceDisplay.MainDisplayInfo;
        SheetHost.WidthRequest = display.Width / display.Density;
        if (!_requiresPin)
        {
            SheetHost.HeightRequest = display.Height / display.Density;
        }
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
            Padding = new Thickness(12, _isMultiSelect || hasSupportingText ? 8 : 4),
        };

        if (_isSingleSelectionConfirmation)
        {
            var content = new Grid
            {
                ColumnDefinitions =
                [
                    new ColumnDefinition(GridLength.Star),
                    new ColumnDefinition(GridLength.Auto),
                    new ColumnDefinition(GridLength.Auto)
                ],
                ColumnSpacing = 10,
                VerticalOptions = LayoutOptions.Center
            };
            content.Add(new Label
            {
                Text = option.Title,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogPrimaryActionLabelStyle"],
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.WordWrap,
                InputTransparent = true
            }, 0, 0);

            bool selected = string.Equals(_pendingValue, option.Value, StringComparison.Ordinal);
            var selectedBadgeLabel = new Label
            {
                Text = AppStrings.SettingsOptionSelected,
                Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["CaptionStyle"],
                InputTransparent = true
            };
            selectedBadgeLabel.SetAppThemeColor(Label.TextColorProperty, Color.FromArgb("#0062BD"), Color.FromArgb("#9BCFFF"));
            var selectedBadge = new Border
            {
                IsVisible = selected,
                Padding = new Thickness(8, 3),
                StrokeThickness = 0,
                StrokeShape = new RoundRectangle { CornerRadius = 10 },
                VerticalOptions = LayoutOptions.Center,
                Content = selectedBadgeLabel
            };
            selectedBadge.SetAppThemeColor(Border.BackgroundColorProperty, Color.FromArgb("#D6EBFF"), Color.FromArgb("#1A2A3D"));
            content.Add(selectedBadge, 1, 0);

            var radio = new Border
            {
                WidthRequest = 22,
                HeightRequest = 22,
                Padding = 4,
                StrokeThickness = 2,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Stroke = selected ? Color.FromArgb("#0071D9") : Color.FromArgb("#A9B0B9"),
                VerticalOptions = LayoutOptions.Center,
                Content = new Border
                {
                    IsVisible = selected,
                    StrokeThickness = 0,
                    StrokeShape = new RoundRectangle { CornerRadius = 8 },
                    BackgroundColor = Color.FromArgb("#0071D9")
                }
            };
            content.Add(radio, 2, 0);
            row.Content = content;
            row.Padding = new Thickness(12, 8);
            row.MinimumHeightRequest = 56;
            row.SetAppThemeColor(Border.BackgroundColorProperty, selected ? Color.FromArgb("#EAF4FF") : Colors.Transparent, selected ? Color.FromArgb("#1A2A3D") : Colors.Transparent);
            SemanticProperties.SetDescription(row, option.Title);
            SemanticProperties.SetHint(row, selected ? AppStrings.SettingsOptionSelected : AppStrings.SettingsOptionSelectHint);
            string captured = option.Value;
            var tap = new TapGestureRecognizer();
            tap.Tapped += (_, _) => StageSingleSelection(captured);
            row.GestureRecognizers.Add(tap);
            _singleSelectionRows[option.Value] = row;
        }
        else if (_isMultiSelect)
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
                HorizontalOptions = LayoutOptions.Fill,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                LineBreakMode = LineBreakMode.WordWrap,
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

        if (!_isMultiSelect && !_isSingleSelectionConfirmation)
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

    private void StageSingleSelection(string value)
    {
        if (_isClosing || !_isSingleSelectionConfirmation)
        {
            return;
        }

        _pendingValue = value;
        foreach ((string optionValue, Border row) in _singleSelectionRows)
        {
            bool selected = string.Equals(optionValue, value, StringComparison.Ordinal);
            row.SetAppThemeColor(Border.BackgroundColorProperty, selected ? Color.FromArgb("#EAF4FF") : Colors.Transparent, selected ? Color.FromArgb("#1A2A3D") : Colors.Transparent);
            SemanticProperties.SetHint(row, selected ? AppStrings.SettingsOptionSelected : AppStrings.SettingsOptionSelectHint);
        }

        // Rebuild the small trailing controls to keep the selected marker in sync with the row.
        RefreshSingleSelectionIndicators();
    }

    private void RefreshSingleSelectionIndicators()
    {
        foreach ((string value, Border row) in _singleSelectionRows)
        {
            bool selected = string.Equals(_pendingValue, value, StringComparison.Ordinal);
            if (row.Content is not Grid content || content.Children.Count < 3)
            {
                continue;
            }

            if (content.Children[1] is Border badge)
            {
                badge.IsVisible = selected;
            }

            if (content.Children[2] is Border radio)
            {
                radio.Stroke = selected ? Color.FromArgb("#0071D9") : Color.FromArgb("#A9B0B9");
                if (radio.Content is Border dot)
                {
                    dot.IsVisible = selected;
                }
            }
        }
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
        if (_isClosing)
        {
            return;
        }

        if (_isDecisionSheet)
        {
            TryAcceptInput();
            return;
        }

        if (_isMultiSelect)
        {
            SelectedValues = _selectionOrder.ToArray();
            ClosePopup();
            return;
        }

        if (_isSingleSelectionConfirmation)
        {
            SelectedValue = _pendingValue;
            ClosePopup();
        }
    }

    private void OnInputCompleted(object? sender, EventArgs e)
    {
        TryAcceptInput();
    }

    private void TryAcceptInput()
    {
        if (_isClosing || (_requiresPin && !AppPinPolicy.IsValid(_dialogInputEntry?.Text)))
        {
            return;
        }

        _dialogResult = true;
        ClosePopup();
    }

    private void OnPinChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && e.NewTextValue is { } text && text.Any(ch => !char.IsAsciiDigit(ch)))
        {
            entry.Text = new string(text.Where(char.IsAsciiDigit).ToArray());
        }

        UpdatePinAcceptState();
    }

    private void UpdatePinAcceptState()
    {
        bool valid = AppPinPolicy.IsValid(_dialogInputEntry?.Text);
        AcceptHost.IsEnabled = valid;
        AcceptHost.Opacity = valid ? 1 : 0.5;
    }

    private void OnCancelTapped(object? sender, TappedEventArgs e)
    {
        if (_isClosing)
        {
            return;
        }

        CancelledWithButton = true;
        if (_isDecisionSheet)
        {
            _dialogResult = false;
        }

        ClosePopup();
    }

    private void OnDismissTapped(object? sender, TappedEventArgs e)
    {
        if (_isDecisionSheet)
        {
            _dialogResult = false;
        }

        ClosePopup();
    }

    private void ClosePopup()
    {
        if (_isClosing)
        {
            return;
        }

        _isClosing = true;
        SafeAsync.Run(async () =>
        {
            try
            {
                await UiAnimations.AnimateToastPopOutAsync(SheetCardHost, slideOffset: 12);
            }
            finally
            {
                await CloseAsync();
            }
        });
    }
}
