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
import com.my.target.common.MyTargetPrivacy;
import com.my.target.common.models.IAdLoadingError;

public final class VkBannerHost extends FrameLayout {
    private MyTargetView banner;
    private Runnable loaded;
    private Runnable failed;
    private boolean active;
    private boolean privacyStateSet;
    private int generation;

    public VkBannerHost(Context context) { super(context); }

    public void setCallbacks(Runnable onLoaded, Runnable onFailed) {
        loaded = onLoaded;
        failed = onFailed;
    }

    public void start(int slotId, String disclosure, boolean dark) {
        if (active || slotId <= 0) return;
        active = true;
        final int requestGeneration = ++generation;
        try {
            // Do not signal affirmative user consent when banners load automatically.
            MyTargetPrivacy.setUserConsent(false);
            privacyStateSet = true;
            LinearLayout layout = new LinearLayout(getContext());
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
            layout.addView(ad, adLayoutParams);
            addView(layout);
            ad.setListener(new MyTargetView.MyTargetViewListener() {
                @Override public void onLoad(MyTargetView view) {
                    if (!active || requestGeneration != generation) { view.destroy(); return; }
                    if (loaded != null) loaded.run();
                }
                @Override public void onNoAd(IAdLoadingError error, MyTargetView view) { fail(requestGeneration); }
                @Override public void onClick(MyTargetView view) { }
                @Override public void onShow(MyTargetView view) { }
            });
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
        if (privacyStateSet) {
            try { MyTargetPrivacy.setUserConsent(false); }
            catch (RuntimeException | LinkageError error) { logFailure(error); }
            privacyStateSet = false;
        }
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
