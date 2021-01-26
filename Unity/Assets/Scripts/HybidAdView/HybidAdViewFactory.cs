using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HybidAdViewFactory
{
    public static HybidBanner createHybidAdView(MonoBehaviour parent) 
	{
		HybidBanner hybidAdView;

		#if UNITY_EDITOR

		hybidAdView = parent.gameObject.AddComponent<HybidEditorBanner> ();

		#elif UNITY_ANDROID

		hybidAdView = parent.gameObject.AddComponent<HybidAndroidBanner> ();

		#elif UNITY_IOS

		hybidAdView = parent.gameObject.AddComponent<HybidIOSBanner> ();

		#endif

		return hybidAdView;
	}
}