package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.HyBid;
import net.pubnative.lite.sdk.interstitial.HyBidInterstitialAd;

public class HyBidInterstitialWrapper implements HyBidInterstitialAd.Listener {
    private static final String TAG = HyBidInterstitialWrapper.class.getSimpleName();

    protected String mGameObjectName;
    protected String mAdId;
    protected HyBidInterstitialAd mInterstitial;

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

    public void load(String gameObjectName, String appToken, String placementId, String adId) {
        setGameObject(gameObjectName);
        setAdId(adId);
        if (mInterstitial != null) {
            mInterstitial.destroy();
        }

        mInterstitial = new HyBidInterstitialAd(UnityPlayer.currentActivity, placementId, this);

        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the interstitial");
        } else {
            if (!HyBid.isInitialized()) {
                HyBid.initialize(appToken, UnityPlayer.currentActivity.getApplication(), new HyBid.InitialisationListener() {
                    @Override
                    public void onInitialisationFinished(boolean b) {
                        mInterstitial.load();
                    }
                });
            } else {
                mInterstitial.load();
            }
        }
    }

    public void show(String adId) {
        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                mInterstitial.show();
            }
        });
    }

    public void hide(String adId) {
        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                //mInterstitial.hide();
            }
        });
    }

    @Override
    public void onInterstitialLoaded() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidInterstitialLoaded", mAdId);
    }

    @Override
    public void onInterstitialLoadFailed(Throwable throwable) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidInterstitialLoadFailed", mAdId);
    }

    @Override
    public void onInterstitialImpression() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidInterstitialImpression", mAdId);
    }

    @Override
    public void onInterstitialClick() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidInterstitialClick", mAdId);
    }

    @Override
    public void onInterstitialDismissed() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidInterstitialDismissed", mAdId);
    }
}
