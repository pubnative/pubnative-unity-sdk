package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.lite.sdk.views.HyBidAdView;
import net.pubnative.sdk.core.Pubnative;

public class HyBidAdViewWrapper extends HyBidAdWrapper {

    private static final String TAG = HyBidAdViewWrapper.class.getSimpleName();

    protected HyBidAdView hyBidAdView;

    public HyBidAdViewWrapper() {
        super();
        this.hyBidAdView = new HyBidAdView(UnityPlayer.currentActivity);
    }

    public void load(String gameObjectName, String appToken, String placementId, String adId, int position) {

        setGameObject(gameObjectName);
        setAdId(adId);

        if (hyBidAdView != null) {
            hyBidAdView.destroy();
        }

        HyBidAdView.Position bannerPosition;
        this.hyBidAdView = new HyBidAdView(UnityPlayer.currentActivity);

        if (position == getTopPosition()) {
            bannerPosition = HyBidAdView.Position.TOP;
        } else {
            bannerPosition = HyBidAdView.Position.BOTTOM;
        }

        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the banner");
        } else {
            Pubnative.init(UnityPlayer.currentActivity, appToken);
            hyBidAdView.load(placementId, bannerPosition, (HyBidAdView.Listener) UnityPlayer.currentActivity);
        }
    }

    private int getTopPosition() {
        return 1;
    }

    private int getBottomPosition() {
        return 2;
    }
}