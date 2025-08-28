using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderLayer_Y : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int OrderLayer_Multiplier = 10;
        GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * OrderLayer_Multiplier * -1);
    }
}
