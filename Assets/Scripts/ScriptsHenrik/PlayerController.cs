using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    
    /*
    When the player is close to the point it is moving to, 
    input for movement is possible again
    */
    [SerializeField] private float distanceUntilInputEnabled = 0.05f;
    public Transform movePoint;
    
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
    }

    void SetPlayerDirection()
    {
        
    }

    
}
