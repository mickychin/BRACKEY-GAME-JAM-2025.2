using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour
{
    [Serializable]
    public struct ToolEffect
    {
        public float Risk;
        public float BiteChance;
    }

    [SerializeField] Image Current_Tool_Image;
    [SerializeField] ToolEffect TubeContainerEffect, BugnetEffect;

    public enum ToolType
    {
        TubeContainer,
        Bugnet
    }

    public ToolType CurrentEquippedTool;

    public void SetTool_TubeContainer()
    {
        CurrentEquippedTool = ToolType.TubeContainer;
        Current_Tool_Image.sprite = ItemAssets.Instance.TubeContainerSprite;
        Spinwheel spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.SetToolRisk(TubeContainerEffect.Risk);
        spinwheel.SetToolBiteRate(TubeContainerEffect.BiteChance);
    }

    public void SetTool_Bugnet()
    {
        CurrentEquippedTool = ToolType.Bugnet;
        Current_Tool_Image.sprite = ItemAssets.Instance.BugnetSprite;
        Spinwheel spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.SetToolRisk(BugnetEffect.Risk);
        spinwheel.SetToolBiteRate(BugnetEffect.BiteChance);
    }

    public Item CurrentTool_Item()
    {
        switch(CurrentEquippedTool)
        {
            default:
            case ToolType.TubeContainer: return new Item { itemType = Item.ItemType.TubeContainer, amount = 1 };
            case ToolType.Bugnet: return new Item { itemType = Item.ItemType.Bugnet, amount = 1 };
        }
    }
}

