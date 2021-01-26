using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HybidAdViewFactory
{
    public static HybidAdView createHybidAdView(MonoBehaviour parent) 
	{
		HybidAdView hybidAdView;

		#if UNITY_EDITOR

		hybidAdView = parent.gameObject.AddComponent<HybidEditorAdView> ();

		#elif UNITY_ANDROID

		hybidAdView = parent.gameObject.AddComponent<HybidAndroidAdView> ();

		#elif UNITY_IOS

		hybidAdView = parent.gameObject.AddComponent<HyBidIOSInterstitialAd> ();

		#endif

		return hybidAdView;
	}
}