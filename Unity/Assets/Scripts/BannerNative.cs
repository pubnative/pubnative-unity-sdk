using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerNative : MonoBehaviour, ILoadListener
{
	private PNBanner banner;
	private PNiOSBanner iosBanner;

	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadBanner;

	[SerializeField]
	private Button _buttonHideBanner;

	// Use this for initialization
	void Start ()
	{
		#if UNITY_EDITOR

		#elif UNITY_ANDROID

		banner = this.gameObject.AddComponent<PNBanner> ();
		banner.appToken = appToken;
		banner.placement = placement;
		banner.Listener = this;
		_buttonLoadBanner.onClick.AddListener (RequestBanner);
		_buttonHideBanner.onClick.AddListener (HideBanner);

		#elif UNITY_IOS

		iosBanner = this.gameObject.AddComponent<PNiOSBanner> ();
		banner.appToken = appToken;
		banner.placement = placement;
		banner.Listener = this;
		_buttonLoadBanner.onClick.AddListener (RequestBanner);
		_buttonHideBanner.onClick.AddListener (HideBanner);

		#endif
	}

	private void RequestBanner ()
	{


		#if UNITY_EDITOR

		#elif UNITY_ANDROID

		if (banner != null) {
			banner.Load ();
		}

		#elif UNITY_IOS

		if (iosBanner != null) {
			iosBanner.Load ();
		}

		#endif
	}

	private void HideBanner ()
	{
		#if UNITY_EDITOR

		#elif UNITY_ANDROID

		banner.Hide ();

		#elif UNITY_IOS

		iosBanner.Hide ();

		#endif
	}

	public void LoadFinished ()
	{
		#if UNITY_EDITOR

		#elif UNITY_ANDROID

		banner.Show (PNBanner.Position.TOP);

		#elif UNITY_IOS

		iosBanners.Show (PNBanner.Position.TOP);

		#endif
	}

	public void LoadFailed (Exception error)
	{
		// Handle error
	}
}
