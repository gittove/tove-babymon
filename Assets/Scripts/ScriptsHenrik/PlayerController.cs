using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    
    /*
    When the player is close to the point it is moving to, 
    input for movement is possible again
    */
    [SerializeField] private float distanceUntilInputEnabled = 0.05f;
    public Transform movePoint;
    private Vector3 oldMovePosition;
    private Vector3 initialFacingDir;
    
    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        Vector3 oldMovePosition = movePoint.position;
        if (Vector3.Distance(transform.position, movePoint.position) < distanceUntilInputEnabled)
        {
            if(Input.GetKey(KeyCode.W))
            {
                movePoint.position += new Vector3(0, 0, 1);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                movePoint.position += new Vector3(0, 0, -1);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                movePoint.position += new Vector3(-1, 0, 0);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                movePoint.position += new Vector3(1, 0, 0);
            }
        }
        SetPlayerDirection();
    }

    void SetPlayerDirection()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = movePoint.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    
}
