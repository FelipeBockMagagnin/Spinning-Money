using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviewPanel : MonoBehaviour
{
    public GameObject reviewPanel;

    public void  activeReview()
    {
        reviewPanel.GetComponent<Animator>().SetBool("open", true);    
    }

    public void  disableReview()
    {
        reviewPanel.GetComponent<Animator>().SetBool("open", false);    
    }

    public void Rate()
    {
        disableReview();
        Application.OpenURL("market://details?id=com.DotCompany.SpinningMoney");
    }
}
