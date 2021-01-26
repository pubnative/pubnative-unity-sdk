using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HybidAndroidAdView : HybidAdView {
    
    private const string ANDROID_CLASS = "net.pubnative.unityplugin.HybidAndroidAdViewWrapper";
	protected const string LOAD_METHOD = "load";
	protected const string HIDE_METHOD = "hide";
	protected const string SHOW_METHOD = "show";

	protected AndroidJavaObject layoutWrapper;

	public HybidAndroidAdView ()
	{
		adID = this.GetHashCode().ToString();
		layoutWrapper = new AndroidJavaObject (ANDROID_CLASS);
	}

	public override void Load ()
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement, adID, position);
	}

	public override void Show (Position position)
	{
		int positionValue = (int) position;

		layoutWrapper.Call (SHOW_METHOD, adID, positionValue);
	}
}