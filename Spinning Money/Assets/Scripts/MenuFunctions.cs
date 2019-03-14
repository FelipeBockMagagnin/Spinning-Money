using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject statsPanel;

    public void ActiveMenu()
    {
        menuPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void DisableMenu()
    {
        menuPanel.GetComponent<Animator>().SetBool("active", false);
    }

    public void ActiveStatsPanel()
    {
        statsPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void DisableStatsPanel()
    {
        statsPanel.GetComponent<Animator>().SetBool("active", false);
    }


}
