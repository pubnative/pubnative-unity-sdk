using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HybidNative : MonoBehaviour ,IHyBidAdLoadListener
{

    private HyBidBanner banner;

	public string appToken;
	public string placement;

    [SerializeField]
	private Button _buttonLoadTop;

    [SerializeField]
	private Button _buttonLoadBottom;

    void Start()
    {
        banner = HyBidAdViewFactory.createHyBidAdView(this);
        // banner.appToken = appToken;
		// banner.placement = placement;
        // banner.loadListener = this;
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

    public void onInitialisationFinished(string message)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
