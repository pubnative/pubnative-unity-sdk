package net.pubnative.unityplugin;

import android.util.Log;

import com.unity3d.player.UnityPlayer;

import net.pubnative.sdk.layouts.PNBanner;

public class PNBannerWrapper extends PNAdWrapper {
    private static final String TAG = PNBannerWrapper.class.getSimpleName();

    protected PNBanner mBanner;

    public PNBannerWrapper() {
        super();
        this.mBanner = new PNBanner();
    }

    public void load(String gameObjectName, String appToken, String placementId, String adId) {
        setGameObject(gameObjectName);
        setAdId(adId);
        mBanner.setTrackListener(this);
        if (UnityPlayer.currentActivity == null) {
            Log.e(TAG, "No active context found to load the banner");
        } else {
            mBanner.load(UnityPlayer.currentActivity, appToken, placementId, this);
        }
    }

    public void show(String adId, int position) {
        final PNBanner.Position bannerPosition;
        if (position == getTopPosition()) {
            bannerPosition = PNBanner.Position.TOP;
        } else {
            bannerPosition = PNBanner.Position.BOTTOM;
        }

        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                mBanner.show(bannerPosition);
            }
        });
    }

    //These two position methods will be called from Unity to determine the display position
    public int getTopPosition() {
        return 1;
    }

    public int getBottomPosition() {
        return 2;
    }

    public void hide() {
        executeDisplayAction(new Runnable() {
            @Override
            public void run() {
                mBanner.hide();
            }
        });
    }
}
