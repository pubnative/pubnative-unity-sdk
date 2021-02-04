using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HybidAdViewMonoBehaviour : MonoBehaviour ,IHyBidAdLoadListener
{
    // Start is called before the first frame update

    private HyBidBanner banner;

	public string appToken;
	public string placement;

	[SerializeField]
	private Button _buttonLoadBannerTop;

    [SerializeField]
	private Button _buttonLoadBannerBottom;

    void Start()
    {
        banner = HyBidAdViewFactory.createHyBidAdView(this);
        banner.appToken = appToken;
		banner.placement = placement;
        banner.loadListener = this;
        _buttonLoadBannerTop.onClick.AddListener (showTopBanner);
        _buttonLoadBannerBottom.onClick.AddListener (showBottomBanner);
    }   

    private void showTopBanner ()
	{
		if (banner != null) {
			banner.load(1);
		}
	}

    private void showBottomBanner ()
	{
		if (banner != null) {
			banner.load(0);
		}
	}

    public void OnHyBidAdLoaded()
    {
        
    }

    public void OnHyBidAdImpression()
    {

    }

    
	public void OnHyBidAdClick()
    {

    }

    public void OnHyBidAdLoadFailed(Exception error)
    {

    }
}
