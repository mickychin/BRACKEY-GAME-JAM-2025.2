using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchingMenu : MonoBehaviour
{
    [SerializeField] Image SpiderImage;
    Tool tool;
    [SerializeField] AudioClip ContainerSFX;
    [SerializeField] AudioClip BugnetSFX;

    private void Start()
    {
        tool = FindObjectOfType<Tool>();
    }

    public void Catch()
    {
        if (FindObjectOfType<Spinwheel>().isSpinning())
        {
            return;
        }

        // Attemp to catch Spider
        if (FindObjectOfType<PlayerMovement>().isIteminInventory(tool.CurrentTool_Item()))
        {
            FindObjectOfType<Spinwheel>().Spin();
            playSFX();
        }
        else
        {
            //error noise
        }
    }

    private void playSFX()
    {
        if(tool.CurrentTool_Item().itemType == Item.ItemType.Container)
        {
            GetComponent<AudioSource>().clip = ContainerSFX;
            GetComponent<AudioSource>().Play();
        }
        else if(tool.CurrentTool_Item().itemType == Item.ItemType.Bugnet)
        {
            GetComponent<AudioSource>().clip = BugnetSFX;
            GetComponent<AudioSource>().Play();
        }
    }

    public void Run()
    {
        if (FindObjectOfType<Spinwheel>().isSpinning())
        {
            return;
        }
        // Run from spider
        FindObjectOfType<GameMusic>().PlayWalkMusic();
        gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().canMove = true;
        FindObjectOfType<Food>().ResetHasUseFood();
    }

    public void SetSpiderImage(Sprite sprite)
    {
        SpiderImage.sprite = sprite;
    }
}
