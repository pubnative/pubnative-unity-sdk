using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HyBidAdView : MonoBehaviour
{
    public string appToken;
	public string placement;

	protected string adID = "";

    public virtual void OnHyBidAdLoaded(string message){
        if (String.Equals(adID, message, StringComparison.OrdinalIgnoreCase)) {
			//Do HyBidAdView load stuff
		}
    }

	public virtual void OnHyBidAdImpression(string message){
        if (String.Equals(adID, message, StringComparison.OrdinalIgnoreCase)) {
			//Do HyBidAdView Impression stuff
		}
    }

	public virtual void OnHyBidAdClicked(string message){
        if (String.Equals(adID, message, StringComparison.OrdinalIgnoreCase)) {
			//Do HyBidAdView click stuff
		}
    }

	public virtual void OnHyBidAdError(string message){
        if (String.Equals(adID, message, StringComparison.OrdinalIgnoreCase)) {
			//Do HyBidAdView Error stuff
		}
    }
}