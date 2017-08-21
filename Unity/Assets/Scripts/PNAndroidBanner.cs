using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNAndroidBanner : PNBanner
{
	private const string ANDROID_CLASS = "net.pubnative.unityplugin.PNBannerWrapper";
	protected const string LOAD_METHOD = "load";
	protected const string HIDE_METHOD = "hide";
	protected const string SHOW_METHOD = "show";
	protected const string POSITION_TOP_METHOD = "getTopPosition";
	protected const string POSITION_BOTTOM_METHOD = "getBottomPosition";

	protected AndroidJavaObject layoutWrapper;

	public PNAndroidBanner ()
	{
		layoutWrapper = new AndroidJavaObject (ANDROID_CLASS);
	}
		
	public override void Load ()
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement);
	}

	public override void Show (Position position)
	{
		int positionValue = (int)position;

		layoutWrapper.Call (SHOW_METHOD, positionValue);
	}

	public override void Hide ()
	{
		layoutWrapper.Call (HIDE_METHOD);
	}
}
