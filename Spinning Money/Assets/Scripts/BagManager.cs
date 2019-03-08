using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public Transform spawnPosition;

    int bagLevel, moneyLevel, moneyQuantityLevel, rotationLevel;

    public Material money_1, money_2, money_3, money_4, money_5;
    public GameObject bag_1, bag_2, bag_3, bag_4, bag_5, bag_6;

    public InputManager inputManager;


    public GameObject actualBag;


    float rotationMult;
    float numberOfMoney;

    private void Start()
    {
        checkLevels();
        setBagAtributes();
    }

    //checa os niveis para startar os objetos
    void checkLevels()
    {
        bagLevel = 1;
        moneyLevel = 1;
        moneyQuantityLevel = 1;
        rotationLevel = 1;
    }

    void setBagAtributes()
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
        switch (_rotationLevel)
        {
            case 1:
                //rotation rate 1
                break;
            case 2:
                //rotation rate 2
                break;
            case 3:
                //rotation rate 3
                break;
            case 4:
                //rotation rate 4
                break;
            case 5:
                //rotation rate 5
                break;
            case 6:
                //rotation rate 6
                break;
        }
    }

    void ChangeMoneySpawnRate(int _moneySpawnRate)
    {
        switch (_moneySpawnRate)
        {
            case 1:
                //spawn rate 1
                break;
            case 2:
                //spawn rate 2
                break;
            case 3:
                //spawn rate 3
                break;
            case 4:
                //spawn rate 4
                break;
            case 5:
                //spawn rate 5
                break;
            case 6:
                //spawn rate 6
                break;
        }
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
    }





}
