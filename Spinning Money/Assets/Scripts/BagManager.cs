using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public Transform spawnPosition;

    public int bagLevel, moneyLevel, moneyQuantityLevel, rotationLevel;

    public Material money_1, money_2, money_3, money_4, money_5;
    public GameObject bag_1, bag_2, bag_3, bag_4, bag_5, bag_6;

    public InputManager inputManager;


    public GameObject actualBag;


    float rotationMult;
    float numberOfMoney;

    //checa os niveis para startar os objetos
    void SetLevels(int _bagLevel, int _moneyLevel, int _moneyQuantityLevel, int _rotationLevel)
    {
        bagLevel = _bagLevel;
        moneyLevel = _moneyLevel;
        moneyQuantityLevel = _moneyQuantityLevel;
        rotationLevel = _rotationLevel;
    }

    public void setBagAtributes()
    {
        //set bag level
        spawnBag(bagLevel);

        //set money level
        changeMoney(moneyLevel);

        //set moneyQuantity
        ChangeMoneySpawnRate(moneyQuantityLevel);

        //set rotation
        ChangeRotation(rotationLevel);
    }

    void ChangeRotation(int _rotationLevel)
    {
        inputManager = actualBag.GetComponent<InputManager>();
        inputManager.rotationMult = _rotationLevel;
        MoneyManager.GrowMultiply(_rotationLevel);
    }

    void ChangeMoneySpawnRate(int _moneySpawnRate)
    {
        MoneyManager.GrowMultiply(_moneySpawnRate);
    }

    void changeMoney(int _moneyLevel)
    {
        switch(_moneyLevel)
        {
            case 1:
                actualBag.GetComponent<ParticleSystemRenderer>().material = money_1;
                break;
            case 2:
                actualBag.GetComponent<ParticleSystemRenderer>().material = money_2;
                break;
            case 3:
                actualBag.GetComponent<ParticleSystemRenderer>().material = money_3; 
                break;
            case 4:
                actualBag.GetComponent<ParticleSystemRenderer>().material = money_4;
                break;
            case 5:
                actualBag.GetComponent<ParticleSystemRenderer>().material = money_5;
                break;
        }
        MoneyManager.GrowMultiply(_moneyLevel);
    }

    void spawnBag(int _baglevel)
    {
        if(actualBag != null)
        {
            Destroy(actualBag);
        }

        switch (_baglevel)
        {
            case 1:
                actualBag = Instantiate(bag_1, spawnPosition.position, Quaternion.identity);
                break;
            case 2:
                actualBag = Instantiate(bag_2, spawnPosition.position, Quaternion.identity);
                break;
            case 3:
                actualBag = Instantiate(bag_3, spawnPosition.position, Quaternion.identity);
                break;
            case 4:
                actualBag = Instantiate(bag_4, spawnPosition.position, Quaternion.identity);
                break;
            case 5:
                actualBag = Instantiate(bag_5, spawnPosition.position, Quaternion.identity);
                break;
            case 6:
                actualBag = Instantiate(bag_6, spawnPosition.position, Quaternion.identity);
                break;
        }
        MoneyManager.GrowMultiply(_baglevel);
    }
}
