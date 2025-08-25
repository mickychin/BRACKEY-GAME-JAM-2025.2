using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingMenu : MonoBehaviour
{
    public void Catch()
    {
        // Attemp to catch Spider
        FindObjectOfType<Spinwheel>().Spin();
    }

    public void Run()
    {
        // Run from spider
        gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().canMove = true;
    }
}
