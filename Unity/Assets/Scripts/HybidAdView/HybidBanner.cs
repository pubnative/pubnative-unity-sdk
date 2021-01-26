using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HybidBanner : HybidAdView {

    public abstract void load();

	public abstract void show(Position position);
}