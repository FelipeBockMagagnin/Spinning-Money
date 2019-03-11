using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButtonManager : MonoBehaviour
{
    [Header("Bag Level")]
    public Button bagLevelbutton;
    public int startBagLevel;
    public int actualBagLevel;

    [Header("Money Level")]
    public Button moneyLevelbutton;
    public int startMoneyLevel;
    public int actualMoneyLevel;

    [Header("Money Quantity Level")]
    public Button moneyQuantitybutton;
    public int startMoneyQuantityLevel;
    public int actualMoneyQuantityLevel;

    [Header("Rotation Level")]
    public Button rotationLevelbutton;
    public int startRotationLevel;
    public int actualRotationLevel;

    public BagManager bagManager;


    private void Start()
    {
        LoadLevels();
        StartComponents();
        bagManager.setBagAtributes();
    }

    void StartComponents()
    {
        actualBagLevel = startBagLevel;
        bagManager.bagLevel = startBagLevel;

        actualMoneyLevel = startMoneyLevel;
        bagManager.moneyLevel = startMoneyLevel;

        actualMoneyQuantityLevel = startMoneyQuantityLevel;
        bagManager.moneyQuantityLevel = startMoneyQuantityLevel;

        actualRotationLevel = startRotationLevel;
        bagManager.rotationLevel = startRotationLevel;
    }

    void LoadLevels()
    {
        startBagLevel = 1;
        startMoneyLevel = 1;
        startMoneyQuantityLevel = 1;
        startRotationLevel = 1;
    }

    private void FixedUpdate()
    {
        SetTextButtons();
    }

    void SetTextButtons()
    {
        bagLevelbutton.GetComponentInChildren<Text>().text = "Bag Upgrade - Lvl " + actualBagLevel.ToString();
        moneyLevelbutton.GetComponentInChildren<Text>().text = "Money Upgrade - Lvl " + actualMoneyLevel.ToString();
        moneyQuantitybutton.GetComponentInChildren<Text>().text = "Money Quantity Upgrade - Lvl " + actualMoneyQuantityLevel.ToString();
        rotationLevelbutton.GetComponentInChildren<Text>().text = "Rotation Upgrade - Lvl " + actualRotationLevel.ToString();
    }

    public void BuyButton(string name)
    {
        if(name == "bag upgrade")
        {
            float priceBag = actualBagLevel * 1000;
            if(MoneyManager.money >= priceBag && actualBagLevel < 6)
            {
                actualBagLevel++;
                bagManager.bagLevel = actualBagLevel;
                bagManager.setBagAtributes();
                MoneyManager.Pay(priceBag);
                Debug.Log("Comprou bag upgrade, nivel atual: " + actualBagLevel);
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "money upgrade")
        {
            float priceMoney = actualMoneyLevel * 1000;
            if(MoneyManager.money >= priceMoney && actualMoneyLevel < 5)
            {
                actualMoneyLevel++;
                bagManager.moneyLevel = actualMoneyLevel;
                bagManager.setBagAtributes();
                MoneyManager.Pay(priceMoney);
                Debug.Log("Comprou money upgrade, nivel atual: " + actualMoneyLevel);
            } 
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "money quantity upgrade")
        {
            float priceMoneyQuantity = actualMoneyQuantityLevel * 1000;
            if (MoneyManager.money >= priceMoneyQuantity && actualMoneyQuantityLevel < 5)
            {
                actualMoneyQuantityLevel++;
                bagManager.moneyQuantityLevel = actualMoneyQuantityLevel;
                bagManager.setBagAtributes();
                MoneyManager.Pay(priceMoneyQuantity);
                Debug.Log("Comprou money quantity upgrade, nivel atual: " + actualMoneyQuantityLevel);
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "rotation upgrade")
        {
            float priceRotation = actualRotationLevel * 1000;
            if (MoneyManager.money >= priceRotation && actualRotationLevel < 5)
            {
                actualRotationLevel++;
                bagManager.rotationLevel = actualRotationLevel;
                bagManager.setBagAtributes();
                MoneyManager.Pay(priceRotation);
                Debug.Log("Comprou Rotation upgrade, nivel atual: " + actualRotationLevel);
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }




    }



}