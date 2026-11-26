package app.psychology.ads;

import android.app.Activity;
import android.content.Context;
import android.os.Handler;
import android.os.Looper;
import android.os.SystemClock;
import android.util.Log;
import com.my.target.ads.InterstitialAd;
import com.my.target.common.MyTargetManager;
import com.my.target.common.MyTargetPrivacy;
import com.my.target.common.models.IAdLoadingError;

public final class VkInterstitialHost {
    private static final String TAG = "VkInterstitial";
    private static final long RETRY_DELAY_MS = 60_000;
    private static final long SHOW_INTERVAL_MS = 10 * 60_000;
    private static final Handler main = new Handler(Looper.getMainLooper());
    private static final Runnable expire = VkInterstitialHost::discardPending;
    private static InterstitialAd current;
    private static boolean ready;
    private static boolean showing;
    private static boolean personalizedConsent;
    private static long nextRequestAt;
    private static long nextShowAt;

    private VkInterstitialHost() { }

    public static void preload(Context context, int slotId, boolean consent) {
        updateEligibility(true, consent);
        long now = SystemClock.elapsedRealtime();
        if (current != null || slotId <= 0 || now < nextRequestAt || now < nextShowAt) return;
        nextRequestAt = now + RETRY_DELAY_MS;

        try {
            Context appContext = context.getApplicationContext();
            MyTargetPrivacy.setUserConsent(consent);
            if (!MyTargetManager.isSdkInitialized()) {
                MyTargetManager.initSdk(appContext);
            }

            InterstitialAd ad = new InterstitialAd(slotId, appContext);
            current = ad;
            personalizedConsent = consent;
            ad.setListener(new InterstitialAd.InterstitialAdListener() {
                @Override public void onLoad(InterstitialAd loaded) {
                    if (loaded != current) return;
                    ready = true;
                    Log.i(TAG, "Ad loaded: slot=" + slotId);
                }

                @Override public void onNoAd(IAdLoadingError error, InterstitialAd failed) {
                    if (failed != current) return;
                    Log.w(TAG, "No ad: slot=" + slotId + ", code=" + error.getCode());
                    clear();
                }

                @Override public void onDisplay(InterstitialAd displayed) {
                    if (displayed == current) Log.i(TAG, "Ad shown: slot=" + slotId);
                }

                @Override public void onDismiss(InterstitialAd dismissed) {
                    if (dismissed != current) return;
                    Log.i(TAG, "Ad dismissed: slot=" + slotId);
                    clear();
                }

                @Override public void onFailedToShow(InterstitialAd failed) {
                    if (failed != current) return;
                    Log.w(TAG, "Ad could not be shown: slot=" + slotId);
                    clear();
                }

                @Override public void onClick(InterstitialAd ad) { }
                @Override public void onVideoCompleted(InterstitialAd ad) { }
            });
            main.postDelayed(expire, 2 * 60_000);
            Log.i(TAG, "Requesting ad: slot=" + slotId + ", package=" + appContext.getPackageName());
            ad.load();
        } catch (RuntimeException | LinkageError error) {
            logFailure(error);
            clear();
        }
    }

    public static void showIfReady(Activity activity, boolean consent) {
        updateEligibility(true, consent);
        if (!ready || showing || current == null || activity.isFinishing()
                || activity.isDestroyed() || !activity.hasWindowFocus()
                || SystemClock.elapsedRealtime() < nextShowAt) {
            Log.i(TAG, "Show skipped: ready=" + ready + ", focused=" + activity.hasWindowFocus());
            discardPending();
            return;
        }

        main.removeCallbacks(expire);
        showing = true;
        ready = false;
        nextShowAt = SystemClock.elapsedRealtime() + SHOW_INTERVAL_MS;
        try {
            current.show(activity);
        } catch (RuntimeException | LinkageError error) {
            logFailure(error);
            clear();
        }
    }

    public static void updateEligibility(boolean enabled, boolean consent) {
        if (!enabled || consent != personalizedConsent) discardPending();
    }

    public static void discardPending() {
        if (!showing) clear();
    }

    private static void clear() {
        main.removeCallbacks(expire);
        InterstitialAd ad = current;
        current = null;
        ready = false;
        showing = false;
        if (ad == null) return;

        try {
            ad.setListener(null);
            ad.destroy();
        } catch (RuntimeException | LinkageError error) {
            logFailure(error);
        }
    }

    private static void logFailure(Throwable error) {
        Log.w(TAG, "Interstitial unavailable: " + error.getClass().getSimpleName());
    }
}
