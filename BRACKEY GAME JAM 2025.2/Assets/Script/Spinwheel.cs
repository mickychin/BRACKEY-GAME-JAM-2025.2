using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Spinwheel : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] private float spin;
    [SerializeField] private float spin_decline_rate;

    [SerializeField] Image Risk_Area;

    [SerializeField] GameObject Antidote_Canvas;

    private Spider currentSpider;
    private float currentBiteRate;
    private float currentRisk;

    private float ToolBiteRate;
    private float ToolRisk;

    private float PassiveRiskBuff;
    private float PassiveBiteRateBuff;

    AudioSource audioSource;

    private void UpdateRiskMeter()
    {
        Risk_Area.fillAmount = currentRisk + ToolRisk + PassiveRiskBuff;
    }

    public void SetToolBiteRate(float rate)
    {
        ToolBiteRate = rate;
    }

    public void SetToolRisk(float risk)
    {
        ToolRisk = risk;
        UpdateRiskMeter();
    }

    private void SetRisk(float risk)
    {
        currentRisk = risk;
        UpdateRiskMeter();
    }
 
    public void ChangeRisk(float risk)
    {
        currentRisk += risk;
        UpdateRiskMeter();
    }

    public void ChangeBiteRate(float change)
    {
        currentBiteRate += change;
    }

    public void SetSpider(Spider spider)
    {
        PassiveBiteRateBuff = 0;
        PassiveRiskBuff = 0;
        foreach (Item item in FindObjectOfType<GameMaster>().MainInventory.GetItemLists()) //get the buff from equipment and item
        {
            PassiveBiteRateBuff += item.ItemBiteRateBuff;
            PassiveRiskBuff += item.ItemRiskBuff;
        }

        SetRisk(spider.Default_Risk);
        Debug.Log(PassiveRiskBuff);
        Debug.Log(currentRisk + ToolRisk + PassiveRiskBuff);
        currentSpider = spider;
        currentBiteRate = currentSpider.Bite_Rate;
    }

    public void Spin()
    {
        float spinPower = Random.Range(80f, 1000f);
        audioSource.Play();
        spin = spinPower;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if(spin == 0)
        {
            return;
        }

        int maxSpinPower = 100;
        float maxSpinPitch = 1;
        audioSource.pitch = 0.1f + (Mathf.Min(spin / maxSpinPower, maxSpinPitch) * 2.9f);   
        rectTransform.Rotate(new Vector3(0, 0, spin));
        spin *= spin_decline_rate;
        if(spin <= 0.001)
        {
            audioSource.Stop();
            spin = 0;
            FindObjectOfType<Food>().ResetHasUseFood();
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.removeItemFromINV(FindObjectOfType<Tool>().CurrentTool_Item());
            //FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
            if (IsSpinOnRed())
            {
                //Fail capture, possibly bitten
                if (isBitten()) // calculate from bite rate and rng
                {
                    SpiderBite();
                }
                else
                {
                    FindObjectOfType<GameMusic>().PlayWalkMusic();
                    FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
                    player.canMove = true;
                }
            }
            else
            {
                player.canMove = true;
                FindObjectOfType<GameMusic>().PlayWalkMusic();
                FindObjectOfType<SFX_Player>().playCapturedSFX();
                FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
                FindObjectOfType<PlayerMovement>().addItemToINV(currentSpider.GetItem());
                FindObjectOfType<GameMaster>().CurrentMoney += (int)currentSpider.Price; // maybe reworked later
                FindObjectOfType<GameMaster>().TotalEarnedMoney += (int)currentSpider.Price;
                Destroy(currentSpider.gameObject);
            }
        }
    }

    private void SpiderBite()
    {
        foreach (Item item in FindObjectOfType<GameMaster>().MainInventory.GetItemLists()) // check through every item in inventory
        {
            if (item.itemType == Item.ItemType.Antidote) // check if we have Antidote
            {
                //have Antidote (maybe reworked?)
                Antidote_Canvas.SetActive(true);
                Antidote_Canvas.GetComponent<Animator>().SetTrigger("PlayAnim");
                return;
            }
        }

        FindObjectOfType<GameMusic>().StopMusic();

        if (currentSpider.IsLethal)
        {
            // player die
            FindObjectOfType<PlayerMovement>().Die();
        }
        else
        {
            FindObjectOfType<PlayerMovement>().PassOut();
        }
    }

    private bool isBitten()
    {
        int randomNumber = Random.Range(1, 101);
        int converDecimalToPercent = 100;
        if (randomNumber <= (currentBiteRate + ToolBiteRate + PassiveBiteRateBuff) * converDecimalToPercent)
        {
            return true;
        }
        return false;
    }

    private bool IsSpinOnRed()
    {
        float Flipped_Risk_Area = Mathf.Abs(Risk_Area.fillAmount - 1f);
        if(rectTransform.localEulerAngles.z / 360f >= Flipped_Risk_Area)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isSpinning()
    {
        if(spin > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
