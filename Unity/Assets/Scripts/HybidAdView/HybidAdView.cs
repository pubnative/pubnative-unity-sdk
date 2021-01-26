using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HybidAdView : HybidAd {

    public abstract void Load ();

	public abstract void show (Position position);
}