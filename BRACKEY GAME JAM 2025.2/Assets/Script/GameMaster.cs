using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int CurrentMoney;
    public int TotalEarnedMoney;
    public int CurrentDay;
    public bool IsShowedDay;
    public Inventory MainInventory;

    public float MusicVolume;
    public float SFXVolume;

    // Start is called before the first frame update
    void Awake()
    {
        if(FindObjectsOfType<GameMaster>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
