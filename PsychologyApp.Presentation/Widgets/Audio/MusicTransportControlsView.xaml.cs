using System.Windows.Input;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Widgets.Audio;

public partial class MusicTransportControlsView : ContentView
{
    public MusicTransportControlsView()
    {
        InitializeComponent();
        LocalizedContentView.SubscribePreferences(this, ApplyLocalization);
        ApplyLocalization();
    }

    private void ApplyLocalization()
    {
        SemanticProperties.SetDescription(PreviousTrackButton, AppStrings.MusicPreviousTrack);
        SemanticProperties.SetDescription(NextTrackButton, AppStrings.MusicNextTrack);
        UpdatePlaybackDescription();
    }

    private void UpdatePlaybackDescription()
    {
        if (PlayPauseButton is not null)
        {
            SemanticProperties.SetDescription(
                PlayPauseButton,
                IsPlaying ? AppStrings.MusicPause : AppStrings.MusicPlay);
        }
    }

    private static void OnIsPlayingChanged(BindableObject bindable, object oldValue, object newValue) =>
        ((MusicTransportControlsView)bindable).UpdatePlaybackDescription();

    public static readonly BindableProperty PlayPreviousCommandProperty =
        BindableProperty.Create(nameof(PlayPreviousCommand), typeof(ICommand), typeof(MusicTransportControlsView));

    public static readonly BindableProperty TogglePlayPauseCommandProperty =
        BindableProperty.Create(nameof(TogglePlayPauseCommand), typeof(ICommand), typeof(MusicTransportControlsView));

    public static readonly BindableProperty PlayNextCommandProperty =
        BindableProperty.Create(nameof(PlayNextCommand), typeof(ICommand), typeof(MusicTransportControlsView));

    public static readonly BindableProperty IsPlayingProperty =
        BindableProperty.Create(
            nameof(IsPlaying),
            typeof(bool),
            typeof(MusicTransportControlsView),
            false,
            propertyChanged: OnIsPlayingChanged);

    public ICommand? PlayPreviousCommand
    {
        get => (ICommand?)GetValue(PlayPreviousCommandProperty);
        set => SetValue(PlayPreviousCommandProperty, value);
    }

    public ICommand? TogglePlayPauseCommand
    {
        get => (ICommand?)GetValue(TogglePlayPauseCommandProperty);
        set => SetValue(TogglePlayPauseCommandProperty, value);
    }

    public ICommand? PlayNextCommand
    {
        get => (ICommand?)GetValue(PlayNextCommandProperty);
        set => SetValue(PlayNextCommandProperty, value);
    }

    public bool IsPlaying
    {
        get => (bool)GetValue(IsPlayingProperty);
        set => SetValue(IsPlayingProperty, value);
    }
}
