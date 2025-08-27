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

    private Spider currentSpider;
    private float currentBiteRate;
    private float currentRisk;

    private float ToolBiteRate;
    private float ToolRisk;

    private void UpdateRiskMeter()
    {
        Risk_Area.fillAmount = currentRisk + ToolRisk;
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
        SetRisk(spider.Default_Risk);
        currentSpider = spider;
        currentBiteRate = currentSpider.Bite_Rate;
    }

    public void Spin()
    {
        float spinPower = Random.Range(80f, 1000f);
        spin = spinPower;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spin();
            SetRisk(0.5f);
        }

        if(spin == 0)
        {
            return;
        }

        rectTransform.Rotate(new Vector3(0, 0, spin));
        spin *= spin_decline_rate;
        if(spin <= 0.001)
        {
            spin = 0;
            FindObjectOfType<Food>().ResetHasUseFood();
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.removeItemFromINV(FindObjectOfType<Tool>().CurrentTool_Item());
            player.canMove = true;
            FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
            if (IsSpinOnRed())
            {
                //Fail capture, possibly bitten
                if (isBitten()) // calculate from bite rate and rng
                {
                    SpiderBite();
                }
            }
            else
            {
                FindObjectOfType<PlayerMovement>().addItemToINV(currentSpider.GetItem());
                FindObjectOfType<GameMaster>().CurrentMoney += (int)currentSpider.Price; // maybe reworked later
                Destroy(currentSpider.gameObject);
            }
        }
    }

    private void SpiderBite()
    {
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
        if (randomNumber <= (currentBiteRate + ToolBiteRate) * converDecimalToPercent)
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
