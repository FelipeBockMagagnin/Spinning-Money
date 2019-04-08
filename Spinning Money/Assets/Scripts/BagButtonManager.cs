using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButtonManager : MonoBehaviour
{
    ///BAG LEVEL UPGRADES
    [Header("Bag Level")]
    public Text bagPricetxt;
    public Text baglevelTxt;    
    public double[] bagValues;
    [HideInInspector]
    public int startBagLevel;
    [HideInInspector]
    public int actualBagLevel;

    //MONEY LEVEL UPGRADE
    [Header("Money Level")]
    public Text moneyPricetxt;
    public Text moneylevelTxt;
    public double[] moneyValues;
    [HideInInspector]
    public int startMoneyLevel;
    [HideInInspector]
    public int actualMoneyLevel;

    //MONEY QUANTITY UPGRADES
    [Header("Money Quantity Level")]
    public Text moneyQuantityPricetxt;
    public Text moneyQuantityleveltxt;
    [HideInInspector]
    public int startMoneyQuantityLevel;
    [HideInInspector]
    public int actualMoneyQuantityLevel;
    public double[] moneyQuantityValues;

    //RTOTATION UPGRADES
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
    public ActivementsAndRanking activementsAndRanking;

    /// <summary>
    /// Assigns values ​​to variables when starting the game 
    /// </summary>
    /// <param name="_baglevel"></param>
    /// <param name="_moneylevel"></param>
    /// <param name="_moneyQuantitylevel"></param>
    /// <param name="_rotationlevel"></param>
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

    /// <summary>
    /// Change text in the UI
    /// </summary>
    private void SetTextButtons()
    {
        if(actualBagLevel == 6)
        {
            bagPricetxt.text = "Max Lvl";
            baglevelTxt.text = actualBagLevel.ToString();
        }
        else
        {
            string moneyFormat = string.Format("{0:#,0.#}", bagValues[actualBagLevel - 1]);
            bagPricetxt.text = moneyFormat;
            baglevelTxt.text = actualBagLevel.ToString();
        }
        if (actualMoneyLevel == 5)
        {
            moneyPricetxt.text = "Max Lvl";
            moneylevelTxt.text = actualMoneyLevel.ToString();
        }
        else
        {
            string moneyFormat = string.Format("{0:#,0.#}", moneyValues[actualMoneyLevel - 1]);
            moneyPricetxt.text = moneyFormat;
            moneylevelTxt.text = actualMoneyLevel.ToString();
        }
        if (actualMoneyQuantityLevel == 5)
        {
            moneyQuantityleveltxt.text = actualMoneyQuantityLevel.ToString();
            moneyQuantityPricetxt.text = "Max Lvl";
        }
        else
        {
            string moneyFormat = string.Format("{0:#,0.#}", moneyQuantityValues[actualMoneyQuantityLevel - 1]);
            moneyQuantityPricetxt.text = moneyFormat;
            moneyQuantityleveltxt.text = actualMoneyQuantityLevel.ToString();
        }
        if (actualRotationLevel == 5)
        {
            rotationPricetxt.text = "Max Lvl";
            rotationlevelTxt.text = actualRotationLevel.ToString();
        }
        else
        {
            string moneyFormat = string.Format("{0:#,0.#}", rotationValues[actualRotationLevel - 1]);
            rotationPricetxt.text = moneyFormat;
            rotationlevelTxt.text = actualRotationLevel.ToString();
        }        
    }

    /// <summary>
    /// Play Cash Sound :P
    /// </summary>
    private void PlayCashSound()
    {
        cashSound.Play();
    }

    /// <summary>
    /// Instantiate a particle at 0,0.33,0
    /// </summary>
    private void InstantiateParticleEvolution()
    {
        Instantiate(ParticleSystemEvolution, new Vector3(0, 0.33f, 0), Quaternion.identity);
    }

    /// <summary>
    /// Buy button if have money
    /// </summary>
    /// <param name="name">button name</param>
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
                MoneyManager.GrowMultiply(actualBagLevel);
                PlayCashSound();
                InstantiateParticleEvolution();
                activementsAndRanking.GiveActivements("Bag", actualBagLevel);
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
                InstantiateParticleEvolution();
                PlayCashSound();
                activementsAndRanking.GiveActivements("Money", actualMoneyLevel);
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
                InstantiateParticleEvolution();
                PlayCashSound();
                activementsAndRanking.GiveActivements("Drop", actualMoneyQuantityLevel);
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
                InstantiateParticleEvolution();
                PlayCashSound();
                activementsAndRanking.GiveActivements("Rotation", actualRotationLevel);
            }
        }
        SetTextButtons();
    }
}