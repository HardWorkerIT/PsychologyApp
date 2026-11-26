package app.psychology.ads;

import android.app.Activity;
import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import com.my.target.ads.Reward;
import com.my.target.ads.RewardedAd;
import com.my.target.common.MyTargetManager;
import com.my.target.common.MyTargetPrivacy;
import com.my.target.common.models.IAdLoadingError;
import java.lang.ref.WeakReference;

public final class VkRewardedHost {
    private static final String TAG = "VkRewarded";
    private static final Handler main = new Handler(Looper.getMainLooper());
    private static final Runnable loadTimeout = VkRewardedHost::cancelPending;
    private static final Runnable showTimeout = VkRewardedHost::expireShowing;
    private static final long SHOW_TIMEOUT_MS = 180_000;
    private static RewardedAd current;
    private static WeakReference<Activity> ownerActivity;
    private static Runnable unavailable;
    private static boolean personalizedConsent;
    private static boolean showing;
    private static boolean rewarded;

    private VkRewardedHost() { }

    public static void watch(Activity activity, int slotId, boolean consent,
            Runnable onReward, Runnable onClosed, Runnable onUnavailable) {
        if (current != null || !canShow(activity)) {
            onUnavailable.run();
            return;
        }

        unavailable = onUnavailable;
        personalizedConsent = consent;
        try {
            Context context = activity.getApplicationContext();
            MyTargetPrivacy.setUserConsent(consent);
            if (!MyTargetManager.isSdkInitialized()) MyTargetManager.initSdk(context);

            RewardedAd ad = new RewardedAd(slotId, context);
            current = ad;
            WeakReference<Activity> owner = new WeakReference<>(activity);
            ownerActivity = owner;
            ad.setListener(new RewardedAd.RewardedAdListener() {
                @Override public void onLoad(RewardedAd loaded) {
                    if (loaded != current) return;
                    Activity host = owner.get();
                    if (!canShow(host)) {
                        finish(onUnavailable);
                        return;
                    }

                    main.removeCallbacks(loadTimeout);
                    showing = true;
                    main.postDelayed(showTimeout, SHOW_TIMEOUT_MS);
                    try { loaded.show(host); }
                    catch (RuntimeException | LinkageError error) {
                        logFailure(error);
                        finish(onUnavailable);
                    }
                }

                @Override public void onNoAd(IAdLoadingError error, RewardedAd failed) {
                    if (failed != current) return;
                    Log.w(TAG, "No ad: slot=" + slotId + ", code=" + error.getCode());
                    finish(onUnavailable);
                }

                @Override public void onFailedToShow(RewardedAd failed) {
                    if (failed == current) finish(onUnavailable);
                }

                @Override public void onDisplay(RewardedAd displayed) {
                    if (displayed == current) Log.i(TAG, "Ad shown: slot=" + slotId);
                }

                @Override public void onDismiss(RewardedAd dismissed) {
                    // Let a reward callback already queued by the player run before releasing the ad.
                    main.post(() -> {
                        if (dismissed == current) {
                            Log.i(TAG, "Ad dismissed: slot=" + slotId);
                            finish(onClosed);
                        }
                    });
                }

                @Override public void onReward(Reward reward, RewardedAd earned) {
                    if (earned != current || !showing || rewarded) return;
                    rewarded = true;
                    Log.i(TAG, "Reward earned: slot=" + slotId);
                    onReward.run();
                }

                @Override public void onClick(RewardedAd ad) { }
            });
            main.postDelayed(loadTimeout, 20_000);
            Log.i(TAG, "Requesting ad: slot=" + slotId + ", package=" + context.getPackageName());
            ad.load();
        } catch (RuntimeException | LinkageError error) {
            logFailure(error);
            finish(onUnavailable);
        }
    }

    public static void cancelPending() {
        if (current != null && !showing) finish(unavailable);
    }

    private static void expireShowing() {
        if (current != null && showing) finish(unavailable);
    }

    public static void cancelForActivity(Activity activity) {
        if (current != null && ownerActivity != null && ownerActivity.get() == activity) finish(unavailable);
    }

    public static void updateEligibility(boolean enabled, boolean consent) {
        if (!enabled || personalizedConsent != consent) cancelPending();
    }

    private static boolean canShow(Activity activity) {
        return activity != null && !activity.isFinishing() && !activity.isDestroyed() && activity.hasWindowFocus();
    }

    private static void finish(Runnable callback) {
        main.removeCallbacks(loadTimeout);
        main.removeCallbacks(showTimeout);
        RewardedAd ad = current;
        current = null;
        ownerActivity = null;
        unavailable = null;
        showing = false;
        rewarded = false;
        if (ad != null) {
            try {
                ad.setListener(null);
                ad.destroy();
            } catch (RuntimeException | LinkageError error) {
                logFailure(error);
            }
        }
        callback.run();
    }

    private static void logFailure(Throwable error) {
        Log.w(TAG, "Rewarded ad unavailable: " + error.getClass().getSimpleName());
    }
}
