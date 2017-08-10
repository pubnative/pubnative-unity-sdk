package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.sdk.layouts.PNLargeLayout;

public class PNInterstitialWrapper extends PNAdWrapper {
    private static final String TAG = PNInterstitialWrapper.class.getSimpleName();

    protected PNLargeLayout mInterstitial;

    public PNInterstitialWrapper() {
        super();
        this.mInterstitial = new PNLargeLayout();
    }

    public void load(String gameObjectName, String appToken, String placementId) {
        setGameObject(gameObjectName);
        mInterstitial.setLoadListener(this);
        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the interstitial");
        } else {
            mInterstitial.load(UnityPlayer.currentActivity, appToken, placementId);
        }
    }

    public void show() {
        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                mInterstitial.show();
            }
        });
    }

    public void hide() {
        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                mInterstitial.hide();
            }
        });
    }
}
