using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 10f;
    public Transform movePoint;
    
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, movePoint.position) < 0.05f)
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
