using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HybidNative : MonoBehaviour
{

	public string appToken;
	public string placement;

    [SerializeField]
	private Button _buttonLoadTop;

    [SerializeField]
	private Button _buttonLoadBottom;

    void Start()
    {
        _buttonLoadTop.onClick.AddListener (LoadTopAd);
        _buttonLoadBottom.onClick.AddListener (LoadBottomAd);
    }

    private void LoadTopAd ()
	{
	}

    private void LoadBottomAd ()
	{
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
