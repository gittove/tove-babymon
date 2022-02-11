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
    [SerializeField] private Vector3 sweepOffset = new Vector3(0, -8, -3);
    [SerializeField] private Vector3 sweepRotation = new Vector3(0, 8, -3);

    public float xBorderLeft = -3f;
    public float xBorderRight = 13f;
    public float zBorderUp = 5f;
    public float zBorderDown = -17f;
    bool isSweeping;
    Vector3 initialRotation;


    ///// SUPeR SLERPeR 
    public Vector3 startPos;
    public Vector3 endPos;
    public float journeyTime = 1.0f;
    public float speed;
    public bool repeatable;

    float startTime;
    Vector3 centerPoint;
    Vector3 startRelCenter;
    Vector3 endRelCenter;


    void Awake() 
    {
        transform.position = playerTransform.position + offset;
        startTime = Time.time;
        isSweeping = false;
        Vector3 initialRotation = new Vector3(32f,0f,0f);
        transform.rotation = Quaternion.Euler(initialRotation); 
    }

    void LateUpdate() 
    {
        if(Input.GetKey(KeyCode.C))
        {
            isSweeping = true;
            CameraSweepBack();
        }
        else
        {
            CameraFollowPlayer();
            isSweeping = false;
        } 
        
    }

    void CameraFollowPlayer()
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, 0, playerTransform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        transform.position = new Vector3(
            Mathf.Clamp(smoothedPosition.x, xBorderLeft, xBorderRight),
            smoothedPosition.y,
            Mathf.Clamp(smoothedPosition.z, zBorderDown, zBorderUp)
        );
        //transform.rotation = Quaternion.Euler(initialRotation);

    }


    void CameraSweep()
    {
        //SetCameraDirection();
        // Positions
        //Vector3 desiredPosition = playerTransform.position + sweepOffset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, sweepSmoothSpeed * Time.deltaTime);
        // Rotations
        //transform.position = smoothedPosition;
        //Debug.Log(smoothedPosition);

        Debug.Log("camera pos: "+transform.position);
        Debug.Log("player offset pos: "+ (playerTransform.position + sweepOffset));
        // The center of the arc
        Vector3 center = (transform.position + playerTransform.position + sweepOffset) * 0.5f;
        
        // move the center a bit downwards to make the arc vertical
        center += new Vector3(2, 2, 0);
        Debug.Log("center pos: "+center);
        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = transform.position - center;
        Vector3 setRelCenter = playerTransform.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(
            riseRelCenter, 
            setRelCenter, 
            2f * Time.deltaTime);
        //transform.position = Vector3.Slerp(
        //    transform.position, 
        //    playerTransform.position + sweepOffset, 
        //    2f * Time.deltaTime);
        
        Quaternion lookOnLook = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, 2f * Time.deltaTime);

        //transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        //transform.position += center;

    }

    public void GetCenter(Vector3 direction) {
        startPos = transform.position;
        endPos = playerTransform.position + sweepOffset;

        centerPoint = (startPos + endPos) * .5f;
        centerPoint -= new Vector3(0, 2, 0); 
        centerPoint = new Vector3(centerPoint.x, centerPoint.y * -1f, centerPoint.z);
        centerPoint -= direction;
        startRelCenter = startPos - centerPoint;
        endRelCenter = endPos - centerPoint;
    }


    void CameraSweepBack()
    {
        GetCenter(Vector3.up);

        if(!repeatable) {
            float fracComplete = (Time.time - startTime) / journeyTime * speed;
            transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete * speed);
            transform.position += centerPoint;
            //Quaternion lookOnLook = Quaternion.LookRotation(playerTransform.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, 2f * Time.deltaTime);
        }
        if (repeatable) {
            float fracComplete = Mathf.PingPong(Time.time - startTime, journeyTime / speed);
            transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete * speed);
            transform.position += centerPoint;
            if (fracComplete >= 1) {
                startTime = Time.time;
            }
        }
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