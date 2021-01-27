package net.pubnative.unityplugin;

import android.util.Log;
import android.view.View;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.api.RequestManager;
import net.pubnative.lite.sdk.auction.Auction;
import net.pubnative.lite.sdk.models.Ad;
import net.pubnative.lite.sdk.presenter.AdPresenter;
import net.pubnative.lite.sdk.views.HyBidAdView;

import java.util.PriorityQueue;

public class HyBidAdWrapper implements HyBidAdView.Listener {

    private static final String TAG = PNAdWrapper.class.getSimpleName();

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

    @Override
    public void onAdLoaded() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHybidAdLoaded", mAdId);
    }

    @Override
    public void onAdLoadFailed(Throwable throwable) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHybidAdError", mAdId);
    }

    @Override
    public void onAdImpression() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHybidAdImpression", mAdId);
    }

    @Override
    public void onAdClick() {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnHybidAdClicked", mAdId);
    }
}
