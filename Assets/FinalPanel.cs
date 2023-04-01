using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanel : MonoBehaviour
{
    public GameObject finalPanel;

    public void Open()
    {
        finalPanel.GetComponent<Animator>().SetBool("open", true);
    }

    public void Close()
    {
        finalPanel.GetComponent<Animator>().SetBool("open", false);
    }
}
