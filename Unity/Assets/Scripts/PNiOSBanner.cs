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
	extern static public void load(string gameObjectName, string appToken, string placement, string bannerID);
	public override void Load ()
	{
		bannerID = this.GetHashCode().ToString();
		load(this.gameObject.name, appToken, placement, bannerID);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void show(string bannerID, int positon);
	public override void Show (Position position)
	{
		int positionValue = (int)position;
		show(bannerID, positionValue);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hide (string bannerID);
	public override void Hide ()
	{
		hide(bannerID);
	}

	protected override void OnPNLayoutLoadFinish (string message)
	{
		if (this.loadListener == null) {
			// Handle no listener set up
		} else {
			if (bannerID.Equals(message, StringComparison.Ordinal)) {
				this.loadListener.LoadFinished();
			}
		}
	}

	protected override void OnPNLayoutLoadFailed (string message)
	{
		if (this.loadListener == null) {
			// Handle no listener set up
		} else {
			if (bannerID.Equals(message, StringComparison.Ordinal)) {
				this.loadListener.LoadFailed(new Exception ("Ad failed to load."));
			}
		}
	}

}
