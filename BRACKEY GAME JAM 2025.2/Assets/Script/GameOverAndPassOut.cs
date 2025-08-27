using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAndPassOut : MonoBehaviour
{
    [SerializeField] GameObject GameoverCanvas;
    [SerializeField] GameObject PassoutCanvas;

    public void LoadGameOver()
    {
        GameoverCanvas.SetActive(true);
    }

    public void LoadPassout()
    {
        PassoutCanvas.SetActive(true);
    }
}
