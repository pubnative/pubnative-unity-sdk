using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNInterstitialFactory {

	public static PNInterstitial createInterstitial(MonoBehaviour parent) 
	{
		PNInterstitial interstitial;

		#if UNITY_EDITOR

		interstitial = parent.gameObject.AddComponent<PNEditorInterstitial> ();

		#elif UNITY_ANDROID

		interstitial = parent.gameObject.AddComponent<PNAndroidInterstitial> ();

		#elif UNITY_IOS

		interstitial = parent.gameObject.AddComponent<PNIOSInterstitial> ();

		#endif

		return interstitial;
		}
}
