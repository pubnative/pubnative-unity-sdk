using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HybidAd : MonoBehaviour
{
    public string appToken;
	public string placement;

	protected string adID = "";

    protected int position = 0;

    public IHybidAdLoadListener loadListener {
		get {
			return this.loadListener;
		}
		set {
			this.loadListener = value;
		}
	}
    public IAuctionListener auctionListener {
		get {
			return this.auctionListener;
		}
		set {
			this.auctionListener = value;
		}
	}

    public IRequestManagerListener requestManagerListener {
		get {
			return this.requestManagerListener;
		}
		set {
			this.requestManagerListener = value;
		}
	}

    public string AdId {
		get {
			return this.adID;
		}
		set {
			this.adID = value;
		}
	}

    public string position {
		get {
			return this.position;
		}
		set {
			this.position = value;
		}
	}

    public virtual void onRequestManagerSuccess(string message){
        if (this.requestManagerListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.requestManagerListener.onRequestSuccess();
		}
    }

    public virtual void onRequestManagerFail(string message){
        if (this.requestManagerListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.requestManagerListener.onRequestFail(new Exception("Ad failed to load"));
		}
    }

    public virtual void onHybidAdLoaded(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.onAdLoaded();
            this.loadListener.onAdImpression();
		}
    }

    public virtual void onHybidAdClicked(string message){
        if (this.loadListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.loadListener.onAdClick();
		}
    }

    public virtual void onAuctionSuccess(string message){
        if (this.auctionListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.auctionListener.onAuctionSuccess();
		}
    }

     public virtual void onAuctionFailure(string message){
        if (this.auctionListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.auctionListener.onAuctionFailure(new Exception("Failed to load"));
		}
    }
}

public interface IHybidAdLoadListener
{
    void onAdLoaded();

    void onAdImpression();

    void onAdLoadFailed(Exception error);

    void onAdImpression();

    void onAdClick();
}

public interface IAuctionListener
{
    void onAuctionSuccess();

    void onAuctionFailure(Exception error);
}

public interface IRequestManagerListener
{
    void onRequestSuccess();

    void onRequestFail(Exception error);
}