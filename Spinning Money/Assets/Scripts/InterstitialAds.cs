using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class InterstitialAds : MonoBehaviour
{
    private InterstitialAd interstitial;
    private float initialWaitTime = 210;
    private float normalWaitTime = 145;
    private float failedWaitTime = 22;

    private void Start()
    {
        RequestInterstitial();
        TimeUntilNextAd = initialWaitTime;
    }

    /// <summary>
    /// Request ad to show
    /// </summary>
    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();


        if (RewardedVideoManager.AdsEnabled == true)
        {
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }
    }

    /// <summary>
    /// Show the ad loaded
    /// </summary>
    public void ShowInterstitalAd()
    {
        if (RewardedVideoManager.AdsEnabled == true)
        {
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
                TimeUntilNextAd = normalWaitTime;
            }
            else
            {
                RequestInterstitial();
                TimeUntilNextAd = failedWaitTime;
            }
        }
        else
        {
            TimeUntilNextAd = 1000;
        }
    }

    private double TimeUntilNextAd;
    private void FixedUpdate()
    {
        if (TimeUntilNextAd > 0)
        {
            TimeUntilNextAd -= Time.deltaTime;
        }
        else
        {
            ShowInterstitalAd();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}