using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNAndroidInterstitial : PNInterstitial
{
	private const string ANDROID_CLASS = "net.pubnative.unityplugin.PNInterstitialWrapper";
	protected const string LOAD_METHOD = "load";
	protected const string HIDE_METHOD = "hide";
	protected const string SHOW_METHOD = "show";

	protected AndroidJavaObject layoutWrapper;

	public PNAndroidInterstitial ()
	{
		layoutWrapper = new AndroidJavaObject (ANDROID_CLASS);
	}

	public override void Load ()
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement);
	}

	public override void Show ()
	{
		layoutWrapper.Call (SHOW_METHOD);
	}

	public override void Hide ()
	{
		layoutWrapper.Call (HIDE_METHOD);
	}
}
