using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivementsAndRanking : MonoBehaviour
{
    public GameObject achButton;
    public GameObject ldrButton;

    public GooglePlayFunctions googlePlayFunctions;

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

    void TrySignIn()
    {
        googlePlayFunctions.TrySignIn();
    }

    public void GiveActivements(string name, int Level)
    {
        if (Social.localUser.authenticated)
        {
            switch (name)
            {
                case "Bag":
                    BagActimetents(Level);
                    break;
                case "Money":
                    MoneyActivements(Level);
                    break;
                case "Drop":
                    DropActivements(Level);
                    break;
                case "Rotation:":
                    RotationActivements(Level);
                    break;
                case "Pig":
                    PigBankActivements(Level);
                    break;
                case "PickPocket":
                    PickPocketActivements(Level);
                    break;
                case "Investor":
                    InvertorsActivements(Level);
                    break;
                case "Multiverse":
                    MultiverseActivements(Level);
                    break;
            }

        }
        else
        {
            googlePlayFunctions.TrySignIn();
        }
    }

    static void BagActimetents(int i)
    {
        switch (i)
        {
            case 2:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_goodbye_cute_pig, 100.0f, (bool success) => {});
                break;
            case 3:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_a_nice_pocket, 100.0f, (bool success) => { });
                break;
            case 4:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_what_has_at_the_end_of_the_rainbow, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_upgrade_the_space, 100.0f, (bool success) => { });
                break;
            case 6:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_wow, 100.0f, (bool success) => { });
                break;
        }
    }

    static void MoneyActivements(int i)
    {
        switch (i)
        {
            case 2:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_make_me_rich, 100.0f, (bool success) => { });
                break;
            case 3:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_upgrade_the_incoming, 100.0f, (bool success) => { });
                break;
            case 4:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_golddd, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_aaaaaaaaa, 100.0f, (bool success) => { });
                break;
        }
    }

    static void DropActivements(int i)
    {
        switch (i)
        {
            case 2:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_more_drop_more_money, 100.0f, (bool success) => { });
                break;
            case 3:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_more_drop_more_money_2, 100.0f, (bool success) => { });
                break;
            case 4:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_i_need_that_much_money, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_i_need_that_much_money_2, 100.0f, (bool success) => { });
                break;
        }
    }

    static void RotationActivements(int i)
    {
        switch (i)
        {
            case 2:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_spinning, 100.0f, (bool success) => { });
                break;
            case 3:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_spinninggg, 100.0f, (bool success) => { });
                break;
            case 4:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_spinninggggg, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_spinninggggggg, 100.0f, (bool success) => { });
                break;
        }
    }

    static void PigBankActivements(int i)
    {
        switch (i)
        {
            case 1:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_starting_a_farm, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_little_farm, 100.0f, (bool success) => { });
                break;
            case 10:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_average_farm, 100.0f, (bool success) => { });
                break;
            case 15:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_big_farm, 100.0f, (bool success) => { });
                break;
            case 20:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_super_big_farm, 100.0f, (bool success) => { });
                break;
            case 25:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_unnecessarily_big_farm, 100.0f, (bool success) => { });
                break;
            case 30:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_why_so_big, 100.0f, (bool success) => { });
                break;
        }
    }

    static void PickPocketActivements(int i)
    {
        switch (i)
        {
            case 1:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_beginning_of_career, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_specializing, 100.0f, (bool success) => { });
                break;
            case 10:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_creating_a_small_team, 100.0f, (bool success) => { });
                break;
            case 15:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_creating_a_medium_team, 100.0f, (bool success) => { });
                break;
            case 20:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_creating_a_big_team, 100.0f, (bool success) => { });
                break;
            case 25:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_creating_a_very_big_team, 100.0f, (bool success) => { });
                break;
            case 30:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_why_so_big_2, 100.0f, (bool success) => { });
                break;
        }
    }

    static void InvertorsActivements(int i)
    {
        switch (i)
        {
            case 1:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_starting_a_company, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_small_company, 100.0f, (bool success) => { });
                break;
            case 10:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_medium_company, 100.0f, (bool success) => { });
                break;
            case 15:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_big_company, 100.0f, (bool success) => { });
                break;
            case 20:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_super_big_company, 100.0f, (bool success) => { });
                break;
            case 25:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_multinational_company, 100.0f, (bool success) => { });
                break;
            case 30:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_why_so_big_3, 100.0f, (bool success) => { });
                break;
        }
    }

    static void MultiverseActivements(int i)
    {
        switch (i)
        {
            case 1:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_stating_the_universe, 100.0f, (bool success) => { });
                break;
            case 5:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_small_multiverse, 100.0f, (bool success) => { });
                break;
            case 10:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_medium_multiverse, 100.0f, (bool success) => { });
                break;
            case 15:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_big_multiverse, 100.0f, (bool success) => { });
                break;
            case 20:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_super_big_multiverse, 100.0f, (bool success) => { });
                break;
            case 25:
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_why_so_big_4, 100.0f, (bool success) => { });
                break;
        }
    }

}


