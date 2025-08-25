using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite TubeContainerSprite;
    public Sprite NotebookSprite;
    public Sprite BugnetSprite;
    public Sprite HeadlightSprite;
    public Sprite FlashlightSprite;
    public Sprite AntidoteSprite;
    public Sprite GlovesSprite;
    public Sprite FoodT1Sprite;
    public Sprite FoodT2Sprite;
    public Sprite FoodT3Sprite;
    public Sprite BiscuitSprite;
    public Sprite MRKTSprite;
    public Sprite RJSSprite;
    public Sprite OBTSprite;
    public Sprite GBSprite;
    public Sprite GSTSprite;
    public Sprite BlackWidowSprite;
    public Sprite SFWSprite;
    public Sprite RadioactiveSpiderSprite;
}
