using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinwheel : MonoBehaviour
{
    RectTransform rectTransform;
    [SerializeField] private float spin;
    [SerializeField] private float spin_decline_rate;

    [SerializeField] Image Risk_Area;

    public void SetRisk(float risk)
    {
        if (Risk_Area)
        {
            Risk_Area.fillAmount = risk;
        }
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
            FindObjectOfType<PlayerMovement>().canMove = true;
            FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
            //Debug.Log(rectTransform.localEulerAngles.z / 360f);
            Debug.Log(IsSpinOnRed());
            if (IsSpinOnRed())
            {
                //Fail capture, possibly bitten
            }
            else
            {

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
