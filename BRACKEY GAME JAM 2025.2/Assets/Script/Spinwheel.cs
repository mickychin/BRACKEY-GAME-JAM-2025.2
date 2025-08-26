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

    private void SetRisk(float risk)
    {
        if (Risk_Area)
        {
            Risk_Area.fillAmount = risk;
        }
    }

    public void ChangeRisk(float risk)
    {
        Risk_Area.fillAmount += risk;
    }

    public void SetSpider(Spider spider)
    {
        SetRisk(spider.Default_Risk);
        currentSpider = spider;
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
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.removeItemFromINV(FindObjectOfType<Tool>().CurrentTool_Item());
            player.canMove = true;
            FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
            if (IsSpinOnRed())
            {
                //Fail capture, possibly bitten
            }
            else
            {
                FindObjectOfType<PlayerMovement>().addItemToINV(currentSpider.GetItem());
                Destroy(currentSpider.gameObject);
            }
        }
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
}
