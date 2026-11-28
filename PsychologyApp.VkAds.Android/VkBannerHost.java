package app.psychology.ads;

import android.content.Context;
import android.graphics.Color;
import android.util.Log;
import android.util.DisplayMetrics;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.my.target.ads.MyTargetView;
import com.my.target.common.MyTargetManager;
import com.my.target.common.MyTargetPrivacy;
import com.my.target.common.models.IAdLoadingError;

public final class VkBannerHost extends FrameLayout {
    private MyTargetView banner;
    private Runnable loaded;
    private Runnable failed;
    private boolean active;
    private boolean activePersonalizedAdsConsent;
    private int generation;

    public VkBannerHost(Context context) { super(context); }

    public void setCallbacks(Runnable onLoaded, Runnable onFailed) {
        loaded = onLoaded;
        failed = onFailed;
    }

    public void start(int slotId, String disclosure, boolean dark, boolean personalizedAdsConsent) {
        if (slotId <= 0) return;
        if (active) {
            if (activePersonalizedAdsConsent == personalizedAdsConsent) return;
            stop();
        }
        active = true;
        activePersonalizedAdsConsent = personalizedAdsConsent;
        final int requestGeneration = ++generation;
        try {
            MyTargetPrivacy.setUserConsent(personalizedAdsConsent);
            if (!MyTargetManager.isSdkInitialized()) MyTargetManager.initSdk(getContext().getApplicationContext());
            final LinearLayout layout = new LinearLayout(getContext());
            layout.setOrientation(LinearLayout.VERTICAL);
            TextView label = new TextView(getContext());
            label.setText(disclosure);
            label.setTextSize(12);
            label.setTextColor(dark ? Color.LTGRAY : Color.DKGRAY);
            layout.addView(label);

            MyTargetView ad = new MyTargetView(getContext());
            banner = ad;
            ad.setSlotId(slotId);
            MyTargetView.AdSize adSize = MyTargetView.AdSize.ADSIZE_320x50;
            ad.setAdSize(adSize);
            ad.setRefreshAd(false);
            LinearLayout.LayoutParams adLayoutParams = new LinearLayout.LayoutParams(
                    adSize.getWidthPixels(), ViewGroup.LayoutParams.WRAP_CONTENT);
            adLayoutParams.gravity = Gravity.CENTER_HORIZONTAL;
            ad.setListener(new MyTargetView.MyTargetViewListener() {
                @Override public void onLoad(MyTargetView view) {
                    if (!active || requestGeneration != generation) { view.destroy(); return; }
                    // VK's integration contract attaches the banner only after a successful load.
                    // Until then, the zero-height MAUI host is not a visible ad placement.
                    layout.addView(view, adLayoutParams);
                    addView(layout);
                    Log.i("VkBanner", "Banner loaded: slot=" + slotId);
                    if (loaded != null) loaded.run();
                }
                @Override public void onNoAd(IAdLoadingError error, MyTargetView view) {
                    if (!active || requestGeneration != generation) return;
                    // The SDK's technical error distinguishes no-fill from a configuration or transport failure.
                    // No app content or custom targeting parameters are included in this diagnostic.
                    Log.w("VkBanner", "Banner request failed: slot=" + slotId
                            + ", code=" + error.getCode() + ", reason=" + error.getMessage());
                    fail(requestGeneration);
                }
                @Override public void onClick(MyTargetView view) { }
                @Override public void onShow(MyTargetView view) {
                    if (active && requestGeneration == generation) Log.i("VkBanner", "Banner shown: slot=" + slotId);
                }
            });
            Log.i("VkBanner", "Requesting banner: slot=" + slotId + ", package=" + getContext().getPackageName() + ", size=320x50");
            ad.load();
        } catch (RuntimeException | LinkageError error) {
            logFailure(error);
            fail(requestGeneration);
        }
    }

    private void fail(int requestGeneration) {
        if (!active || requestGeneration != generation) return;
        Runnable callback = failed;
        stop();
        if (callback != null) callback.run();
    }

    private static void logFailure(Throwable error) {
        Log.w("VkBanner", "Banner unavailable: " + error.getClass().getSimpleName());
    }

    public void stop() {
        active = false;
        generation++;
        if (banner != null) {
            try { banner.destroy(); }
            catch (RuntimeException | LinkageError error) { logFailure(error); }
            banner = null;
        }
        removeAllViews();
    }

    public int measureContentHeightDp() {
        DisplayMetrics metrics = getResources().getDisplayMetrics();
        int width = getWidth() > 0 ? getWidth() : metrics.widthPixels - Math.round(40 * metrics.density);
        measure(View.MeasureSpec.makeMeasureSpec(Math.max(1, width), View.MeasureSpec.EXACTLY),
                View.MeasureSpec.makeMeasureSpec(0, View.MeasureSpec.UNSPECIFIED));
        return Math.max(1, (int)Math.ceil(getMeasuredHeight() / metrics.density));
    }
}
