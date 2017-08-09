using System;

public interface ILoadListener
{
	void LoadFinished ();

	void LoadFailed (Exception error);
}