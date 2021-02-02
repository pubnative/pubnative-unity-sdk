using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HyBidIOSBanner : HyBidAdView
{
    [System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void removeBanner(string adID);
	void onDestroy()
	{
		removeBanner(adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadBanner(string gameObjectName, string appToken, string placement, string adID);
	public override void Load (int position)
	{
        Console.WriteLine("###LOAD_BANNER");
		adID = this.GetHashCode().ToString();
		loadBanner(this.gameObject.name, appToken, placement, adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void showBanner(string adID, int positon);
	public override void Show (Position position)
	{
		int positionValue = (int)position;
		showBanner(adID, positionValue);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hideBanner (string adID);
	public override void Hide ()
	{
		hideBanner(adID);
	}
}