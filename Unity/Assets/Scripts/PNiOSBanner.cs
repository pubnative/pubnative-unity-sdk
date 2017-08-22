using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNIOSBanner : PNBanner
{
	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void load(string objectName, string appToken, string placement);
	public override void Load ()
	{
		 load(this.gameObject.name, appToken, placement);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void show(int positon);
	public override void Show (Position position)
	{
		int positionValue = (int)position;
		show(positionValue);
	}

	[System.Runtime.InteropServices.DllImport("__Internal")]
	extern static public void hide ();
	public override void Hide ()
	{
		hide();
	}
}
