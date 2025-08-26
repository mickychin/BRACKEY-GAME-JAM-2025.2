using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingMenu : MonoBehaviour
{
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
        // Run from spider
        gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().canMove = true;
    }
}
