using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();

        itemList.Add(new Item { itemType = Item.ItemType.Container, amount = 5});
        //Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        bool itemAlreadyInInventory = false;
        foreach (Item inventoryItem in itemList)
        {
            if(inventoryItem.itemType == item.itemType)
            {
                //Debug.Log(item.amount);
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }
        }
        if (!itemAlreadyInInventory)
        {
            itemList.Add(new Item { itemType = item.itemType, amount = item.amount, ItemRiskBuff = item.ItemRiskBuff, ItemBiteRateBuff = item.ItemBiteRateBuff});
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        Item itemInInventory = null;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                //Debug.Log(item.amount);
                inventoryItem.amount -= item.amount;
                itemInInventory = inventoryItem;
            }
        }
        if (itemInInventory != null && itemInInventory.amount <= 0)
        {
            itemList.Remove(itemInInventory);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemLists()
    {
        return itemList;
    }
}
