using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderLayer_y_update : MonoBehaviour
{
    [SerializeField] float offset;
    void Update()
    {
        int OrderLayer_Multiplier = 10;
        GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y + offset) * OrderLayer_Multiplier * -1);
    }
}
