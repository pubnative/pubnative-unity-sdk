using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNIOSInterstitial : PNInterstitial
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void removeInterstitial(string adID);
	void onDestroy()
	{
		removeInterstitial(adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadInterstitial(string gameObjectName, string appToken, string placement, string adID);
	public override void Load ()
	{
		adID = this.GetHashCode().ToString();
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
