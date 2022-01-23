using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public Transform grabbers;
    private bool isGrabbing;
    private Vector3 facingDirection;
    [SerializeField] private float sightDistance = 5f; 

    void Start() 
    {
        isGrabbing = false;
    }
    
    void Update() 
    {
        PlayerSight();
    }
    /*private void OnTriggerEnter(Collider coll) 
    {
        
        Debug.Log(coll.tag);
        if(coll.tag == "Moveable")
        {
            Grab(coll);
        }
        
    }
    */

    private void PlayerSight()
    {
        /*
        Vector3 currentPos = transform.position;
        
        Ray ray = new Ray(transform.position, grabbers.position);
        RaycastHit hit;
        Debug.DrawLine(transform.position, hit.point, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            
            Debug.Log(hit.transform.gameObject.tag);
        }
        
        if (environmentInfo.collider == true && environmentInfo.collider.tag == "Moveable") 
        {
            
            if (Input.GetButton("Fire1"))
            {
                isGrabbing = true;
                environmentInfo.collider.gameObject.transform.parent = grabbers;
                environmentInfo.collider.gameObject.transform.position = grabbers.position;
                environmentInfo.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;   
            } else {
                isGrabbing = false;
                environmentInfo.collider.gameObject.transform.parent = null;
                environmentInfo.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                
            }  
        }
        */
    }
}
