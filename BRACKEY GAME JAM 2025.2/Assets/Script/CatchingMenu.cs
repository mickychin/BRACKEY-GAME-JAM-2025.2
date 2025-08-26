using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchingMenu : MonoBehaviour
{
    [SerializeField] Image SpiderImage;
    Tool tool;

    private void Start()
    {
        tool = FindObjectOfType<Tool>();
    }

    public void Catch()
    {
        // Attemp to catch Spider
        if (FindObjectOfType<PlayerMovement>().isIteminInventory(tool.CurrentTool_Item()))
        {
            FindObjectOfType<Spinwheel>().Spin();
        }
        else
        {
            //error noise
        }
    }

    public void Run()
    {
        if (FindObjectOfType<Spinwheel>().isSpinning())
        {
            return;
        }
        // Run from spider
        gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().canMove = true;
        FindObjectOfType<Food>().ResetHasUseFood();
    }

    public void SetSpiderImage(Sprite sprite)
    {
        SpiderImage.sprite = sprite;
    }
}
