using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour
{
    [SerializeField] Image Current_Tool_Image;

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
    }

    public void SetTool_Bugnet()
    {
        CurrentEquippedTool = ToolType.Bugnet;
        Current_Tool_Image.sprite = ItemAssets.Instance.BugnetSprite;
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

