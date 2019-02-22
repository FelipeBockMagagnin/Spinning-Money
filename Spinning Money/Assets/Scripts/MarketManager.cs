using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string name;
    public int price;
    //[HideInInspector]
    //public bool blocked;
    public Button button;
    public int IncreseMultiplyAmount;
    //public Button PriceButton;
}

public class MarketManager : MonoBehaviour
{
    public Item[] items;
    InputManager inputManager;
    MarketManager instance;

    private void Awake()
    {
        inputManager = GameObject.Find("Cube").GetComponent<InputManager>();
    }


    /// <summary>
    /// Compra um determinado estilo
    /// </summary>
    /// <param name="item"></param>
    void ButtonBuy(Item item)
    {
        Debug.Log("item " + item.name + " desbloqueado");
        inputManager.multiplicator += item.IncreseMultiplyAmount;
    }

    /// <summary>
    /// Compra um novo estilo/musica
    /// </summary>
    /// <param name="name"></param>
    public void Buy(string name)
    {
        foreach (Item item in items)
        {
            if (item.name == name)
            {
                if (inputManager.money  >= item.price)
                {
                    Debug.Log("Item " + item.name + " comprado com sucesso");
                    ButtonBuy(item);
                    inputManager.money -= item.price;
                }
                else
                {
                    Debug.Log("Não há dinheiro para comprar o Item " + item.name);
                }

            }
        }
    }
}
