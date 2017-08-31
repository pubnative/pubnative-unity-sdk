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
	extern static public void load(string gameObjectName, string appToken, string placement, string interstitialID);
	public override void Load ()
	{
		interstitialID = this.GetHashCode().ToString();
		load(this.gameObject.name, appToken, placement, interstitialID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void show(string interstitialID);
	public override void Show ()
	{
		show(interstitialID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hide (string interstitialID);
	public override void Hide ()
	{
		hide(interstitialID);
	}
}
