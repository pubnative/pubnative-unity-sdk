using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNBannerFactory {

	public static PNBanner createBanner(MonoBehaviour parent) 
	{
		PNBanner banner;

		#if UNITY_EDITOR

		banner = parent.gameObject.AddComponent<PNEditorBanner> ();

		#elif UNITY_ANDROID

		banner = parent.gameObject.AddComponent<PNAndroidBanner> ();

		#elif UNITY_IOS

		banner = parent.gameObject.AddComponent<PNIOSBanner> ();

		#endif

		return banner;
	}
}
