using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class HybidNative : MonoBehaviour
{

    private HyBidBanner banner;
    private bool isBannerLoading;

	public string appToken;
	public string placement;

    [SerializeField]
	private Button _buttonLoadTop;

    [SerializeField]
	private Button _buttonLoadBottom;

    void Start()
    {
        banner = HyBidAdViewFactory.createHyBidAdView(this);
        banner.appToken = appToken;
		banner.placement = placement;
        _buttonLoadTop.onClick.AddListener (LoadTopAd);
        _buttonLoadBottom.onClick.AddListener (LoadBottomAd);
    }

    private void LoadTopAd ()
	{
        if (banner != null) {
			banner.load(1);
		}
	}

    private void LoadBottomAd ()
	{
        if (banner != null) {
			banner.load(2);
		}
	}
}
