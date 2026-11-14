using PsychologyApp.Presentation.Shared.Common;
using Xunit;

namespace PsychologyApp.Presentation.Tests.ViewModels;

public sealed class AdvertisingGateTests
{
    [Fact]
    public void AdvertisingIsConfiguredAndEnabledWithoutAnAdFreeCode()
    {
        Assert.True(AdvertisingConfiguration.IsPrivacyPolicyConfigured);
        Assert.True(AdvertisingConfiguration.IsVkBannerConfigured);
        Assert.True(AdvertisingConfiguration.CanOfferAds);
        Assert.True(AdvertisingConfiguration.CanRequestAds(new UserPreferencesState()));
        Assert.False(AdvertisingConfiguration.CanRequestAds(new UserPreferencesState { AdsDisabled = true }));
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
