using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialNative : MonoBehaviour, IInterstitialListener
{
	private HyBidInterstitialAd interstitial;

	private bool isLoading;
	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadInterstitial;

	// Use this for initialization
	void Start ()
	{
		interstitial = HyBidInterstitialAdFactory.createInterstitialAd (this);

		interstitial.appToken = appToken;
		interstitial.placement = placement;
		interstitial.InterstitialListener = this;
		_buttonLoadInterstitial.onClick.AddListener (RequestInterstitial);
	}

	private void RequestInterstitial ()
	{
		if (interstitial != null && !isLoading) {
			isLoading = true;
			interstitial.Load();
		}
	}


	public void OnInterstitialLoaded ()
	{
		isLoading = false;
		interstitial.Show ();
	}

	public void OnInterstitialLoadFailed (Exception error)
	{
		isLoading = false;
		// Handle error
	}

	public void OnInterstitialImpression ()
	{
		// Handle Impression
	}

	public void OnInterstitialClick ()
	{
		// Handle click
	}

	public void OnInterstitialDismissed ()
	{
		// Handle dismissed
	}
	
}