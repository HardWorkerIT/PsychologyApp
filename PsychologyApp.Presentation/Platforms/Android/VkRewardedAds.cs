using App.Psychology.Ads;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Platforms.Android;

internal enum VkRewardedResult
{
    Unavailable,
    ClosedEarly,
    Granted
}

internal static class VkRewardedAds
{
    // REWARDED in the SDK's demo. The .dev package is separate from the registered publisher app.
    private const int DemoSlotId = 45101;

    internal static async Task<VkRewardedResult> WatchAsync()
    {
        UserPreferencesState preferences = UserPreferences.Load();
        if (!CanWatch(preferences)
            || Microsoft.Maui.ApplicationModel.Platform.CurrentActivity is not { } activity)
        {
            return VkRewardedResult.Unavailable;
        }

        VkRewardedResult result = VkRewardedResult.ClosedEarly;
        TaskCompletionSource<VkRewardedResult> completed = new(TaskCreationOptions.RunContinuationsAsynchronously);
        using var reward = new Java.Lang.Runnable(() =>
        {
            try
            {
                UserPreferences.GrantAdsReward();
                result = VkRewardedResult.Granted;
            }
            catch (Exception error)
            {
                BestEffort.Report(error);
                result = VkRewardedResult.Unavailable;
            }
        });
        using var closed = new Java.Lang.Runnable(() => completed.TrySetResult(result));
        using var unavailable = new Java.Lang.Runnable(() => completed.TrySetResult(
            result == VkRewardedResult.Granted ? result : VkRewardedResult.Unavailable));
        int slotId = activity.PackageName?.EndsWith(".dev", StringComparison.Ordinal) == true
            ? DemoSlotId : AdvertisingConfiguration.VkRewardedSlotId;
        VkRewardedHost.Watch(activity, slotId, preferences.PersonalizedAdsConsent, reward, closed, unavailable);
        return await completed.Task;
    }

    internal static void UpdatePreferences(UserPreferencesState preferences) =>
        MainThread.BeginInvokeOnMainThread(() =>
            VkRewardedHost.UpdateEligibility(CanWatch(preferences), preferences.PersonalizedAdsConsent));

    internal static void CancelPending() => VkRewardedHost.CancelPending();

    internal static void CancelForActivity(global::Android.App.Activity activity) => VkRewardedHost.CancelForActivity(activity);

    private static bool CanWatch(UserPreferencesState preferences) =>
        AdvertisingConfiguration.CanRequestAds(
            preferences, AdvertisingConfiguration.PrivacyPolicyUrl, AdvertisingConfiguration.VkRewardedSlotId);
}
