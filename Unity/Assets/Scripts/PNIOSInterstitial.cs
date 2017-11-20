using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNIOSInterstitial : PNInterstitial
{

	public string interstitialID = "";

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void removeInterstitial(string interstitialID);
	void onDestroy()
	{
		removeInterstitial(interstitialID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadInterstitial(string gameObjectName, string appToken, string placement, string interstitialID);
	public override void Load ()
	{
		interstitialID = this.GetHashCode().ToString();
		loadInterstitial(this.gameObject.name, appToken, placement, interstitialID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void showInterstitial(string interstitialID);
	public override void Show ()
	{
		showInterstitial(interstitialID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hideInterstitial (string interstitialID);
	public override void Hide ()
	{
		hideInterstitial(interstitialID);
	}
}
