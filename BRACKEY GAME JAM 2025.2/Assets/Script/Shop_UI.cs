using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        inventory = new Inventory();
    }

    public void BuyItem(string itemName)
    {
        foreach(Item.ItemType item in Enum.GetValues(typeof(Item.ItemType)))
        {
            if(item.ToString() == itemName)
            {
                //we found the item
                Debug.Log(item.ToString());
                inventory.AddItem(new Item { itemType = item, amount = 1});
            }
        }
    }
}
