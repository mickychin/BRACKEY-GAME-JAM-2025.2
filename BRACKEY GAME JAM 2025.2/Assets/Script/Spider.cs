using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float Default_Risk;
    public float Price;
    public float Bite_Rate;
    [SerializeField] private Item spider_item;
    public SpriteRenderer Render;

    public void SetItem(Item item)
    {
        spider_item = item;
    }

    public Item GetItem()
    {
        Item item = spider_item;
        return item;
    }
}
