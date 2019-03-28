using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivementsAndRanking : MonoBehaviour
{


    public GameObject achButton;
    public GameObject ldrButton;



    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Cannot show Achievements, not logged in");
        }
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }

    public void Update()
    {
        ldrButton.SetActive(Social.localUser.authenticated);
        achButton.SetActive(Social.localUser.authenticated);
    }
}
