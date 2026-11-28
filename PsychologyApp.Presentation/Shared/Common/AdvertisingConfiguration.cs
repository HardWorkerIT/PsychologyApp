namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>Configuration and eligibility shared by the VK advertising formats.</summary>
internal static class AdvertisingConfiguration
{
    internal const int VkArticleInterstitialSlotId = 2124384;
    internal const int VkRewardedSlotId = 2124984;
    internal const int VkCatalogNativeSlotId = 2124987;
    internal const int VkReadingCatalogBannerSlotId = 2107995;
    internal const int AdsRewardMinutes = 30;

    // A secure public policy is required before the SDK can send a request.
    internal const string PrivacyPolicyUrl = "https://hardworkerit.github.io/PsychologyApp/privacy-policy/";

    internal static bool IsPrivacyPolicyConfigured => IsValidPolicyUrl(PrivacyPolicyUrl);
    internal static bool CanOfferAds => IsPrivacyPolicyConfigured
        && (VkCatalogNativeSlotId > 0 || VkReadingCatalogBannerSlotId > 0 || VkArticleInterstitialSlotId > 0 || VkRewardedSlotId > 0);

    internal static bool CanRequestNativeAd(UserPreferencesState preferences) =>
        CanRequestAds(preferences, PrivacyPolicyUrl, VkCatalogNativeSlotId);

    internal static bool CanRequestBannerAd(UserPreferencesState preferences) =>
        CanRequestAds(preferences, PrivacyPolicyUrl, VkReadingCatalogBannerSlotId);

    internal static bool CanRequestAds(UserPreferencesState preferences, string? policyUrl, int slotId) =>
        IsValidPolicyUrl(policyUrl) && slotId > 0 && !preferences.AdsDisabled && !HasActiveReward(preferences);

    internal static bool HasActiveReward(UserPreferencesState preferences) =>
        preferences.AdsRewardUntilUtcTicks > DateTime.UtcNow.Ticks;

    private static bool IsValidPolicyUrl(string? url) =>
        Uri.TryCreate(url, UriKind.Absolute, out Uri? policyUri) && policyUri.Scheme == Uri.UriSchemeHttps;
}
