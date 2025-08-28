using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverAndPassOut : MonoBehaviour
{
    [SerializeField] GameObject GameoverCanvas;
    [SerializeField] GameObject PassoutCanvas;
    [SerializeField] TextMeshProUGUI PassoutDayCounter;

    public void LoadGameOver()
    {
        GameoverCanvas.SetActive(true);
    }

    public void LoadPassout()
    {
        PassoutCanvas.SetActive(true);
        PassoutDayCounter.text = "Day " + (FindObjectOfType<GameMaster>().CurrentDay + 1).ToString();
        FindObjectOfType<GameMaster>().IsShowedDay = true;
    }
}
