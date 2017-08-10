using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PNAd : MonoBehaviour
{
	protected const string LOAD_METHOD = "load";
	protected const string HIDE_METHOD = "hide";
	protected const string SHOW_METHOD = "show";

	public string appToken;
	public string placement;

	protected ILoadListener listener;

	public ILoadListener Listener {
		get {
			return this.listener;
		}
		set
		{
			this.listener = value;
		}
	}

	protected AndroidJavaObject layoutWrapper;

	public PNAd ()
	{
		layoutWrapper = new AndroidJavaObject (AndroidClassName ());
	}

	public abstract string AndroidClassName ();

	public void LoadListener (ILoadListener loadListener)
	{
		this.listener = loadListener;
	}
		
	private void OnPNLayoutLoadFinish (string message)
	{
		if (this.listener == null) {
			// Handle no listener set up
		} else {
			this.listener.LoadFinished ();
		}
	}

	private void OnPNLayoutLoadFailed (string message)
	{
		if (this.listener == null) {
			// Handle no listener set up
		} else {
			this.listener.LoadFailed (new Exception (message));
		}
	}
}