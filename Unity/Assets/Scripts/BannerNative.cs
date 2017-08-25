using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerNative : MonoBehaviour, ILoadListener, ITrackListener
{
	private PNBanner banner;

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

		banner = this.gameObject.AddComponent<PNEditorBanner> ();

		#elif UNITY_ANDROID

		banner = this.gameObject.AddComponent<PNAndroidBanner> ();

		#elif UNITY_IOS

		banner = this.gameObject.AddComponent<PNIOSBanner> ();

		#endif

		banner.appToken = appToken;
		banner.placement = placement;
		banner.LoadListener = this;
		banner.TrackListener = this;
		_buttonLoadBanner.onClick.AddListener (RequestBanner);
		_buttonHideBanner.onClick.AddListener (HideBanner);
	}

	private void RequestBanner ()
	{
		if (banner != null) {
			banner.Load ();
		}
	}

	private void HideBanner ()
	{
		banner.Hide ();
	}

	public void LoadFinished ()
	{
		banner.Show (PNBanner.Position.TOP);
	}

	public void LoadFailed (Exception error)
	{
		// Handle error
	}

	public void ImpressionTracked()
	{
		// Handle Impression
	}

	public void ClickTracked ()
	{
		// Handle Click
	}
}
