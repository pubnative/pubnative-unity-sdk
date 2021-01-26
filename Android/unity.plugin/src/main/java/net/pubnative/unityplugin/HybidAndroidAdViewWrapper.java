package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.views.HyBidAdView;
import net.pubnative.sdk.core.Pubnative;

public class HybidAndroidAdViewWrapper extends HybidAdWrapper {
    private static final String TAG = HybidAndroidAdViewWrapper.class.getSimpleName();

    protected HyBidAdView hyBidAdView;
    private HyBidAdView.Position bannerPosition;

    public HybidAndroidAdViewWrapper() {
        super();
        this.hyBidAdView = new HyBidAdView(UnityPlayer.currentActivity);
    }

    public void load(String gameObjectName, String appToken, String placementId, String adId) {

        setGameObject(gameObjectName);
        setAdId(adId);

        if (hyBidAdView != null) {
            hyBidAdView.destroy();
        }

        this.hyBidAdView = new HyBidAdView(UnityPlayer.currentActivity);

        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the banner");
        } else {
            Pubnative.init(UnityPlayer.currentActivity, appToken);
            hyBidAdView.load(placementId, (HyBidAdView.Listener) UnityPlayer.currentActivity);
        }
    }

    public void show(int position) {

        if (position == getTopPosition()) {
            bannerPosition = HyBidAdView.Position.TOP;
        } else {
            bannerPosition = HyBidAdView.Position.BOTTOM;
        }

        hyBidAdView.setPosition(bannerPosition);

        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                hyBidAdView.show();
            }
        });
    }

    private int getTopPosition() {
        return 1;
    }

    private int getBottomPosition() {
        return 2;
    }
}