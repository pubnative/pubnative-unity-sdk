using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PNAd : MonoBehaviour
{
	public string appToken;
	public string placement;

	protected ILoadListener loadListener;
	protected ITrackListener trackListener;

	public ILoadListener LoadListener {
		get {
			return this.loadListener;
		}
		set {
			this.loadListener = value;
		}
	}

	public ITrackListener TrackListener {
		get {
			return this.trackListener;
		}
		set {
			this.trackListener = value;
		}
	}

	protected virtual void OnPNLayoutLoadFinish (string message)
	{
		if (this.loadListener == null) {
			// Handle no listener set up
		} else {
			this.loadListener.LoadFinished ();
		}
	}

	protected virtual void OnPNLayoutLoadFailed (string message)
	{
		if (this.loadListener == null) {
			// Handle no listener set up
		} else {
			this.loadListener.LoadFailed (new Exception (message));
		}
	}

	protected virtual void OnPNLayoutTrackImpression (string message)
	{
		if (this.trackListener == null) {
			// Handle no listener set up
		} else {
			this.trackListener.ImpressionTracked ();
		}
	}

	protected virtual void OnPNLayoutTrackClick (string message)
	{
		if (this.trackListener == null) {
			// Handle no listener set up
		} else {
			this.trackListener.ClickTracked ();
		}
	}
}
