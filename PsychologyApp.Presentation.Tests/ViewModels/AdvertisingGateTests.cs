using PsychologyApp.Presentation.Shared.Common;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

public sealed class AdvertisingGateTests
{
    [Fact]
    public void AdvertisingIsConfiguredAndEnabledWithoutAnAdFreeCode()
    {
        Assert.True(AdvertisingConfiguration.IsPrivacyPolicyConfigured);
        Assert.True(AdvertisingConfiguration.CanOfferAds);
        Assert.True(AdvertisingConfiguration.CanRequestNativeAd(new UserPreferencesState()));
        Assert.False(AdvertisingConfiguration.CanRequestNativeAd(new UserPreferencesState { AdsDisabled = true }));
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void A_video_reward_blocks_ordinary_ads_until_it_expires(bool active, bool allowed)
    {
        var preferences = new UserPreferencesState
        {
            AdsRewardUntilUtcTicks = (active ? DateTime.UtcNow.AddMinutes(5) : DateTime.UtcNow.AddMinutes(-5)).Ticks
        };

        Assert.Equal(allowed, AdvertisingConfiguration.CanRequestNativeAd(preferences));
        Assert.Equal(allowed, AdvertisingConfiguration.CanRequestAds(preferences,
            AdvertisingConfiguration.PrivacyPolicyUrl, AdvertisingConfiguration.VkArticleInterstitialSlotId));
    }

    [Theory]
    [InlineData(null, 123, false, false)]
    [InlineData("", 123, false, false)]
    [InlineData("http://example.com/privacy", 123, false, false)]
    [InlineData("https://example.com/privacy", 0, false, false)]
    [InlineData("https://example.com/privacy", 123, true, false)]
    [InlineData("https://example.com/privacy", 123, false, true)]
    public void AdvertisingRequiresSecurePolicySlotAndNoAdFreeCode(string? policy, int slotId, bool disabled, bool allowed)
    {
        var preferences = new UserPreferencesState { AdsDisabled = disabled };
        Assert.Equal(allowed, AdvertisingConfiguration.CanRequestAds(preferences, policy, slotId));
    }
}
