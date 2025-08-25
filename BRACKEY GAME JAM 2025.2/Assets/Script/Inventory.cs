using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.TubeContainer, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Flashlight, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Bugnet, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemLists()
    {
        return itemList;
    }
}
