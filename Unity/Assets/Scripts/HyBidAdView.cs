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

    public IHyBidAdLoadListener loadListener {
		get {
			return this.loadListener;
		}
		set {
			this.loadListener = value;
		}
	}

    public virtual void OnHyBidAdLoaded(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.OnHyBidAdLoaded();
		}
    }

	public virtual void OnHyBidAdImpression(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			 this.loadListener.OnHyBidAdImpression();
		}
    }

	public virtual void OnHyBidAdClicked(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			 this.loadListener.OnHyBidAdClick();
		}
    }

	public virtual void OnHyBidAdError(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.OnHyBidAdLoadFailed(new Exception("Failed to load Ad"));
		}
    }
}

public interface IHyBidAdLoadListener
{
    void OnHyBidAdLoaded();

    void OnHyBidAdImpression();

	void OnHyBidAdClick();

    void OnHyBidAdLoadFailed(Exception error);
}