using App.Psychology.Ads;
using Microsoft.Maui.Handlers;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Platforms.Android;

internal sealed class VkNativeView : View
{
    internal static readonly BindableProperty IsEligibleProperty = BindableProperty.Create(
        nameof(IsEligible), typeof(bool), typeof(VkNativeView), false);

    private static readonly BindablePropertyKey IsAdLoadedPropertyKey = BindableProperty.CreateReadOnly(
        nameof(IsAdLoaded), typeof(bool), typeof(VkNativeView), false);

    public bool IsEligible => (bool)GetValue(IsEligibleProperty);
    public bool IsAdLoaded => (bool)GetValue(IsAdLoadedPropertyKey.BindableProperty);

    public VkNativeView() => HeightRequest = 0;

    internal void SetAdHeight(int height)
    {
        HeightRequest = height;
        SetValue(IsAdLoadedPropertyKey, height > 0);
    }
}

internal sealed class VkNativeHandler : ViewHandler<VkNativeView, VkNativeHost>
{
    // NATIVE_AD in the SDK demo, used only by the isolated developer package.
    private const int DemoSlotId = 6590;
    private static readonly IPropertyMapper<VkNativeView, VkNativeHandler> Mapper =
        new PropertyMapper<VkNativeView, VkNativeHandler>(ViewMapper)
        {
            [nameof(VkNativeView.IsEligible)] = static (handler, _) => handler.Refresh()
        };

    private Java.Lang.Runnable? _changed;

    public VkNativeHandler() : base(Mapper) { }

    protected override VkNativeHost CreatePlatformView() => new(Context);

    protected override void ConnectHandler(VkNativeHost platformView)
    {
        base.ConnectHandler(platformView);
        _changed = new Java.Lang.Runnable(() => MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_changed is null)
            {
                return;
            }

            if (!CanDisplay(UserPreferences.Load()))
            {
                platformView.Stop();
            }

            VirtualView.SetAdHeight(platformView.MeasureContentHeightDp());
        }));
        platformView.SetChanged(_changed);
        UserPreferences.Changed += OnPreferencesChanged;
        Refresh();
    }

    protected override void DisconnectHandler(VkNativeHost platformView)
    {
        UserPreferences.Changed -= OnPreferencesChanged;
        platformView.SetChanged(null);
        platformView.Stop();
        _changed?.Dispose();
        _changed = null;
        VirtualView.SetAdHeight(0);
        base.DisconnectHandler(platformView);
    }

    private void OnPreferencesChanged() => MainThread.BeginInvokeOnMainThread(Refresh);

    private bool CanDisplay(UserPreferencesState preferences) =>
        VirtualView.IsEligible && AdvertisingConfiguration.CanRequestNativeAd(preferences);

    private void Refresh()
    {
        if (_changed is null)
        {
            return;
        }

        UserPreferencesState preferences = UserPreferences.Load();
        if (!CanDisplay(preferences))
        {
            PlatformView.Stop();
            VirtualView.SetAdHeight(0);
            return;
        }

        int slotId = Context.PackageName?.EndsWith(".dev", StringComparison.Ordinal) == true
            ? DemoSlotId : AdvertisingConfiguration.VkCatalogNativeSlotId;
        bool dark = Microsoft.Maui.Controls.Application.Current?.RequestedTheme == AppTheme.Dark;
        PlatformView.Start(slotId, AppStrings.AdsTitle, dark, preferences.PersonalizedAdsConsent);
        VirtualView.SetAdHeight(PlatformView.MeasureContentHeightDp());
    }
}
