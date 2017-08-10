using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerNativeAndroid : MonoBehaviour, ILoadListener
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
		banner = this.gameObject.AddComponent<PNBanner> ();
		banner.appToken = appToken;
		banner.placement = placement;
		banner.Listener = this;
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
}
