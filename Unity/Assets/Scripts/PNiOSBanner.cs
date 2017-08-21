using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNiOSBanner : MonoBehaviour
{
	public enum Position
	{
		TOP = 1,
		BOTTOM = 2
	}

	public string appToken;
	public string placement;

	protected ILoadListener listener;

	public PNiOSBanner ()
	{
	}

	public void Load ()
	{
	}

	public void Show (Position position)
	{
		int positionValue = (int)position;
	}

	public void Hide ()
	{
	}
		
	public ILoadListener Listener {
		get {
			return this.listener;
		}
		set
		{
			this.listener = value;
		}
	}

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

