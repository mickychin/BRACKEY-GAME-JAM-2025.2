using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
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
        public bool isLethal;
        public int weight; // Higher weight = higher chance
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

    private SpiderType RandomSpiderType()
    {
        int totalWeight = 0;
        foreach(SpiderType spiderType in spiderTypes)
        {
            totalWeight += spiderType.weight;
        }

        int randomNumber = Random.Range(0, totalWeight);

        foreach (SpiderType spiderType in spiderTypes)
        {
            if (randomNumber < spiderType.weight)
            {
                return spiderType;
            }
            randomNumber -= spiderType.weight;
        }
        Debug.LogError("Weight Error!");
        return new SpiderType(); //this should never happen just a safety net
    }

    public Sprite GetSpiderSprite(SpiderType spiderType)
    {
        switch (spiderType.spiderName)
        {
            default:
            case SpiderName.MRKT: return ItemAssets.Instance.MRKTSprite;
            case SpiderName.RJS: return ItemAssets.Instance.RJSSprite;
            case SpiderName.OBT: return ItemAssets.Instance.OBTSprite;
            case SpiderName.GB: return ItemAssets.Instance.GBSprite;
            case SpiderName.GST: return ItemAssets.Instance.GSTSprite;
            case SpiderName.BlackWidow: return ItemAssets.Instance.BlackWidowSprite;
            case SpiderName.SFW: return ItemAssets.Instance.SFWSprite;
            case SpiderName.RadioactiveSpider: return ItemAssets.Instance.RadioactiveSpiderSprite;
        }
    }

    private void Start()
    {
        for (int i = 0; i < 20;  i++)
        {
            SpawnSpider(RandomSpiderType(), new Vector2(Random.Range(-6f, 6f), Random.Range(-9f, 9f)));
        }
    }

    private void SpawnSpider(SpiderType spiderType, Vector2 spawn_pos)
    {
        Spider spider = Instantiate(spider_prefab, spawn_pos, Quaternion.identity).GetComponent<Spider>();
        spider.Default_Risk = spiderType.Default_Risk;
        spider.Price = spiderType.Price;
        spider.Bite_Rate = spiderType.Bite_Rate;
        spider.IsLethal = spiderType.isLethal;
        spider.name = spiderType.spiderName.ToString();
        spider.Render.sprite = GetSpiderSprite(spiderType);
        spider.SetItem(GetSpiderItem(spiderType));
    }
}
