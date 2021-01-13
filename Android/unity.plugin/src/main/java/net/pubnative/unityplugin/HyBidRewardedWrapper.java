package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.HyBid;
import net.pubnative.lite.sdk.interstitial.HyBidInterstitialAd;
import net.pubnative.lite.sdk.rewarded.HyBidRewardedAd;

public class HyBidRewardedWrapper implements HyBidRewardedAd.Listener {
    private static final String TAG = HyBidRewardedWrapper.class.getSimpleName();

    protected String mGameObjectName;
    protected String mAdId;
    protected HyBidRewardedAd mRewarded;

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
        if (mRewarded != null) {
            mRewarded.destroy();
        }

        mRewarded = new HyBidRewardedAd(UnityPlayer.currentActivity, placementId, this);

        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the rewarded ad");
        } else {
            HyBid.initialize(appToken, UnityPlayer.currentActivity.getApplication(), new HyBid.InitialisationListener() {
                @Override
                public void onInitialisationFinished(boolean b) {
                    mRewarded.load();
                }
            });
        }
    }

    public void show(String adId) {
        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                mRewarded.show();
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
    public void onRewardedLoaded() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedLoadFinish", mAdId);
    }

    @Override
    public void onRewardedLoadFailed(Throwable throwable) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedLoadFailed", mAdId);
    }

    @Override
    public void onRewardedClick() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedTrackClick", mAdId);
    }

    @Override
    public void onRewardedOpened() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedTrackImpression", mAdId);
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedViewShown", mAdId);
    }

    @Override
    public void onRewardedClosed() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedViewHidden", mAdId);
    }

    @Override
    public void onReward() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHyBidRewardedViewShown", mAdId);
    }
}
