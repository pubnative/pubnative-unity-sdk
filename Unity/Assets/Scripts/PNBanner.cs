using System;

public abstract class PNBanner : PNAd
{
	public enum Position
	{
		TOP = 1,
		BOTTOM = 2
	}

	public abstract void Load ();

	public abstract void Show (Position position);

	public abstract void Hide ();
}

