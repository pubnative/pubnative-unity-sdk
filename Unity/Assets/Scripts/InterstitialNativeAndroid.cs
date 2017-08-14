using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialNativeAndroid : MonoBehaviour, ILoadListener
{
	private PNInterstitial interstitial;

	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadInterstitial;

	// Use this for initialization
	void Start ()
	{
		interstitial = this.gameObject.AddComponent<PNInterstitial> ();
		interstitial.appToken = appToken;
		interstitial.placement = placement;
		interstitial.Listener = this;
		_buttonLoadInterstitial.onClick.AddListener (RequestInterstitial);
	}

	private void RequestInterstitial ()
	{
		if (interstitial != null) {
			interstitial.Load();
		}
	}

	public void LoadFinished ()
	{
		interstitial.Show ();
	}

	public void LoadFailed (Exception error)
	{
		// Handle error
	}
}
