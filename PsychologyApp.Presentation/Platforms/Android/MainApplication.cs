using Android.App;
using Android.Runtime;
using App.Psychology.Ads;
using PsychologyApp.Presentation.App;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    public override void OnCreate()
    {
        UserPreferences.Changed += ApplyAdvertisingConsent;
        base.OnCreate();
    }

    private static void ApplyAdvertisingConsent()
    {
        UserPreferencesState preferences = UserPreferences.Load();
        VkNativeHost.UpdatePersonalizedAdsConsent(preferences.PersonalizedAdsConsent
            && !preferences.AdsDisabled && !AdvertisingConfiguration.HasActiveReward(preferences));
        Platforms.Android.VkInterstitialAds.UpdatePreferences(preferences);
        Platforms.Android.VkRewardedAds.UpdatePreferences(preferences);
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
