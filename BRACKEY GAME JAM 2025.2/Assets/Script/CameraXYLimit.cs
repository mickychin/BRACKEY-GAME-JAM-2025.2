using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXYLimit : MonoBehaviour
{
    [SerializeField] Vector2 MinXY;
    [SerializeField] Vector2 MaxXY;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinXY.x, MaxXY.x), Mathf.Clamp(transform.position.y, MinXY.y, MaxXY.y), transform.position.z);
    }
}
