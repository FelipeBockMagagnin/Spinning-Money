using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{

    public string _name;
    public double initialCost;
    public double initialRevenue;
    public double coefficient;
    public double productionMultiplicator;

    private double actualCost;
    public double actualRevenue;
    private double actualProductivity;

    public int numberOfItems;
    public Text buttonTxt;
    public Text numberOfItemsTxt;
    public GameObject announceTxt;
    public ActivementsAndRanking activementsAndRanking; 


    private void Start()
    {
        StartCoroutine(Production());
    }

    /// <summary>
    /// assign values to the valiables
    /// </summary>
    /// <param name="_numberOfItems"></param>
    public void StartGame(int _numberOfItems)
    {
        numberOfItems = _numberOfItems;
        setInitialMultiplycator();
        actualRevenue = (initialRevenue * _numberOfItems) * productionMultiplicator;

        if(numberOfItems == 0)
        {
            actualCost = initialCost;
        }
        else
        {
            setInitialActualcost();
        }        
    }

    /// <summary>
    /// set cost at start of the game
    /// </summary>
    void setInitialActualcost()
    {
        actualCost = initialCost;
        for(int x = 1; x <= numberOfItems; x++)
        {
            actualCost = actualCost * (Mathf.Pow(Convert.ToSingle(coefficient), x));
        }
    }

    /// <summary>
    /// product every 1 second
    /// </summary>
    /// <returns></returns>
    IEnumerator Production()
    {
        MoneyManager.Give(actualRevenue);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Production());
    }

    /// <summary>
    /// buy new item
    /// </summary>
    public void BuyItem()
    {
        if(MoneyManager.money >= actualCost)
        {
            ActivementsAndRanking.UpdateLeaderBoard();
            MoneyManager.Pay(actualCost);
            numberOfItems++;
            activementsAndRanking.GiveActivements(SetActivementString(), numberOfItems);
            UpgradeItem();
        }
        else
        {
            print("Sem Dinheiro para comprar o item: " + name);
        }        
    }

    /// <summary>
    /// change the name string just to match with activements
    /// </summary>
    /// <returns></returns>
    private String SetActivementString()
    {
        if(_name == "Pig Banks")
        {
            return "Pig";
        }
        else if(_name == "Pickpocket")
        {
            return "PickPocket";
        }
        else if (_name == "Investors")
        {
            return "Investor";
        }
        else if (_name == "Multiverses")
        {
            return "Multiverse";
        }
        else
        {
            return "";
        }
    }

    private void Update()
    {
        string moneyFormat = string.Format("{0:#,0.#}", actualCost);
        buttonTxt.text = moneyFormat;
        numberOfItemsTxt.text = numberOfItems.ToString();
        if(MoneyManager.money >= actualCost)
        {
            this.GetComponent<Button>().interactable = true;
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
        }
    }

    /// <summary>
    /// upgrade an item
    /// </summary>
    public void UpgradeItem()
    {
        setMultiply();
        actualCost = actualCost * (Mathf.Pow(Convert.ToSingle(coefficient), numberOfItems));
        actualRevenue = (initialRevenue * numberOfItems) * productionMultiplicator;
    }

    /// <summary>
    /// assign value to initial multiplicator at start of the game
    /// </summary>
    void setInitialMultiplycator()
    {
        int times = numberOfItems / 5;
        if(times == 0)
        {
            this.productionMultiplicator = 1;
        }
        else
        {
            this.productionMultiplicator = 1;
            for (int i = 1; i <= times; i++)
            {
                this.productionMultiplicator *= i * 2;                
            }
        }
    }

    /// <summary>
    /// set multiply during the buys in the game
    /// </summary>
    void setMultiply()
    {
        if (numberOfItems % 5 == 0)
        {            
            this.productionMultiplicator *= (numberOfItems/5)*2;
            ShowAnnounce((numberOfItems / 5) * 2);
        }
        
        if(numberOfItems == 0)
        {
            this.productionMultiplicator = 1;
        }
    }

    /// <summary>
    /// show announce of multiplicator achieved
    /// </summary>
    /// <param name="_productionGrow"></param>
    void ShowAnnounce(int _productionGrow)
    {
        announceTxt.GetComponent<Animator>().SetTrigger("ShowMessage");
        announceTxt.GetComponentInChildren<Text>().text = _name + " prodution multiplied by " + _productionGrow;
    }
}
