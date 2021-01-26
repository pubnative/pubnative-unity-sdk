package net.pubnative.unityplugin;

import android.util.Log;
import android.view.View;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.api.RequestManager;
import net.pubnative.lite.sdk.auction.Auction;
import net.pubnative.lite.sdk.models.Ad;
import net.pubnative.lite.sdk.presenter.AdPresenter;

import java.util.PriorityQueue;

public class HybidAdWrapper implements RequestManager.RequestListener, AdPresenter.Listener, Auction.Listener {

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
    public void onRequestSuccess(Ad ad) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onRequestManagerSuccess", mAdId);
    }

    @Override
    public void onRequestFail(Throwable throwable) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onRequestManagerFail", mAdId);
    }

    @Override
    public void onAdLoaded(AdPresenter adPresenter, View view) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onHybidAdLoaded", mAdId);
    }

    @Override
    public void onAdClicked(AdPresenter adPresenter) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onHybidAdClicked", mAdId);
    }

    @Override
    public void onAdError(AdPresenter adPresenter) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onHybidAdError", mAdId);
    }

    @Override
    public void onAuctionSuccess(PriorityQueue<Ad> priorityQueue) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onAuctionSuccess", mAdId);
    }

    @Override
    public void onAuctionFailure(Throwable throwable) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "onAuctionFailure", mAdId);
    }
}
