using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HyBidAndroidBanner : HyBidBanner {
    
    protected const string ANDROID_CLASS = "net.pubnative.unityplugin.HyBidAdViewWrapper";
	protected const string LOAD_METHOD = "load";
	protected const string HIDE_METHOD = "hide";
	protected const string SHOW_METHOD = "show";

	protected AndroidJavaObject layoutWrapper;

	public HyBidAndroidBanner ()
	{
		adID = this.GetHashCode().ToString();
		layoutWrapper = new AndroidJavaObject (ANDROID_CLASS);
	}

	public override void load (int position)
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement, adID ,position);
	}
}