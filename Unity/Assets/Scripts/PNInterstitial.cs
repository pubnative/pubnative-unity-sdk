using System;

public abstract class PNInterstitial : PNAd
{
	protected IViewListener viewListener;

	public IViewListener ViewListener {
		get {
			return this.viewListener;
		}
		set {
			this.viewListener = value;
		}
	}

	public abstract void Load ();

	public abstract void Show ();

	public abstract void Hide ();

	protected virtual void OnPNLayoutViewShown (string message)
	{
		if (this.viewListener != null) {
			this.viewListener.OnShown ();
		}
	}

	protected virtual void OnPNLayoutViewHidden (string message)
	{
		if (this.viewListener != null) {
			this.viewListener.OnHidden ();
		}
	}
}

