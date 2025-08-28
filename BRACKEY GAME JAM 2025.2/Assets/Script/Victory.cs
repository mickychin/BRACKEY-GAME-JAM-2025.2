using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TotalEarnedText;

    // Start is called before the first frame update
    void Start()
    {
        TotalEarnedText.text = "$" + FindObjectOfType<GameMaster>().TotalEarnedMoney.ToString();
    }
}
