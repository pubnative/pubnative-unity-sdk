using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PNAd : MonoBehaviour
{
	public string appToken;
	public string placement;

	protected ILoadListener listener;

	public ILoadListener Listener {
		get {
			return this.listener;
		}
		set {
			this.listener = value;
		}
	}

	public void LoadListener (ILoadListener loadListener)
	{
		this.listener = loadListener;
	}

	protected virtual void OnPNLayoutLoadFinish (string message)
	{
		if (this.listener == null) {
			// Handle no listener set up
		} else {
			this.listener.LoadFinished ();
		}
	}

	protected virtual void OnPNLayoutLoadFailed (string message)
	{
		if (this.listener == null) {
			// Handle no listener set up
		} else {
			this.listener.LoadFailed (new Exception (message));
		}
	}
}
