using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string name;
    public int price;
    public Button button;
}

public class MarketManager : MonoBehaviour
{
    public Item[] items;
    MarketManager instance;

    void ButtonBuy(Item item)
    {
        Debug.Log("item " + item.name + " desbloqueado");
    }


    public void Buy(string name)
    {
        foreach (Item item in items)
        {
            if (item.name == name)
            {
                if (MoneyManager.money  >= item.price)
                {
                    Debug.Log("Item " + item.name + " comprado com sucesso");
                    ButtonBuy(item);
                    MoneyManager.money -= item.price;
                }
                else
                {
                    Debug.Log("Não há dinheiro para comprar o Item " + item.name);
                }

            }
        }
    }
}
