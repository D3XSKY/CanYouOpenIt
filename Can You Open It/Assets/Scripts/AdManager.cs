using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Unity Ads initialized: " + Advertisement.isInitialized);
        Debug.Log("Unity Ads is supported: " + Advertisement.isSupported);
        Debug.Log("Unity Ads test mode enabled: " + Advertisement.testMode);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowVideoAd(Action<ShowResult> adCallBackAction = null, string zone = "")
    {

        StartCoroutine(WaitForAdEditor());

        if (string.IsNullOrEmpty(zone))
        {
            zone = null;
        }

        var options = new ShowOptions();

        if (adCallBackAction == null)
        {
            options.resultCallback = DefaultAdCallBackHandler;
        }
        else
        {
            options.resultCallback = adCallBackAction;
        }

        if (Advertisement.IsReady(zone))
        {
            Debug.Log("Showing ad for zone: " + zone);
            Advertisement.Show(zone, options);
        }
        else
        {
            Debug.LogWarning("Ad was not ready. Zone: " + zone);
        }
    }
    private void DefaultAdCallBackHandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Time.timeScale = 1f;
                break;

            case ShowResult.Failed:
                Time.timeScale = 1f;
                break;

            case ShowResult.Skipped:
                Time.timeScale = 1f;
                break;
        }
    }
    public void ShowStandardVideoAd()
    {
        ShowVideoAd();
    }
}
