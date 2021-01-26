using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HybidAdView : MonoBehaviour
{
    public string appToken;
	public string placement;

	protected string adID = "";

    public IHybidAdLoadListener loadListener {
		get {
			return this.loadListener;
		}
		set {
			this.loadListener = value;
		}
	}

    public virtual void onHybidAdLoaded(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.onAdLoaded();
		}
    }

	public virtual void onHybidAdImpression(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			 this.loadListener.onAdImpression();
		}
    }

	public virtual void onHybidAdClicked(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			 this.loadListener.onAdClick();
		}
    }

	public virtual void onHybidAdError(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.onAdLoadFailed(new Exception("Failed to load Ad"));
		}
    }
}

public interface IHybidAdLoadListener
{
    void onAdLoaded();

    void onAdImpression();

	void onAdClick();

    void onAdLoadFailed(Exception error);
}