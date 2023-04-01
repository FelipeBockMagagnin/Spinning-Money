using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsPanelUIManager : MonoBehaviour
{
    public GameObject upgradesPanel;
    public GameObject investorsPanel;
    public GameObject utilitiesPanel;

    void Start()
    {
        upgradesPanel.SetActive(true);
        investorsPanel.SetActive(false);
        utilitiesPanel.SetActive(false);
    }

    public void ShowUpgradesPanel() {
        upgradesPanel.SetActive(true);
        investorsPanel.SetActive(false);
        utilitiesPanel.SetActive(false);
    }

    public void ShowInvestorsPanel() {
        upgradesPanel.SetActive(false);
        investorsPanel.SetActive(true);
        utilitiesPanel.SetActive(false);
    }

    public void ShowUtilitiesPanel() {
        upgradesPanel.SetActive(false);
        investorsPanel.SetActive(false);
        utilitiesPanel.SetActive(true);
    }
}
