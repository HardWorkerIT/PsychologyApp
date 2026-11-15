using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Devices;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Services.Dialogs;

namespace PsychologyApp.Presentation.Shared.UI.Overlays;

public partial class AppOptionsSheetPopup : Popup
{
    public AppOptionsSheetPopup(string title, IReadOnlyList<string> options, string cancelLabel)
        : this(title, options.Select(option => new DialogOptionItem(option, option)).ToArray(), cancelLabel)
    {
    }

    public AppOptionsSheetPopup(string title, IReadOnlyList<DialogOptionItem> options, string cancelLabel)
    {
        InitializeComponent();
        TitleLabel.Text = title;
        CancelLabel.Text = cancelLabel;

        for (int index = 0; index < options.Count; index++)
        {
            if (index > 0 && HasSupportingText(options[index]))
            {
                OptionsStack.Add(new BoxView
                {
                    Style = (Style)Microsoft.Maui.Controls.Application.Current!.Resources["AppDialogDividerStyle"],
                    Margin = new Thickness(12, 2)
                });
            }

            AddOptionRow(options[index]);
        }

        Loaded += OnLoaded;
    }

    public string? SelectedValue { get; private set; }

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
            MinimumHeightRequest = hasSupportingText ? 68 : 48,
            Padding = hasSupportingText ? new Thickness(12, 8) : new Thickness(0, 4),
        };

        if (!hasSupportingText)
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

        SemanticProperties.SetDescription(row, string.Join(". ", new[] { option.Title, option.Description, option.Detail }
            .Where(value => !string.IsNullOrWhiteSpace(value))));
        string captured = option.Value;
        var tap = new TapGestureRecognizer();
        tap.Tapped += (_, _) => SelectOption(captured);
        row.GestureRecognizers.Add(tap);
        OptionsStack.Add(row);
    }

    private static bool HasSupportingText(DialogOptionItem option) =>
        !string.IsNullOrWhiteSpace(option.Description) || !string.IsNullOrWhiteSpace(option.Detail);

    private void SelectOption(string value)
    {
        SelectedValue = value;
        SafeAsync.Run(async () => await CloseAsync());
    }

    private void OnCancelTapped(object? sender, TappedEventArgs e) => SafeAsync.Run(async () => await CloseAsync());

    private void OnDismissTapped(object? sender, TappedEventArgs e) => SafeAsync.Run(async () => await CloseAsync());
}
