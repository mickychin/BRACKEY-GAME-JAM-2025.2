using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antidote_Canvas : MonoBehaviour
{
    [SerializeField] AudioClip AntidoteSFX;
    [SerializeField] AudioClip BiteSFX;

    public void AntidoteUsed()
    {
        FindObjectOfType<GameMusic>().PlayWalkMusic();
        FindObjectOfType<PlayerMovement>().canMove = true;
        FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().removeItemFromINV(new Item { itemType = Item.ItemType.Antidote, amount = 1 });
        gameObject.SetActive(false);
    }

    public void playBiteSFX()
    {
        GetComponent<AudioSource>().clip = BiteSFX;
        GetComponent<AudioSource>().Play();
    }

    public void playAntidoteSFX()
    {
        GetComponent<AudioSource>().clip = AntidoteSFX;
        GetComponent<AudioSource>().Play();
    }
}
