using System;

public class HyBidIOSInterstitialAd : HyBidInterstitialAd
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadInterstitial(string gameObjectName, string appToken, string placement, string adID);
	public override void Load ()
	{
		loadInterstitial(this.gameObject.name, appToken, placement, adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void showInterstitial(string adID);
	public override void Show ()
	{
		showInterstitial(adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hideInterstitial (string adID);
	public override void Hide ()
	{
		hideInterstitial(adID);
	}
}