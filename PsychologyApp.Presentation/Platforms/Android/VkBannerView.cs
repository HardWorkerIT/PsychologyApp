#if ANDROID
using Android.Content;
using App.Psychology.Ads;
using Microsoft.Maui.Handlers;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Platforms.Android;

public sealed class VkBannerView : View
{
    public static readonly BindableProperty IsEligibleProperty = BindableProperty.Create(
        nameof(IsEligible), typeof(bool), typeof(VkBannerView), false);

    private static readonly BindablePropertyKey IsAdLoadedPropertyKey = BindableProperty.CreateReadOnly(
        nameof(IsAdLoaded), typeof(bool), typeof(VkBannerView), false);

    public static readonly BindableProperty IsAdLoadedProperty = IsAdLoadedPropertyKey.BindableProperty;

    public bool IsEligible
    {
        get => (bool)GetValue(IsEligibleProperty);
        set => SetValue(IsEligibleProperty, value);
    }

    public bool IsAdLoaded => (bool)GetValue(IsAdLoadedProperty);

    internal void SetAdLoaded(bool isLoaded) => SetValue(IsAdLoadedPropertyKey, isLoaded);

    public VkBannerView() => HeightRequest = 0;
}

public sealed class VkBannerHandler : ViewHandler<VkBannerView, VkBannerHost>
{
    public static readonly IPropertyMapper<VkBannerView, VkBannerHandler> Mapper =
        new PropertyMapper<VkBannerView, VkBannerHandler>(ViewMapper)
        {
            [nameof(VkBannerView.IsEligible)] = MapEligibility
        };
    private Java.Lang.IRunnable? _loaded;
    private Java.Lang.IRunnable? _failed;
    private bool _connected;

    public VkBannerHandler() : base(Mapper) { }

    private static void MapEligibility(VkBannerHandler handler, VkBannerView view) => handler.Refresh();

    protected override VkBannerHost CreatePlatformView() => new(Context);

    protected override void ConnectHandler(VkBannerHost platformView)
    {
        base.ConnectHandler(platformView);
        _connected = true;
        _loaded = new Java.Lang.Runnable(() => MainThread.BeginInvokeOnMainThread(() =>
        {
            if (!_connected) return;
            if (AdvertisingConfiguration.CanRequestAds(UserPreferences.Load()))
            {
                VirtualView.HeightRequest = platformView.MeasureContentHeightDp();
                VirtualView.SetAdLoaded(true);
            }
            else
            {
                platformView.Stop();
                VirtualView.HeightRequest = 0;
                VirtualView.SetAdLoaded(false);
            }
        }));
        _failed = new Java.Lang.Runnable(() => MainThread.BeginInvokeOnMainThread(() =>
        {
            if (!_connected) return;
            VirtualView.HeightRequest = 0;
            VirtualView.SetAdLoaded(false);
        }));
        platformView.SetCallbacks(_loaded, _failed);
        UserPreferences.Changed += OnPreferencesChanged;
        Refresh();
    }

    protected override void DisconnectHandler(VkBannerHost platformView)
    {
        UserPreferences.Changed -= OnPreferencesChanged;
        _connected = false;
        VirtualView.SetAdLoaded(false);
        platformView.Stop();
        platformView.SetCallbacks(null, null);
        base.DisconnectHandler(platformView);
    }

    private void OnPreferencesChanged() => MainThread.BeginInvokeOnMainThread(() =>
    {
        if (_connected) Refresh();
    });

    private void Refresh()
    {
        if (!_connected) return;

        if (!VirtualView.IsEligible || !AdvertisingConfiguration.CanRequestAds(UserPreferences.Load()))
        {
            PlatformView.Stop();
            VirtualView.HeightRequest = 0;
            VirtualView.SetAdLoaded(false);
            return;
        }
        const int slotId = AdvertisingConfiguration.VkReadingCatalogBannerSlotId;
        bool dark = Microsoft.Maui.Controls.Application.Current?.RequestedTheme == AppTheme.Dark;
        PlatformView.Start(slotId, AppStrings.AdsTitle, dark);
    }
}
#endif
