using App.Psychology.Ads;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Platforms.Android;

internal static class VkInterstitialAds
{
    // INTERSTITIAL_IMAGE in the SDK's official demo. The developer package is not the registered publisher app.
    private const int DemoImageSlotId = 6481;

    internal static void Preload(UserPreferencesState preferences)
    {
        if (!CanRequest(preferences))
        {
            VkInterstitialHost.DiscardPending();
            return;
        }

        var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
        if (activity is null || activity.IsFinishing || activity.IsDestroyed)
        {
            return;
        }

        int slotId = activity.PackageName?.EndsWith(".dev", StringComparison.Ordinal) == true
            ? DemoImageSlotId
            : AdvertisingConfiguration.VkArticleInterstitialSlotId;
        VkInterstitialHost.Preload(activity, slotId, preferences.PersonalizedAdsConsent);
    }

    internal static void ShowIfReady(UserPreferencesState preferences)
    {
        if (CanRequest(preferences) && Microsoft.Maui.ApplicationModel.Platform.CurrentActivity is { } activity)
        {
            VkInterstitialHost.ShowIfReady(activity, preferences.PersonalizedAdsConsent);
        }
        else
        {
            VkInterstitialHost.DiscardPending();
        }
    }

    internal static void UpdatePreferences(UserPreferencesState preferences) =>
        MainThread.BeginInvokeOnMainThread(() =>
            VkInterstitialHost.UpdateEligibility(CanRequest(preferences), preferences.PersonalizedAdsConsent));

    internal static void DiscardPending() => VkInterstitialHost.DiscardPending();

    private static bool CanRequest(UserPreferencesState preferences) =>
        AdvertisingConfiguration.CanRequestAds(
            preferences, AdvertisingConfiguration.PrivacyPolicyUrl, AdvertisingConfiguration.VkArticleInterstitialSlotId);
}
