﻿using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GooglePlayFunctions : MonoBehaviour
{

    public Text signInButtonText;

    private void Start()
    {
        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    public void SignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            signInButtonText.text = "Sign In";
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Signed in!");

            // Change sign-in button text
            signInButtonText.text = "Sign out";
        }
        else
        {
            Debug.Log("Sign-in failed...");

            // Show failure message
            signInButtonText.text = "Sign in";
        }
    }


}
