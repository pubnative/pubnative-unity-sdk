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
	private Button _buttonLoadBanner;

    void Start()
    {
        banner = HyBidAdViewFactory.createHyBidAdView(this);
        banner.appToken = appToken;
		banner.placement = placement;
        banner.loadListener = this;
        _buttonLoadBanner.onClick.AddListener (RequestBanner);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestBanner ()
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
