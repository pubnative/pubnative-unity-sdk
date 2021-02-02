using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HyBidIOSBanner : HyBidAdView
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadBanner(string gameObjectName, string appToken, string placement, string adID, int position);
	public override void Load (int position)
	{
		loadBanner(this.gameObject.name, appToken, placement, adID, position);
	}
}