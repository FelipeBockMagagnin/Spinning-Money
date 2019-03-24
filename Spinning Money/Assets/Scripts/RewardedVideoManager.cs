using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class RewardedVideoManager : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    public OfflineTime offlineTime;

    public int coinMultiplyAd;

    //double coins ball manager
    public GameObject ball;
    public Transform spawnPosition;
    public GameObject actualBall;
    public GameObject doubleCoinsObjectsTxt;

    public double _time;
    public double timeWithMultiply;

    private void FixedUpdate()
    {
        _time -= Time.deltaTime;
        timeWithMultiply -= Time.deltaTime;
        Debug.Log("Time: " + _time);

        if (_time < 0)
        {
            SpawnDoubleCoinsBall();
        }
        
        if(timeWithMultiply >= 0)
        {
            doubleCoinsObjectsTxt.SetActive(true);
            doubleCoinsObjectsTxt.GetComponentInChildren<Text>().text = "All Money x2 per " + timeWithMultiply + " seconds";
            MoneyManager.AllmoneyMultiply = 2;
        }
        else
        {
            doubleCoinsObjectsTxt.SetActive(false);
            MoneyManager.AllmoneyMultiply = 1;
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider != null)
            {
                ClickOnDoubleCoinsBall();
            }
        }
    }

    public void SpawnDoubleCoinsBall()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            if(actualBall == null)
            {
                actualBall = Instantiate(ball, spawnPosition.position, Quaternion.identity);
                Destroy(actualBall, 60);
            }
            _time = 300;
            print("aaaa");
        }
        else
        {
            _time = 60;
        }
    }

    public void ClickOnDoubleCoinsBall()
    {
        Destroy(actualBall);
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            timeWithMultiply = 120;
        }
        else
        {
            RequestRewardBasedVideo();
        }
    }

    private void Awake()
    {
        _time = 120;
        timeWithMultiply = -1;
        coinMultiplyAd = 2;
    }


    // Start is called before the first frame update
    void Start()
    {
        


        #if UNITY_ANDROID
        string appid = "ca-app-pub-3940256099942544/5224354917";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        MobileAds.Initialize(appid);

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;




        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;



        RequestRewardBasedVideo();
    }

    /// <summary>
    /// Pede um anuncio para carregar e ficar em espera
    /// </summary>
    private void RequestRewardBasedVideo()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void UserOptWatchAdMultipliCoinsBegin()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
        else
        {
            RequestRewardBasedVideo();
            offlineTime.doubleCoinsButton.GetComponentInChildren<Text>().text = "No Ads Loaded :(";
            offlineTime.WhatAdAndDoubleEarnedCoins();
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        offlineTime.WhatAdAndDoubleEarnedCoins();
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
    }
}
