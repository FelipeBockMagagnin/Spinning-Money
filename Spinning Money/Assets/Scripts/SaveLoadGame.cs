using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveLoadGame : MonoBehaviour
{
    ///MONEY MANAGER
    //Money
    //Total Money
    //Money Multi


    ///BAG BUTTON MANAGER
    //Actual bag level
    //Actual money level
    //Actual moneyQuantity level
    //Actual rotation level

    public BagButtonManager bagButtonManager;


    ///UPGRADE MANAGER
    //numberOfItems

    public UpgradeManager Item1;
    public UpgradeManager Item2;
    public UpgradeManager Item3;
    public UpgradeManager Item4;



    public OfflineTime offlineTime;



    private void Start()
    {
        Load();
    }


    public void Save()
    {
        offlineTime.SaveLastShutdownTime();


        //MONEY MANAGER
        PlayerPrefs.SetString("Money", MoneyManager.money.ToString());
        PlayerPrefs.SetString("TotalMoney", MoneyManager.totalMoney.ToString());
        PlayerPrefs.SetString("MoneyMultiply", MoneyManager.moneyMultiply.ToString());

        ///BAGBUTTONMANAGER
        PlayerPrefs.SetInt("ActualBagLevel", bagButtonManager.actualBagLevel);
        PlayerPrefs.SetInt("ActualMoneyLevel", bagButtonManager.actualMoneyLevel);
        PlayerPrefs.SetInt("ActualMoneyQuantityLevel", bagButtonManager.actualMoneyQuantityLevel);
        PlayerPrefs.SetInt("ActualRotationLevel", bagButtonManager.actualRotationLevel);

        ///UPGRADE MANAGER
        PlayerPrefs.SetInt("Item1", Item1.numberOfItems);
        PlayerPrefs.SetInt("Item2", Item2.numberOfItems);
        PlayerPrefs.SetInt("Item3", Item3.numberOfItems);
        PlayerPrefs.SetInt("Item4", Item4.numberOfItems);
    }


    public void Load()
    {
        //MONEY MANAGER
        //if has key so all the keys are stored
        if (PlayerPrefs.HasKey("Money"))
        {
            //MONEY MANAGER
            String Smoney = PlayerPrefs.GetString("Money");
            String StotalMoney = PlayerPrefs.GetString("TotalMoney");
            String SmoneyMultiply = PlayerPrefs.GetString("MoneyMultiply");


            double Dmoney = Double.Parse(Smoney);
            double DtotalMoney = Double.Parse(StotalMoney);
            double DmoneyMultiply = Double.Parse(SmoneyMultiply);


            MoneyManager.StartGame(Dmoney, DtotalMoney, DmoneyMultiply);
        }
        else
        {
            //start game with all zero
            MoneyManager.StartGame(0, 0, 1);
        }

        //BAGBUTTONMANAGER
        if(PlayerPrefs.HasKey("ActualBagLevel"))
        {
            int _baglevel = PlayerPrefs.GetInt("ActualBagLevel");
            int _moneylevel = PlayerPrefs.GetInt("ActualMoneyLevel");
            int _moneyQuantitylevel = PlayerPrefs.GetInt("ActualMoneyQuantityLevel");
            int _rotationlevel = PlayerPrefs.GetInt("ActualRotationLevel");

            bagButtonManager.StartGame(_baglevel, _moneylevel, _moneyQuantitylevel, _rotationlevel);
        } 
        else
        {
            bagButtonManager.StartGame(1, 1, 1, 1);
        }

        

        if(PlayerPrefs.HasKey("Item1"))
        {
            Item1.StartGame(PlayerPrefs.GetInt("Item1"));
            Item2.StartGame(PlayerPrefs.GetInt("Item2"));
            Item3.StartGame(PlayerPrefs.GetInt("Item3"));
            Item4.StartGame(PlayerPrefs.GetInt("Item4"));
        }
        else
        {
            Item1.StartGame(0);
            Item2.StartGame(0);
            Item3.StartGame(0);
            Item4.StartGame(0);
        }




        offlineTime.OnGameStartup();

    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            Save();
        }
        else
        {
            
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
