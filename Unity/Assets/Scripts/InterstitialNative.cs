using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialNative : MonoBehaviour, ILoadListener, ITrackListener, IViewListener
{
	private PNInterstitial interstitial;

	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadInterstitial;

	// Use this for initialization
	void Start ()
	{
		interstitial = PNInterstitialFactory.createInterstitial (this);

		interstitial.appToken = appToken;
		interstitial.placement = placement;
		interstitial.LoadListener = this;
		interstitial.TrackListener = this;
		interstitial.ViewListener = this;
		_buttonLoadInterstitial.onClick.AddListener (RequestInterstitial);
	}

	private void RequestInterstitial ()
	{
		if (interstitial != null) {
			interstitial.Load();
		}
	}

	public void OnLoadFinished ()
	{
		interstitial.Show ();
	}

	public void OnLoadFailed (Exception error)
	{
		// Handle error
	}

	public void OnImpressionTracked()
	{
		// Handle Impression
	}

	public void OnClickTracked ()
	{
		// Handle Click
	}

	public void OnShown ()
	{
		// Handle interstitial show
	}

	public void OnHidden ()
	{
		// Handle interstitial hide
	}
}
