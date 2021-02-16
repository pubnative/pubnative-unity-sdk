package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.HyBid;
import net.pubnative.lite.sdk.models.AdSize;
import net.pubnative.lite.sdk.views.HyBidAdView;

public class HyBidAdViewWrapper implements HyBidAdView.Listener {

    private static final String TAG = HyBidAdViewWrapper.class.getSimpleName();

    protected HyBidAdView hyBidAdView;

    protected String mGameObjectName;
    protected String mAdId;

    protected void executeDisplayAction(Runnable runnable) {
        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to show the ad");
        } else {
            UnityPlayer.currentActivity.runOnUiThread(runnable);
        }
    }

    protected void setGameObject(String gameObjectName) {
        this.mGameObjectName = gameObjectName;
    }

    protected void setAdId(String adId) {
        this.mAdId = adId;
    }

    public void load(String gameObjectName, final String appToken, final String placementId, String adId, final int position) {
        try {
            setGameObject(gameObjectName);
            setAdId(adId);

            if (hyBidAdView != null) {
                UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        hyBidAdView.destroy();
                        startBanner(appToken, placementId, position);
                    }
                });
            } else {
                startBanner(appToken, placementId, position);
            }
        } catch (Exception e) {
            Log.d("Exception", e.toString());
        }
    }

    private void startBanner(String appToken, final String placementId, int position) {
        if (hyBidAdView != null) {
            hyBidAdView.destroy();
        }

        final HyBidAdView.Position bannerPosition;

        if (position == getTopPosition()) {
            bannerPosition = HyBidAdView.Position.TOP;
        } else {
            bannerPosition = HyBidAdView.Position.BOTTOM;
        }

        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the interstitial");
        } else {
            if (!HyBid.isInitialized()) {
                HyBid.initialize(appToken, UnityPlayer.currentActivity.getApplication(), new HyBid.InitialisationListener() {
                    @Override
                    public void onInitialisationFinished(boolean b) {
                        loadBanner(placementId, bannerPosition);
                    }
                });
            } else {
                loadBanner(placementId, bannerPosition);
            }
        }
    }

    private void loadBanner(final String placementId, final HyBidAdView.Position bannerPosition) {
        hyBidAdView = new HyBidAdView(UnityPlayer.currentActivity);
        hyBidAdView.setAdSize(AdSize.SIZE_320x50);
        hyBidAdView.load(placementId, bannerPosition, HyBidAdViewWrapper.this);
    }

    private int getTopPosition() {
        return 1;
    }

    private int getBottomPosition() {
        return 2;
    }

    @Override
    public void onAdLoaded() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidAdLoaded", mAdId);
    }

    @Override
    public void onAdLoadFailed(Throwable throwable) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidAdError", mAdId);
    }

    @Override
    public void onAdImpression() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidAdImpression", mAdId);
    }

    @Override
    public void onAdClick() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidAdClicked", mAdId);
    }
}