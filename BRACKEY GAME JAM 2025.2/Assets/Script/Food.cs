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
    private bool HasUseT1Food, HasUseT2Food, HasUseT3Food;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void ResetHasUseFood()
    {
        HasUseT1Food = false;
        HasUseT2Food = false;
        HasUseT3Food = false;
    }

    public void UseT1Food()
    {
        if (HasUseT1Food)
        {
            return;
        }

        audioSource.Play();
        HasUseT1Food = true;
        playerMovement.removeItemFromINV(new Item { itemType = Item.ItemType.Fly, amount = 1 });
        spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.ChangeRisk(T1effect.Risk);
        spinwheel.ChangeBiteRate(T1effect.BiteChance);
    }

    public void UseT2Food()
    {
        if (HasUseT2Food)
        {
            return;
        }
        audioSource.Play();
        HasUseT2Food = true;
        playerMovement.removeItemFromINV(new Item { itemType = Item.ItemType.Mosquito, amount = 1 });
        spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.ChangeRisk(T2effect.Risk);
        spinwheel.ChangeBiteRate(T2effect.BiteChance);
    }

    public void UseT3Food()
    {
        if (HasUseT3Food)
        {
            return;
        }
        audioSource.Play();
        HasUseT3Food = true;
        playerMovement.removeItemFromINV(new Item { itemType = Item.ItemType.Ant, amount = 1 });
        spinwheel = FindObjectOfType<Spinwheel>();
        spinwheel.ChangeRisk(T3effect.Risk);
        spinwheel.ChangeBiteRate(T3effect.BiteChance);
    }
}
