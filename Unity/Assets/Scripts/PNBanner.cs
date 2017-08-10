using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNBanner : PNAd
{
	private const string ANDROID_CLASS = "net.pubnative.unitypnbannerplugin.PNBannerWrapper";
	protected const string POSITION_TOP_METHOD = "getTopPosition";
	protected const string POSITION_BOTTOM_METHOD = "getBottomPosition";

	public enum Position
	{
		TOP = 1,
		BOTTOM = 2
	}

	public override string AndroidClassName ()
	{
		return ANDROID_CLASS;
	}

	public void Load ()
	{
		layoutWrapper.Call (LOAD_METHOD, this.gameObject.name, appToken, placement);
	}

	public void Show (Position position)
	{
		int positionValue = (int)position;

		layoutWrapper.Call (SHOW_METHOD, positionValue);
	}

	public void Hide ()
	{
		layoutWrapper.Call (HIDE_METHOD);
	}
}
