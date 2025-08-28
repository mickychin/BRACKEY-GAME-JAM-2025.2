using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antidote_Canvas : MonoBehaviour
{
    public void AntidoteUsed()
    {
        FindObjectOfType<PlayerMovement>().canMove = true;
        FindObjectOfType<CatchingMenu>().gameObject.SetActive(false);
        FindObjectOfType<PlayerMovement>().removeItemFromINV(new Item { itemType = Item.ItemType.Antidote, amount = 1 });
        gameObject.SetActive(false);
    }
}
