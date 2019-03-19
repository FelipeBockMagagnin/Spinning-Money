using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButtonManager : MonoBehaviour
{
    [Header("Bag Level")]
    public Text bagPricetxt;
    public Text baglevelTxt;
    [HideInInspector]
    public int startBagLevel;
    [HideInInspector]
    public int actualBagLevel;
    public double[] bagValues;

    [Header("Money Level")]
    public Text moneyPricetxt;
    public Text moneylevelTxt;
    [HideInInspector]
    public int startMoneyLevel;
    [HideInInspector]
    public int actualMoneyLevel;
    public double[] moneyValues;

    [Header("Money Quantity Level")]
    public Text moneyQuantityPricetxt;
    public Text moneyQuantityleveltxt;
    [HideInInspector]
    public int startMoneyQuantityLevel;
    [HideInInspector]
    public int actualMoneyQuantityLevel;
    public double[] moneyQuantityValues;

    [Header("Rotation Level")]
    public Text rotationPricetxt;
    public Text rotationlevelTxt;
    [HideInInspector]
    public int startRotationLevel;
    [HideInInspector]
    public int actualRotationLevel;
    public double[] rotationValues;

    public BagManager bagManager;


    public AudioSource cashSound;


    public GameObject ParticleSystemEvolution;

    public void StartGame(int _baglevel, int _moneylevel, int _moneyQuantitylevel, int _rotationlevel)
    {
        actualBagLevel = _baglevel;
        actualMoneyLevel = _moneylevel;
        actualMoneyQuantityLevel = _moneyQuantitylevel;
        actualRotationLevel = _rotationlevel;

        bagManager.SetLevels(_baglevel, _moneylevel, _moneyQuantitylevel, _rotationlevel);

        bagManager.setBagAtributes();

        SetTextButtons();
    }


    void SetTextButtons()
    {
        if(actualBagLevel == 6)
        {
            bagPricetxt.text = "Max Lvl";
            baglevelTxt.text = actualBagLevel.ToString();
        }
        else
        {
            bagPricetxt.text = bagValues[actualBagLevel - 1].ToString();
            baglevelTxt.text = actualBagLevel.ToString();
        }


        if (actualMoneyLevel == 5)
        {
            moneyPricetxt.text = "Max Lvl";
            moneylevelTxt.text = actualMoneyLevel.ToString();
        }
        else
        {
            moneyPricetxt.text = moneyValues[actualMoneyLevel - 1].ToString();
            moneylevelTxt.text = actualMoneyLevel.ToString();
        }

        if (actualMoneyQuantityLevel == 5)
        {
            moneyQuantityleveltxt.text = actualMoneyQuantityLevel.ToString();
            moneyQuantityPricetxt.text = "Max Lvl";
        }
        else
        {
            moneyQuantityPricetxt.text = moneyQuantityValues[actualMoneyQuantityLevel - 1].ToString();
            moneyQuantityleveltxt.text = actualMoneyQuantityLevel.ToString();
        }


        if (actualRotationLevel == 5)
        {
            rotationPricetxt.text = "Max Lvl";
            rotationlevelTxt.text = actualRotationLevel.ToString();
        }
        else
        {
            rotationPricetxt.text = rotationValues[actualRotationLevel - 1].ToString();
            rotationlevelTxt.text = actualRotationLevel.ToString();
        }        
    }

    public void PlayCashSound()
    {
        cashSound.Play();
    }

    public void InstantiateParticleEvolution()
    {
        Instantiate(ParticleSystemEvolution, new Vector3(0, 0.33f, 0), Quaternion.identity);
    }

    public void BuyButton(string name)
    {
        if (name == "bag upgrade")
        {
            if(MoneyManager.money >= bagValues[actualBagLevel - 1] && actualBagLevel < 6)
            {
                MoneyManager.Pay(bagValues[actualBagLevel - 1]);
                actualBagLevel++;
                bagManager.bagLevel = actualBagLevel;
                bagManager.setBagAtributes();                
                Debug.Log("Comprou bag upgrade, nivel atual: " + actualBagLevel);
                MoneyManager.GrowMultiply(actualBagLevel);
                PlayCashSound();
                InstantiateParticleEvolution();
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "money upgrade")
        {
            if(MoneyManager.money >= moneyValues[actualMoneyLevel - 1] && actualMoneyLevel < 5)
            {
                MoneyManager.Pay(moneyValues[actualMoneyLevel - 1]);
                actualMoneyLevel++;
                bagManager.moneyLevel = actualMoneyLevel;
                bagManager.setBagAtributes();
                MoneyManager.GrowMultiply(actualMoneyLevel);
                Debug.Log("Comprou money upgrade, nivel atual: " + actualMoneyLevel);
                InstantiateParticleEvolution();
                PlayCashSound();
            } 
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "money quantity upgrade")
        {
            if (MoneyManager.money >= moneyQuantityValues[actualMoneyQuantityLevel - 1] && actualMoneyQuantityLevel < 5)
            {
                MoneyManager.Pay(moneyQuantityValues[actualMoneyQuantityLevel - 1]);
                actualMoneyQuantityLevel++;
                bagManager.moneyQuantityLevel = actualMoneyQuantityLevel;
                bagManager.setBagAtributes();
                MoneyManager.GrowMultiply(actualMoneyQuantityLevel);
                Debug.Log("Comprou money quantity upgrade, nivel atual: " + actualMoneyQuantityLevel);
                InstantiateParticleEvolution();
                PlayCashSound();
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "rotation upgrade")
        {
            if (MoneyManager.money >= rotationValues[actualRotationLevel - 1] && actualRotationLevel < 5)
            {
                MoneyManager.Pay(rotationValues[actualRotationLevel - 1]);
                actualRotationLevel++;
                bagManager.rotationLevel = actualRotationLevel;
                bagManager.setBagAtributes();
                MoneyManager.GrowMultiply(actualRotationLevel);
                Debug.Log("Comprou Rotation upgrade, nivel atual: " + actualRotationLevel);
                InstantiateParticleEvolution();
                PlayCashSound();
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        SetTextButtons();
    }



}