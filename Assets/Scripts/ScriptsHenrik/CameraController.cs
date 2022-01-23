using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] private float smoothSpeed = 3f;
    [SerializeField] private float sweepSmoothSpeed = 10f;
    [SerializeField] private Vector3 offset = new Vector3(0, 23, -9);
    [SerializeField] private Vector3 sweepOffset = new Vector3(0, 8, -3);
    [SerializeField] private Vector3 sweepRotation = new Vector3(0, 8, -3);

    
    void LateUpdate() 
    {
        if(Input.GetKey(KeyCode.C))
        {
            CameraSweep();
        }
        else CameraFollowPlayer();
    }

    void CameraFollowPlayer()
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, 0, 0) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
    void CameraSweep()
    {
        SetCameraDirection();
        // Positions
        Vector3 desiredPosition = playerTransform.position + sweepOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, sweepSmoothSpeed * Time.deltaTime);
        // Rotations
        

        transform.position = smoothedPosition;
        Debug.Log(smoothedPosition);
    }

    void SetCameraDirection()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = playerTransform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = sweepSmoothSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}