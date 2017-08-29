package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.sdk.layouts.PNLargeLayout;
import net.pubnative.sdk.layouts.PNLayout;

public class PNInterstitialWrapper extends PNAdWrapper implements PNLargeLayout.ViewListener {
    private static final String TAG = PNInterstitialWrapper.class.getSimpleName();

    protected PNLargeLayout mInterstitial;

    public PNInterstitialWrapper() {
        super();
        this.mInterstitial = new PNLargeLayout();
    }

    public void load(String gameObjectName, String appToken, String placementId) {
        setGameObject(gameObjectName);
        mInterstitial.setTrackListener(this);
        mInterstitial.setViewListener(this);
        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the interstitial");
        } else {
            mInterstitial.load(UnityPlayer.currentActivity, appToken, placementId, this);
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

    @Override
    public void onPNLayoutViewShown(PNLayout pnLayout) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutViewShown", "Interstitial shown");
    }

    @Override
    public void onPNLayoutViewHidden(PNLayout pnLayout) {
        UnityPlayer.UnitySendMessage(mGameObjectName, "OnPNLayoutViewHidden", "Interstitial hidden");
    }
}
