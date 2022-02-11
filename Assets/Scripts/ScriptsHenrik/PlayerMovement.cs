using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] public float speed = 6f;
    [SerializeField] public float smoothSpeed = 3f;
    private Vector3 zWizeMovement = new Vector3(0, 0, 1);
    private Vector3 xWizeMovement = new Vector3(1, 0, 0);
    private Vector3 newTransformPosition;
    private Vector3 oldTransformPosition;
    private Vector3 smoothedPosition;
    private Vector3 desiredPosition;
    bool horizontalMovement = false;

    void Update() 
    {
        if (Input.anyKey)
        {
            MoveTwo();
        }
    }

    void Move() 
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

    }

    void MoveTwo()
    {
    
        if(Input.GetKey(KeyCode.W))
        {
            oldTransformPosition = transform.position;
            newTransformPosition = transform.position + zWizeMovement;
            //newTransformPosition += zWizeMovement * speed * Time.deltaTime;
            AdjustPositionToTile(oldTransformPosition, newTransformPosition);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            transform.position = newTransformPosition;
            Debug.Log("Released");
        }
        if(Input.GetKey(KeyCode.S))
        {
            newTransformPosition = transform.position;
            newTransformPosition -= zWizeMovement * speed * Time.deltaTime;
            //AdjustPositionToTile(newTransformPosition);
        }
        if(Input.GetKey(KeyCode.A))
        {
            horizontalMovement = true;
            newTransformPosition = transform.position;
            newTransformPosition -= xWizeMovement * speed * Time.deltaTime;
            //AdjustPositionToTile(newTransformPosition);
        }
        if(Input.GetKey(KeyCode.D))
        {
            horizontalMovement = true;
            newTransformPosition = transform.position;
            newTransformPosition += xWizeMovement * speed * Time.deltaTime;
            //AdjustPositionToTile(newTransformPosition);
        }
        transform.position = newTransformPosition;
    }

    void AdjustPositionToTile(Vector3 oldPos, Vector3 newPos)
    {   
        /*if (horizontalMovement)
        {
            desiredPosition = new Vector3(Mathf.RoundToInt(pos.x)+1, pos.y, pos.z);
            Debug.Log("Horizontal movement, desired position:");
            Debug.Log(desiredPosition);
        }
        else
        {
            desiredPosition = new Vector3(pos.x, pos.y, Mathf.RoundToInt(pos.z)+1);
            Debug.Log("Vertical movement, desired position:");
            Debug.Log(desiredPosition);
        }
        */
        smoothedPosition = Vector3.Lerp(oldPos, newPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        horizontalMovement = false;
    }

    
}
