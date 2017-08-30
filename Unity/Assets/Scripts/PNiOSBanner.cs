using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNIOSBanner : PNBanner
{
	public string bannerID = "";

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void removeBanner(string bannerID);
	void onDestroy()
	{
		removeBanner(bannerID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void loadBanner(string gameObjectName, string appToken, string placement, string bannerID);
	public override void Load ()
	{
		bannerID = this.GetHashCode().ToString();
		loadBanner(this.gameObject.name, appToken, placement, bannerID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void showBanner(string bannerID, int positon);
	public override void Show (Position position)
	{
		int positionValue = (int)position;
		showBanner(bannerID, positionValue);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hideBanner (string bannerID);
	public override void Hide ()
	{
		hideBanner(bannerID);
	}

	protected override void OnPNLayoutLoadFinish (string message)
	{
		if (this.loadListener != null && bannerID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.OnLoadFinished();
		}
	}

	protected override void OnPNLayoutLoadFailed (string message)
	{
		if (this.loadListener != null && bannerID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.OnLoadFailed(new Exception ("Ad failed to load."));
		}
	}
}
