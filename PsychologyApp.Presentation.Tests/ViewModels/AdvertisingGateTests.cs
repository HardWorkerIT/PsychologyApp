using PsychologyApp.Presentation.Shared.Common;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

public sealed class AdvertisingGateTests
{
    [Fact]
    public void AdvertisingIsConfiguredButRemainsOptIn()
    {
        Assert.True(AdvertisingConfiguration.IsPrivacyPolicyConfigured);
        Assert.True(AdvertisingConfiguration.IsVkBannerConfigured);
        Assert.True(AdvertisingConfiguration.CanOfferAds);
        Assert.False(AdvertisingConfiguration.CanRequestAds(new UserPreferencesState()));
        Assert.True(AdvertisingConfiguration.CanRequestAds(new UserPreferencesState { AdsConsentGranted = true }));
        Assert.False(AdvertisingConfiguration.CanRequestAds(new UserPreferencesState { AdsConsentGranted = true, AdsDisabled = true }));
    }

    [Theory]
    [InlineData(null, 123, true, false, false)]
    [InlineData("", 123, true, false, false)]
    [InlineData("http://example.com/privacy", 123, true, false, false)]
    [InlineData("https://example.com/privacy", 0, true, false, false)]
    [InlineData("https://example.com/privacy", 123, false, false, false)]
    [InlineData("https://example.com/privacy", 123, true, true, false)]
    [InlineData("https://example.com/privacy", 123, true, false, true)]
    public void AdvertisingRequiresPolicyConsentSlotAndNoAdFreeCode(string? policy, int slotId, bool consent, bool disabled, bool allowed)
    {
        var preferences = new UserPreferencesState { AdsConsentGranted = consent, AdsDisabled = disabled };
        Assert.Equal(allowed, AdvertisingConfiguration.CanRequestAds(preferences, policy, slotId));
    }
}
