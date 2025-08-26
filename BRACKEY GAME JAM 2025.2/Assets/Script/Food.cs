using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Serializable] public struct FoodEffect
    {
        public float Risk;
        public float BiteChance;
    }

    Spinwheel spinwheel;
    PlayerMovement playerMovement;
    [SerializeField] private FoodEffect T1effect, T2effect, T3effect;
    

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void UseT1Food()
    {
        playerMovement.removeItemFromINV(new Item { itemType = Item.ItemType.FoodT1, amount = 1 });
        spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.ChangeRisk(T1effect.Risk);
    }

    public void UseT2Food()
    {
        playerMovement.removeItemFromINV(new Item { itemType = Item.ItemType.FoodT2, amount = 1 });
        spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.ChangeRisk(T2effect.Risk);
    }

    public void UseT3Food()
    {
        playerMovement.removeItemFromINV(new Item { itemType = Item.ItemType.FoodT3, amount = 1 });
        spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.ChangeRisk(T3effect.Risk);
    }
}
