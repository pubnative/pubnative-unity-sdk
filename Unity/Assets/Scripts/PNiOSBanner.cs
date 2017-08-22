using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNIOSBanner : PNBanner
{
	public string bannerID;

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public string load(string gameObjectName, string appToken, string placement);
	public override void Load ()
	{
		 bannerID = load(this.gameObject.name, appToken, placement);
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
		if (this.listener == null) {
			// Handle no listener set up
		} else {
			if (bannerID.Equals(message, StringComparison.Ordinal)) {
				this.listener.LoadFinished();
			}
		}
	}

	protected override void OnPNLayoutLoadFailed (string message)
	{
		if (this.listener == null) {
			// Handle no listener set up
		} else {
			if (bannerID.Equals(message, StringComparison.Ordinal)) {
				this.listener.LoadFailed(new Exception ("Ad failed to load."));
			}
		}
	}

}
