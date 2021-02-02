using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerNative : MonoBehaviour, IAdViewListener
{
	private HyBidAdView banner;

	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadBanner;

	[SerializeField]
	private Button _buttonHideBanner;

	// Use this for initialization
	void Start ()
	{
		Console.WriteLine("START_BANNER");
		// banner = PNBannerFactory.createBanner (this);
		banner = HyBidAdViewFactory.createHyBidAdView (this);

		banner.appToken = appToken;
		banner.placement = placement;
		banner.AdViewListener = this;
		_buttonLoadBanner.onClick.AddListener (RequestBanner);
		_buttonHideBanner.onClick.AddListener (HideBanner);
	}

	private void RequestBanner ()
	{
		if (banner != null) {
			banner.Load (1);
		}
	}

	private void HideBanner ()
	{
		banner.Hide ();
	}

	public void OnAdLoaded ()
	{
		Console.WriteLine("###BANNER_LOADED_CALL_SHOW");
		banner.Show (Position.TOP);
	}

	public void OnAdLoadFailed (Exception error)
	{
		// Handle error
	}

    public void OnAdImpression ()
	{
		// Handle Impression
	}

    public void OnAdClick ()
	{
		// Handle Click
	}

}
