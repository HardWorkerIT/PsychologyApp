using PsychologyApp.Presentation.Entities.Audio;
using PsychologyApp.Presentation.Features.PlayMusic;

namespace PsychologyApp.Presentation.Pages.PlayMusic.MusicPlayer;

public partial class MusicPlayerViewModel
{
    private CancellationTokenSource? _pendingPlayback;
    private bool _playbackFailed;

    public bool PlaybackFailed
    {
        get => _playbackFailed;
        private set => SetProperty(ref _playbackFailed, value);
    }

    public void UpdatePlaybackProgressFromService() =>
        ApplyProgress(_playbackPresenter.CreateProgress(_playbackService.Position, _playbackService.Duration));

    public async Task SeekToFractionAsync(double fraction)
    {
        TimeSpan position = await _playbackPresenter.SeekToFractionAsync(_playbackService, fraction);
        ApplyProgress(_playbackPresenter.CreateProgress(position, _playbackService.Duration));
    }

    private async Task PlayTrackAsync(Audio item)
    {
        _pendingPlayback?.Cancel();
        using CancellationTokenSource playback = new();
        _pendingPlayback = playback;
        ActiveTrack = item;
        PlaybackFailed = false;
        IsBuffering = true;

        try
        {
            bool started = await _playbackPresenter.PlayTrackAsync(_playbackService, item, playback.Token);
            if (ReferenceEquals(_pendingPlayback, playback))
            {
                SetPlaybackState(started);
                PlaybackFailed = !started && !playback.IsCancellationRequested;
                if (started)
                {
                    RefreshCacheFlags();
                }
            }
        }
        finally
        {
            if (ReferenceEquals(_pendingPlayback, playback))
            {
                _pendingPlayback = null;
                IsBuffering = false;
            }
        }
    }

    private async Task PlayNextAsync()
    {
        Audio? next = _playbackPresenter.ResolveAdjacentTrack(ActiveTrack, FilteredItems, AllItems, step: 1);
        if (next is not null)
        {
            await PlayTrackAsync(next);
        }
    }

    private async Task PlayPreviousAsync()
    {
        Audio? previous = _playbackPresenter.ResolveAdjacentTrack(ActiveTrack, FilteredItems, AllItems, step: -1);
        if (previous is not null)
        {
            await PlayTrackAsync(previous);
        }
    }

    public void SetPlaybackState(bool isPlaying) => IsPlaying = isPlaying;

    internal void OnPageLeaving()
    {
        CancellationTokenSource? playback = _pendingPlayback;
        _pendingPlayback = null;
        playback?.Cancel();
        IsBuffering = false;
        PlaybackFailed = false;
        SetPlaybackState(false);
    }

    public void SyncActiveTrackFlags() =>
        MusicPlaybackPresenter.SyncActiveTrackFlags(AllItems, ActiveTrack, IsPlaying);

    private void ApplyProgress(MusicPlaybackProgress progress)
    {
        PositionDisplay = progress.PositionDisplay;
        DurationDisplay = progress.DurationDisplay;
        ProgressFraction = progress.ProgressFraction;
        OnPropertyChanged(nameof(ProgressDisplay));
    }
}
