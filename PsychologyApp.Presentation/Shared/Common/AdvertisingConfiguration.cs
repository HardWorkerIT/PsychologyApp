namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>Advertising is available when its public disclosure and VK banner slot are configured.</summary>
internal static class AdvertisingConfiguration
{
    // VK assigns a numeric slot ID to each registered banner block.
    internal const int VkReadingCatalogBannerSlotId = 2107995;

    // A secure public policy is required before the SDK can send a request.
    internal const string PrivacyPolicyUrl = "https://hardworkerit.github.io/PsychologyApp/privacy-policy/";

    internal static bool IsPrivacyPolicyConfigured => IsValidPolicyUrl(PrivacyPolicyUrl);
    internal static bool IsVkBannerConfigured => VkReadingCatalogBannerSlotId > 0;
    internal static bool CanOfferAds => IsPrivacyPolicyConfigured && IsVkBannerConfigured;

    internal static bool CanRequestAds(UserPreferencesState preferences) =>
        CanRequestAds(preferences, PrivacyPolicyUrl, VkReadingCatalogBannerSlotId);

    internal static bool CanRequestAds(UserPreferencesState preferences, string? policyUrl, int slotId) =>
        IsValidPolicyUrl(policyUrl) && slotId > 0 && !preferences.AdsDisabled;

    private static bool IsValidPolicyUrl(string? url) =>
        Uri.TryCreate(url, UriKind.Absolute, out Uri? policyUri) && policyUri.Scheme == Uri.UriSchemeHttps;
}
