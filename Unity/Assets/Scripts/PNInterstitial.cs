using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNInterstitial : PNAd
{
	private const string ANDROID_CLASS = "net.pubnative.unityplugin.PNInterstitialWrapper";

	public override string AndroidClassName ()
	{
		return ANDROID_CLASS;
	}

	public void Load ()
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement);
	}

	public void Show ()
	{
		layoutWrapper.Call (SHOW_METHOD);
	}

	public void Hide ()
	{
		layoutWrapper.Call (HIDE_METHOD);
	}
}
