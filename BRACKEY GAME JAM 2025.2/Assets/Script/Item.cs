using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Item
{
    [Serializable] public enum ItemType
    {
        Container,
        Notebook,
        Bugnet,
        Headlight,
        Flashlight,
        Antidote,
        Gloves,
        Fly,
        Mosquito,
        Ant,
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
    public float ItemRiskBuff;
    public float ItemBiteRateBuff;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Container:     return ItemAssets.Instance.TubeContainerSprite;
            case ItemType.Notebook:          return ItemAssets.Instance.NotebookSprite;
            case ItemType.Bugnet:            return ItemAssets.Instance.BugnetSprite;
            case ItemType.Headlight:         return ItemAssets.Instance.HeadlightSprite;
            case ItemType.Flashlight:        return ItemAssets.Instance.FlashlightSprite;
            case ItemType.Antidote:          return ItemAssets.Instance.AntidoteSprite;
            case ItemType.Gloves:            return ItemAssets.Instance.GlovesSprite;
            case ItemType.Fly:            return ItemAssets.Instance.FoodT1Sprite;
            case ItemType.Mosquito:            return ItemAssets.Instance.FoodT2Sprite;
            case ItemType.Ant:            return ItemAssets.Instance.FoodT3Sprite;
            case ItemType.Biscuit:           return ItemAssets.Instance.BiscuitSprite;
            case ItemType.MRKT:              return ItemAssets.Instance.MRKTCapturedSprite;
            case ItemType.RJS:               return ItemAssets.Instance.RJSSCapturedprite;
            case ItemType.OBT:               return ItemAssets.Instance.OBTCapturedSprite;
            case ItemType.GB:                return ItemAssets.Instance.GBCapturedSprite;
            case ItemType.GST:               return ItemAssets.Instance.GSTCapturedSprite;
            case ItemType.BlackWidow:        return ItemAssets.Instance.BlackWidowCapturedSprite;
            case ItemType.SFW:               return ItemAssets.Instance.SFWCapturedSprite;
            case ItemType.RadioactiveSpider: return ItemAssets.Instance.RadioactiveSpiderCapturedSprite;
        }
    }

    public bool isInteractable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Container:
            case ItemType.Bugnet:
            case ItemType.Fly:
            case ItemType.Mosquito:
            case ItemType.Ant:
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
