using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
