using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public void LoadMain()
    {
        //reset save
        GameMaster gamemaster = FindObjectOfType<GameMaster>();
        gamemaster.CurrentDay = 1;
        gamemaster.CurrentMoney = 0;
        gamemaster.TotalEarnedMoney = 0;
        gamemaster.MainInventory = new Inventory();
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadShop()
    {
        int LastDay = 5;
        if (FindObjectOfType<GameMaster>().CurrentDay >= LastDay)
        {
            SceneManager.LoadScene("Victory");
        }
        else
        {
            SceneManager.LoadScene("Shop");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
