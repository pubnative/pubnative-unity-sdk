package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.sdk.layouts.PNLayout;

public class PNAdWrapper implements PNLayout.LoadListener {
    private static final String TAG = PNAdWrapper.class.getSimpleName();

    protected String mGameObjectName;

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

    @Override
    public void onPNLayoutLoadFinish(PNLayout pnLayout) {
        if (mGameObjectName == null || mGameObjectName.isEmpty()) {
            Log.e(TAG, "No GameObject name has been defined.");
        } else {
            UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutLoadFinish", "Ad successfully loaded");
        }
    }

    @Override
    public void onPNLayoutLoadFail(PNLayout pnLayout, Exception e) {
        if (mGameObjectName == null || mGameObjectName.isEmpty()) {
            Log.e(TAG, "No GameObject name has been defined.");
        } else {
            UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutLoadFailed", e.getMessage());
        }
    }
}
