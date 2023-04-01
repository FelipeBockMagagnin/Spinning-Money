using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonFunctions : MonoBehaviour
{
    public GameObject AboutPanel;
    public GameObject MoreGamesPanel;


    public void EnableAboutPanel()
    {
        AboutPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void DisableAboutPanel()
    {
        AboutPanel.GetComponent<Animator>().SetBool("active", false);
    }

    public void EnableMoreGamesPanel()
    {
        MoreGamesPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void DisableMoreGamesPanel()
    {
        MoreGamesPanel.GetComponent<Animator>().SetBool("active", false);
    }
}
