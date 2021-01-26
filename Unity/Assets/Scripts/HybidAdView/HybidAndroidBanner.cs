using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HybidAndroidBanner : HybidBanner {
    
    protected const string ANDROID_CLASS = "net.pubnative.unityplugin.HybidAndroidAdViewWrapper";
	protected const string LOAD_METHOD = "load";
	protected const string HIDE_METHOD = "hide";
	protected const string SHOW_METHOD = "show";

	protected AndroidJavaObject layoutWrapper;

	public HybidAndroidBanner ()
	{
		adID = this.GetHashCode().ToString();
		layoutWrapper = new AndroidJavaObject (ANDROID_CLASS);
	}

	public override void load ()
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement, adID);
	}

	public override void show (Position position)
	{
		int positionValue = (int) position;

		layoutWrapper.Call (SHOW_METHOD, adID, positionValue);
	}
}