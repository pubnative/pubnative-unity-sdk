using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HyBidAndroidBanner : HyBidAdView {
    
    protected const string ANDROID_CLASS = "net.pubnative.unityplugin.HyBidAdViewWrapper";
	protected const string LOAD_METHOD = "load";

	protected AndroidJavaObject layoutWrapper;

	public HyBidAndroidBanner ()
	{
		adID = this.GetHashCode().ToString();
		layoutWrapper = new AndroidJavaObject (ANDROID_CLASS);
	}

	public override void Load (int position)
	{
		appToken = "dde3c298b47648459f8ada4a982fa92d";
		placement = "8";
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement, adID ,position);
	}

	public override void Hide ()
	{
		
	}
}