﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class RewardedVideoManager : MonoBehaviour
{

    public static bool AdsEnabled;

    
    private RewardBasedVideoAd rewardBasedVideo;
    public OfflineTime offlineTime;
    
    public int coinMultiplyAd;

    //double coins ball manager
    public GameObject ball;
    public Transform spawnPosition;
    public GameObject actualBall;
    public GameObject doubleCoinsObjectsTxt;

    private double _time;
    private double timeWithMultiply;


    public GameObject AdsButton;

    private void FixedUpdate()
    {
        _time -= Time.deltaTime;
        timeWithMultiply -= Time.deltaTime;

        if (_time < 0)
        {
            SpawnDoubleCoinsBall();
        }

        if (timeWithMultiply >= 0)
        {
            doubleCoinsObjectsTxt.SetActive(true);
            doubleCoinsObjectsTxt.GetComponentInChildren<Text>().text = "All Money x2 per " + timeWithMultiply.ToString("0.0") + " seconds";
            MoneyManager.AllmoneyMultiply = 2;
        }
        else
        {
            doubleCoinsObjectsTxt.SetActive(false);
            MoneyManager.AllmoneyMultiply = 1;
        }

        FreeCoinsCount();
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
        if (AdsEnabled == true)
        {
            if (rewardBasedVideo.IsLoaded())
            {
                if (actualBall == null)
                {
                    actualBall = Instantiate(ball, spawnPosition.position, Quaternion.identity);
                    Destroy(actualBall, 20);
                }
                _time = 240;
            }
            else
            {
                print("Failed to load Ad");
                RequestRewardBasedVideo();
                _time = 20;
            }
        }
        else
        {
            if (actualBall == null)
            {
                actualBall = Instantiate(ball, spawnPosition.position, Quaternion.identity);
                Destroy(actualBall, 20);
            }
            _time = 240;
        }
    }

    public void ClickOnDoubleCoinsBall()
    {
        Destroy(actualBall);
        if (AdsEnabled)
        {
            if (rewardBasedVideo.IsLoaded())
            {
                rewardBasedVideo.Show();
                timeWithMultiply = 120;
            }
            else
            {
                timeWithMultiply = 120;
                RequestRewardBasedVideo();
            }
        }
        else
        {
            timeWithMultiply = 120;
        }
    }

    public GameObject FreeCoinsPanel;
    public GameObject FreeCoinsButton;
    public Text FreeCoinPanelTxt;
    public double TimeFreeCoins;

    public void UserOptWhatAdFreeCoins()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            TimeFreeCoins = 180;
        }
        else
        {
            TimeFreeCoins = 180;
            RequestRewardBasedVideo();
        }
    }

    private void GiveFreeCoins()
    {
        CloseButtonFreeMoney();
        openFreeCoinsPanel();
        MoneyManager.Give(MoneyManager.TotalMPS * 90);
        FreeCoinPanelTxt.text = "You received: " + MoneyManager.TotalMPS * 120 * MoneyManager.AllmoneyMultiply + " coins :)";
    }

    private void CloseButtonFreeMoney()
    {
        FreeCoinsButton.GetComponent<Animator>().SetBool("active", false);
    }

    public void closeFreeMoneyPanel()
    {
        FreeCoinsPanel.GetComponent<Animator>().SetBool("active", false);
        TimeFreeCoins = 150;
    }

    private void openFreeCoinsPanel()
    {
        FreeCoinsPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void ClickOnFreeCoinButton()
    {
        if (AdsEnabled == true)
        {
            UserOptWhatAdFreeCoins();
        }
        GiveFreeCoins();
    }

    void FreeCoinsCount()
    {
        if(TimeFreeCoins > 0)
        {
            TimeFreeCoins -= Time.deltaTime;
        }
        else
        {
            if (AdsEnabled == true)
            {
                if (rewardBasedVideo.IsLoaded())
                {
                    FreeCoinsButton.GetComponent<Animator>().SetBool("active", true);
                }
                else
                {
                    TimeFreeCoins = 30;
                    RequestRewardBasedVideo();
                }
            }
            else
            {
                FreeCoinsButton.GetComponent<Animator>().SetBool("active", true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("ADS"))
        {
            if (PlayerPrefs.GetInt("ADS") == 1)
            {
                AdsEnabled = false;
                AdsButton.SetActive(false);
            }
            else
            {
                AdsEnabled = true;
                AdsButton.SetActive(true);
            }
        }
        else
        {
            AdsEnabled = true;
            AdsButton.SetActive(true);
        }

        Debug.Log("Ads: " + PlayerPrefs.GetInt("ADS"));

        _time = 80;
        TimeFreeCoins = 160;
        timeWithMultiply = -1;
        coinMultiplyAd = 2;

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

        if (AdsEnabled == true)
        {
            RequestRewardBasedVideo();
        }
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
        if (AdsEnabled == true)
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
        else
        {
            offlineTime.doubleCoinsButton.GetComponentInChildren<Text>().text = ":)";
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