package app.psychology.ads;

import android.content.Context;
import android.graphics.drawable.GradientDrawable;
import android.text.TextUtils;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.ContextThemeWrapper;
import android.view.View;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.TextView;
import com.my.target.common.MyTargetManager;
import com.my.target.common.MyTargetPrivacy;
import com.my.target.common.models.IAdLoadingError;
import com.my.target.nativeads.NativeAd;
import com.my.target.nativeads.banners.NativePromoBanner;
import com.my.target.nativeads.views.NativeAdView;
import java.util.Collections;

public final class VkNativeHost extends FrameLayout {
    private static final String TAG = "VkNative";
    private final Runnable updateSize = this::notifyChange;
    private NativeAd current;
    private boolean requested;
    private boolean personalizedConsent;
    private Runnable changed;

    public VkNativeHost(Context context) { super(context); }

    public void setChanged(Runnable callback) { changed = callback; }

    public void start(int slotId, String disclosure, boolean dark, boolean consent) {
        if (requested && personalizedConsent == consent) return;
        stop();
        requested = true;
        personalizedConsent = consent;

        try {
            Context context = getContext().getApplicationContext();
            MyTargetPrivacy.setUserConsent(consent);
            if (!MyTargetManager.isSdkInitialized()) MyTargetManager.initSdk(context);
            NativeAd ad = new NativeAd(slotId, context);
            current = ad;
            ad.setAdChoicesOptionListener(new NativeAd.NativeAdChoicesOptionListener() {
                @Override public boolean shouldCloseAutomatically() { return true; }
                @Override public void onCloseAutomatically(NativeAd closed) { hide(closed); }
                @Override public void closeIfAutomaticallyDisabled(NativeAd closed) { hide(closed); }
            });
            ad.setListener(new NativeAd.NativeAdListener() {
                @Override public void onLoad(NativePromoBanner banner, NativeAd loaded) {
                    if (loaded != current) return;
                    try {
                        NativeAdView card = createCard(banner, disclosure, dark);
                        Button action = card.getCtaButtonView();
                        View clickTarget = action.getVisibility() == View.VISIBLE ? action : card.getTitleTextView();
                        // Keep the SDK binder for impression tracking, media and AdChoices.
                        loaded.registerView(card.getNativeAdViewBinder(), Collections.singletonList(clickTarget));
                        addView(card, new LayoutParams(LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
                        Log.i(TAG, "Loaded: slot=" + slotId);
                        notifyChange();
                    } catch (RuntimeException | LinkageError error) {
                        logFailure(error);
                        hide(loaded);
                    }
                }

                @Override public void onNoAd(IAdLoadingError error, NativeAd failed) {
                    if (failed != current) return;
                    Log.w(TAG, "No ad: slot=" + slotId + ", code=" + error.getCode());
                    hide(failed);
                }

                @Override public void onShow(NativeAd shown) {
                    if (shown == current) Log.i(TAG, "Shown: slot=" + slotId);
                }

                @Override public void onClick(NativeAd ad) { }
                @Override public void onClick(View view, NativeAd ad) { }
                @Override public void onVideoPlay(NativeAd ad) { }
                @Override public void onVideoPause(NativeAd ad) { }
                @Override public void onVideoComplete(NativeAd ad) { }
            });
            Log.i(TAG, "Requesting: slot=" + slotId);
            ad.load();
        } catch (RuntimeException | LinkageError error) {
            logFailure(error);
            clearAd();
            notifyChange();
        }
    }

    private NativeAdView createCard(NativePromoBanner banner, String disclosure, boolean dark) {
        Context themed = new ContextThemeWrapper(getContext(),
                dark ? android.R.style.Theme_Material : android.R.style.Theme_Material_Light);
        NativeAdView card = new NativeAdView(themed);
        card.setupView(banner);
        TextView label = card.getAdvertisingTextView();
        if (TextUtils.isEmpty(label.getText())) label.setText(disclosure);
        label.setVisibility(View.VISIBLE);

        int secondary = dark ? 0xffaaaaaa : 0xff666666;
        label.setTextColor(secondary);
        card.getTitleTextView().setTextColor(dark ? 0xffeeeeee : 0xff343434);
        card.getDescriptionTextView().setTextColor(secondary);
        card.getDomainOrCategoryTextView().setTextColor(secondary);
        card.getAgeRestrictionTextView().setTextColor(secondary);
        card.getDisclaimerTextView().setTextColor(secondary);
        Button action = card.getCtaButtonView();
        action.setTextColor(dark ? 0xff3399ff : 0xff0062bd);
        action.setMinHeight(dp(48));

        GradientDrawable surface = new GradientDrawable();
        surface.setColor(dark ? 0xff282828 : 0xffffffff);
        surface.setCornerRadius(dp(12));
        card.setBackground(surface);
        card.setClipToOutline(true);
        return card;
    }

    public void stop() {
        requested = false;
        clearAd();
    }

    private void clearAd() {
        NativeAd ad = current;
        current = null;
        removeCallbacks(updateSize);
        if (ad != null) {
            try {
                ad.setListener(null);
                ad.setAdChoicesOptionListener(null);
                ad.unregisterView();
            } catch (RuntimeException | LinkageError error) {
                logFailure(error);
            }
        }
        removeAllViews();
    }

    public int measureContentHeightDp() {
        View card = getChildAt(0);
        if (card == null) return 0;
        DisplayMetrics metrics = getResources().getDisplayMetrics();
        int width = getWidth() > 0 ? getWidth() : metrics.widthPixels - dp(40);
        card.measure(View.MeasureSpec.makeMeasureSpec(Math.max(1, width), View.MeasureSpec.EXACTLY),
                View.MeasureSpec.makeMeasureSpec(0, View.MeasureSpec.UNSPECIFIED));
        return (int)Math.ceil(card.getMeasuredHeight() / metrics.density);
    }

    @Override protected void onSizeChanged(int width, int height, int oldWidth, int oldHeight) {
        super.onSizeChanged(width, height, oldWidth, oldHeight);
        if (width > 0 && width != oldWidth && getChildCount() > 0) {
            removeCallbacks(updateSize);
            post(updateSize);
        }
    }

    private int dp(int value) { return Math.round(value * getResources().getDisplayMetrics().density); }

    private void hide(NativeAd ad) {
        if (ad != current) return;
        clearAd();
        notifyChange();
    }

    public static void updatePersonalizedAdsConsent(boolean consent) {
        try { MyTargetPrivacy.setUserConsent(consent); }
        catch (RuntimeException | LinkageError error) { logFailure(error); }
    }

    private void notifyChange() { if (changed != null) changed.run(); }

    private static void logFailure(Throwable error) {
        Log.w(TAG, "Native ad unavailable: " + error.getClass().getSimpleName());
    }
}
