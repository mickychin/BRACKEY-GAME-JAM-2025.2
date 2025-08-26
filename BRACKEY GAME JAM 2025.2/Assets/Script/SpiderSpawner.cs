using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpiderSpawner;

public class SpiderSpawner : MonoBehaviour
{
    public enum SpiderName
    {
        MRKT,
        RJS,
        OBT,
        GB,
        GST,
        BlackWidow,
        SFW,
        RadioactiveSpider
    }

     [System.Serializable] public struct SpiderType
    {
        public float Default_Risk;
        public float Price;
        public float Bite_Rate;
        public SpiderName spiderName;
    }

    [SerializeField] Spider spider_prefab;
    public SpiderType[] spiderTypes;

    public Item GetSpiderItem(SpiderType spiderType)
    {
        switch (spiderType.spiderName)
        {
            default:
            case SpiderName.MRKT: return new Item { itemType = Item.ItemType.MRKT, amount = 1};
            case SpiderName.RJS: return new Item { itemType = Item.ItemType.RJS, amount = 1 };
            case SpiderName.OBT: return new Item { itemType = Item.ItemType.OBT, amount = 1 };
            case SpiderName.GB: return new Item { itemType = Item.ItemType.GB, amount = 1 };
            case SpiderName.GST: return new Item { itemType = Item.ItemType.GST, amount = 1 };
            case SpiderName.BlackWidow: return new Item { itemType = Item.ItemType.BlackWidow, amount = 1 };
            case SpiderName.SFW: return new Item { itemType = Item.ItemType.SFW, amount = 1 };
            case SpiderName.RadioactiveSpider: return new Item { itemType = Item.ItemType.RadioactiveSpider, amount = 1 };
        }
    }

    private void Start()
    {
        SpawnSpider(spiderTypes[0], new Vector2(Random.Range(-2f, 2f), 2f));
        SpawnSpider(spiderTypes[0], new Vector2(Random.Range(-2f, 2f), 2f));
    }

    private void SpawnSpider(SpiderType spiderType, Vector2 spawn_pos)
    {
        Spider spider = Instantiate(spider_prefab, spawn_pos, Quaternion.identity).GetComponent<Spider>();
        spider.Default_Risk = spiderType.Default_Risk;
        spider.Price = spiderType.Price;
        spider.Bite_Rate = spiderType.Bite_Rate;
        spider.name = spiderType.spiderName.ToString();
        spider.SetItem(GetSpiderItem(spiderType));
    }
}
