using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Item
{
    public enum ItemType
    {
        TubeContainer,
        Notebook,
        Bugnet,
        Headlight,
        Flashlight,
        Antidote,
        Gloves,
        FoodT1,
        FoodT2,
        FoodT3,
        Biscuit,
        MRKT,
        RJS,
        OBT,
        GB,
        GST,
        BlackWidow,
        SFW,
        RadioactiveSpider
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.TubeContainer:     return ItemAssets.Instance.TubeContainerSprite;
            case ItemType.Notebook:          return ItemAssets.Instance.NotebookSprite;
            case ItemType.Bugnet:            return ItemAssets.Instance.BugnetSprite;
            case ItemType.Headlight:         return ItemAssets.Instance.HeadlightSprite;
            case ItemType.Flashlight:        return ItemAssets.Instance.FlashlightSprite;
            case ItemType.Antidote:          return ItemAssets.Instance.AntidoteSprite;
            case ItemType.Gloves:            return ItemAssets.Instance.GlovesSprite;
            case ItemType.FoodT1:            return ItemAssets.Instance.FoodT1Sprite;
            case ItemType.FoodT2:            return ItemAssets.Instance.FoodT2Sprite;
            case ItemType.FoodT3:            return ItemAssets.Instance.FoodT3Sprite;
            case ItemType.Biscuit:           return ItemAssets.Instance.BiscuitSprite;
            case ItemType.MRKT:              return ItemAssets.Instance.MRKTSprite;
            case ItemType.RJS:               return ItemAssets.Instance.RJSSprite;
            case ItemType.OBT:               return ItemAssets.Instance.OBTSprite;
            case ItemType.GB:                return ItemAssets.Instance.GBSprite;
            case ItemType.GST:               return ItemAssets.Instance.GSTSprite;
            case ItemType.BlackWidow:        return ItemAssets.Instance.BlackWidowSprite;
            case ItemType.SFW:               return ItemAssets.Instance.SFWSprite;
            case ItemType.RadioactiveSpider: return ItemAssets.Instance.RadioactiveSpiderSprite;
        }
    }

    public bool isInteractable()
    {
        switch (itemType)
        {
            default:
            case ItemType.TubeContainer:
            case ItemType.Bugnet:
            case ItemType.FoodT1:
            case ItemType.FoodT2:
            case ItemType.FoodT3:
            case ItemType.Biscuit:
                return true;
            case ItemType.Notebook:
            case ItemType.Headlight:
            case ItemType.Flashlight:
            case ItemType.Antidote:
            case ItemType.Gloves:
            case ItemType.MRKT:
            case ItemType.RJS:
            case ItemType.OBT:
            case ItemType.GB:
            case ItemType.GST:
            case ItemType.BlackWidow:
            case ItemType.SFW:
            case ItemType.RadioactiveSpider:
                return false;
        }
    }
}
