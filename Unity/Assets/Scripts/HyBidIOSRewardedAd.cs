using System;

public class HyBidIOSRewardedAd : HyBidRewardedAd
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadRewarded(string gameObjectName, string appToken, string placement, string adID);
	public override void Load ()
	{
		loadRewarded(this.gameObject.name, appToken, placement, adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void showRewarded(string adID);
	public override void Show ()
	{
		showRewarded(adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hideRewarded (string adID);
	public override void Hide ()
	{
		hideRewarded(adID);
	}
}