using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNIOSBanner : PNBanner
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void removeBanner(string bannerID);
	void onDestroy()
	{
		removeBanner(adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadBanner(string gameObjectName, string appToken, string placement, string bannerID);
	public override void Load ()
	{
		adID = this.GetHashCode().ToString();
		load(this.gameObject.name, appToken, placement, adID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void showBanner(string bannerID, int positon);
	public override void Show (Position position)
	{
		int positionValue = (int)position;
		show(adID, positionValue);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hideBanner (string bannerID);
	public override void Hide ()
	{
		hide(adID);
	}
}
