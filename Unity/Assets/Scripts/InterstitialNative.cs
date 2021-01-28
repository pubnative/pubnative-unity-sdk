using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialNative : MonoBehaviour, IInterstitialListener, IRewardedListener
{
	private HyBidInterstitialAd interstitial;
	private HyBidRewardedAd rewarded;

	private bool isInterstitialLoading;
	private bool isRewardedLoading;

	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadInterstitial;

	[SerializeField]
	private Button _buttonLoadRewarded;

	// Use this for initialization
	void Start ()
	{
		interstitial = HyBidInterstitialAdFactory.createInterstitialAd (this);

		interstitial.appToken = appToken;
		interstitial.placement = placement;
		interstitial.InterstitialListener = this;
		_buttonLoadInterstitial.onClick.AddListener (RequestInterstitial);
		_buttonLoadRewarded.onClick.AddListener (RequestRewarded);
	}

	private void RequestInterstitial ()
	{
		if (interstitial != null && !isInterstitialLoading) {
			isInterstitialLoading = true;
			interstitial.Load();
		}
	}

	private void RequestRewarded ()
	{
		if (rewarded != null && !isRewardedLoading) {
			isRewardedLoading = true;
			rewarded.Load();
		}
	}

	// Interstitial Listeners
	public void OnInterstitialLoaded ()
	{
		isInterstitialLoading = false;
		interstitial.Show ();
	}

	public void OnInterstitialLoadFailed (Exception error)
	{
		isInterstitialLoading = false;
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

	// Rewarded Listeners
	public void OnRewardedLoaded ()
	{
		isRewardedLoading = false;
		rewarded.Show ();
	}

	public void OnRewardedLoadFailed (Exception error)
	{
		isInterstitialLoading = false;
		// Handle error
	}

	public void OnRewardedOpened ()
	{
		// Handle opened
	}

	public void OnRewardedClick ()
	{
		// Handle click
	}

	public void OnRewardedClosed ()
	{
		// Handle closed
	}

	public void onReward ()
	{
		// Handle onReward
	}
	
}