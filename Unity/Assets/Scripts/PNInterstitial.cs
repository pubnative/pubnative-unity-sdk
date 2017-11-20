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
		if (this.viewListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.viewListener.OnShown ();
		}
	}

	protected virtual void OnPNLayoutViewHidden (string message)
	{
		if (this.viewListener != null && adID.Equals(message, StringComparison.Ordinal)) {
			this.viewListener.OnHidden ();
		}
	}
}

