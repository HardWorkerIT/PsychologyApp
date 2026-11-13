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

    public bool IsEligible
    {
        get => (bool)GetValue(IsEligibleProperty);
        set => SetValue(IsEligibleProperty, value);
    }

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
            if (AdvertisingConfiguration.CanRequestAds(UserPreferences.Load())) VirtualView.HeightRequest = platformView.MeasureContentHeightDp();
            else platformView.Stop();
        }));
        _failed = new Java.Lang.Runnable(() => MainThread.BeginInvokeOnMainThread(() => { if (_connected) VirtualView.HeightRequest = 0; }));
        platformView.SetCallbacks(_loaded, _failed);
        UserPreferences.Changed += OnPreferencesChanged;
        Refresh();
    }

    protected override void DisconnectHandler(VkBannerHost platformView)
    {
        UserPreferences.Changed -= OnPreferencesChanged;
        _connected = false;
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
            return;
        }
        const int slotId = AdvertisingConfiguration.VkReadingCatalogBannerSlotId;
        bool dark = Microsoft.Maui.Controls.Application.Current?.RequestedTheme == AppTheme.Dark;
        PlatformView.Start(slotId, AppStrings.AdsTitle, dark);
    }
}
#endif
