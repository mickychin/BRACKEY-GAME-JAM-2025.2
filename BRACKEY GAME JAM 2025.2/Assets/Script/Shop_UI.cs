using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop_UI : MonoBehaviour
{
    [System.Serializable] public struct ItemPrice
    {
        public Item.ItemType itemType;
        public int price;
    }

    [SerializeField] private Inventory inventory;
    [SerializeField] public ItemPrice[] itemsPrice;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI DayText;
    GameMaster gamemaster;

    private void Start()
    {
        gamemaster = FindObjectOfType<GameMaster>();
        if (gamemaster.MainInventory != null)
        {
            inventory = gamemaster.MainInventory;
        }
        else
        {
            inventory = new Inventory();
        }
        gamemaster.CurrentDay++;
        if (gamemaster.IsShowedDay)
        {
            DayText.gameObject.SetActive(false);
        }
        else
        {
            DayText.text = "Day " + gamemaster.CurrentDay.ToString();
        }
            gamemaster.IsShowedDay = false;
        moneyText.text = "$" + gamemaster.CurrentMoney.ToString(); //update money UI
    }

    public void BuyItem(string itemName)
    {
        foreach(Item.ItemType item in Enum.GetValues(typeof(Item.ItemType)))
        {
            if (item.ToString() == itemName)
            {
                //we found the item
                //Debug.Log(item.ToString());
                foreach (ItemPrice itemPrice in itemsPrice)
                {
                    if (itemPrice.itemType == item)  // check for the same item type
                    {
                        //Debug.Log(item.ToString());
                        if (itemPrice.price > gamemaster.CurrentMoney) //basically checking if we have enough money
                        {
                            return; //we dont have enough money
                        }
                        else
                        {
                            gamemaster.CurrentMoney -= itemPrice.price; //we have enough money reduce money
                            moneyText.text = "$" + gamemaster.CurrentMoney.ToString(); //update money UI
                        }
                    }
                }

                inventory.AddItem(new Item { itemType = item, amount = 1}); //add item
                gamemaster.MainInventory = inventory;
            }
        }
    }
}
