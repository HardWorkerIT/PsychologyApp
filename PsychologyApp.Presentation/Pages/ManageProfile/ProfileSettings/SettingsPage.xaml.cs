using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Extensions;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.UI.Components;
using PsychologyApp.Presentation.Shared.UI.Overlays;
using PsychologyApp.Presentation.Features.ManageProfile.DependencyInjection;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsPage : ContentPage
{
#if ANDROID
    private bool _watchingReward;
    private bool _rewardPanelVisible;
    private IDispatcherTimer? _rewardExpiry;
#endif

    public SettingsPage(
        IPageViewModelActivator pageViewModelActivator,
        ISettingsViewModelFactory settingsViewModelFactory)
    {
        InitializeComponent();
        this.ActivateViewModel(pageViewModelActivator, page => settingsViewModelFactory.Create(page));
#if ANDROID
        RewardButton.TapCommand = new AsyncCommand(WatchRewardAsync);
#endif
    }

#if ANDROID
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _rewardPanelVisible = true;
        RewardDescription.Text = AppStrings.AdsRewardDescription(AdvertisingConfiguration.AdsRewardMinutes);
        RewardButton.BodyText = AppStrings.AdsRewardWatch;
        UpdateRewardPanel();
    }

    protected override void OnDisappearing()
    {
        _rewardPanelVisible = false;
        _rewardExpiry?.Stop();
        VkRewardedAds.CancelPending();
        base.OnDisappearing();
    }

    private async Task WatchRewardAsync()
    {
        if (BindingContext is SettingsViewModel { AdsDisabled: true }
            || !AdvertisingConfiguration.CanRequestAds(UserPreferences.Load(),
            AdvertisingConfiguration.PrivacyPolicyUrl, AdvertisingConfiguration.VkRewardedSlotId))
        {
            UpdateRewardPanel();
            return;
        }

        _watchingReward = true;
        RewardButton.IsEnabled = false;
        SetRewardStatus(AppStrings.AdsRewardLoading);
        try
        {
            VkRewardedResult result = await VkRewardedAds.WatchAsync();
            UpdateRewardPanel(result switch
            {
                VkRewardedResult.ClosedEarly => AppStrings.AdsRewardClosedEarly,
                VkRewardedResult.Unavailable => AppStrings.AdsRewardUnavailable,
                _ => null
            });
        }
        finally
        {
            _watchingReward = false;
            UpdateRewardButton();
        }
    }

    private void UpdateRewardPanel(string? status = null)
    {
        UserPreferencesState preferences = UserPreferences.Load();
        RewardPanel.IsVisible = AdvertisingConfiguration.IsPrivacyPolicyConfigured
            && AdvertisingConfiguration.VkRewardedSlotId > 0 && !preferences.AdsDisabled
            && BindingContext is not SettingsViewModel { AdsDisabled: true };
        bool active = AdvertisingConfiguration.HasActiveReward(preferences);
        UpdateRewardButton();
        if (!_watchingReward || status is not null || active)
        {
            SetRewardStatus(active ? AppStrings.AdsRewardActive : status);
        }

        _rewardExpiry?.Stop();
        if (_rewardPanelVisible && RewardPanel.IsVisible && active)
        {
            if (_rewardExpiry is null)
            {
                _rewardExpiry = Dispatcher.CreateTimer();
                _rewardExpiry.IsRepeating = false;
                _rewardExpiry.Tick += (_, _) => UpdateRewardPanel();
            }

            _rewardExpiry.Interval = TimeSpan.FromTicks(Math.Max(TimeSpan.TicksPerMillisecond,
                preferences.AdsRewardUntilUtcTicks - DateTime.UtcNow.Ticks));
            _rewardExpiry.Start();
        }
    }

    private void UpdateRewardButton() =>
        RewardButton.IsEnabled = !_watchingReward && !AdvertisingConfiguration.HasActiveReward(UserPreferences.Load());

    private void SetRewardStatus(string? status)
    {
        RewardStatus.Text = status ?? string.Empty;
        RewardStatus.IsVisible = !string.IsNullOrEmpty(status);
    }
#endif

    private void OnSettingSelectionRequested(object? sender, EventArgs e) =>
        SafeAsync.Run(() => PickSettingAsync(sender));

    private void OnAdsDisclosureTapped(object? sender, TappedEventArgs e) =>
        SafeAsync.Run(ShowAdsDisclosureAsync);

    private async Task ShowAdsDisclosureAsync()
    {
        var popup = new AdsDisclosurePopup();
        await this.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
    }

    private async Task PickSettingAsync(object? sender)
    {
        if (sender is not SettingPickerRowView row)
        {
            return;
        }

        IReadOnlyList<string> options = row.GetOptionLabels();
        if (options.Count == 0)
        {
            return;
        }

        var popup = new AppOptionsSheetPopup(
            row.PickerTitle,
            options,
            AppStrings.Cancel);
        await this.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
        string? selected = popup.SelectedValue;
        if (selected is not null)
        {
            row.SelectOption(selected);
        }
    }
}
