using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] private float smoothSpeed = 3f;
    private Vector3 offset = new Vector3( 0, 23, -9);

    void LateUpdate() 
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, 0, 0) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}