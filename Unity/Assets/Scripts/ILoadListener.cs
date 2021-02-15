using System;

public interface ILoadListener
{
	void OnLoadFinished ();

	void OnLoadFailed (Exception error);
}