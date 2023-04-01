using System.Collections;
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

        if (PlayerPrefs.HasKey("Money"))
        {
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
        }
        else
        {
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }        
    }

    /// <summary>
    /// Sign in to the google play
    /// </summary>
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

    /// <summary>
    /// Verify if the user is logged
    /// </summary>
    /// <param name="success"></param>
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
