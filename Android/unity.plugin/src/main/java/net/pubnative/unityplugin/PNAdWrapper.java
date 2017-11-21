package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.sdk.layouts.PNLayout;

public class PNAdWrapper implements PNLayout.LoadListener, PNLayout.TrackListener {
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
    public void onPNLayoutLoadFinish(PNLayout pnLayout) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutLoadFinish", mAdId);
    }

    @Override
    public void onPNLayoutLoadFail(PNLayout pnLayout, Exception e) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutLoadFailed", mAdId);
    }

    @Override
    public void onPNLayoutTrackImpression(PNLayout pnLayout) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutTrackImpression", mAdId);
    }

    @Override
    public void onPNLayoutTrackClick(PNLayout pnLayout) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutTrackClick", mAdId);
    }
}
