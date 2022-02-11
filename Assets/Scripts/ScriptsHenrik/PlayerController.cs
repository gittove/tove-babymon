using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private AnimationManager _animationManager;
    [SerializeField] private GameObject _3Dmodel;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float rotationSpeed = 0.01f;

    /*
    When the player is close to the point it is moving to, 
    input for movement is possible again
    */
    [SerializeField] private float distanceUntilInputEnabled = 0.05f;
    public Transform movePoint;

    private IDictionary<KeyCode, Vector3> KeyCodes = new Dictionary<KeyCode, Vector3>
    {
        {KeyCode.W, new Vector3(0, 0, 1)},
        {KeyCode.A, new Vector3(-1, 0, 0)},
        {KeyCode.S, new Vector3(0, 0, -1)},
        {KeyCode.D, new Vector3(1, 0, 0)}
    };

    private List<KeyCode> KeyCodeMemory = new List<KeyCode>();
    private List<KeyCode> PossibleKeyCodes = new List<KeyCode> {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
    public float speed = 0.1f;
    private Vector3 relativePosition;
    private Quaternion targetRotation;
    private bool rotating = false;
    float rotationTime;
    private void Awake()
    {
        _animationManager = _3Dmodel.GetComponent<AnimationManager>();

        isMoving = false;

        movePoint.parent = null;
    }

    void Update()
    {
        // Check which Keycodes are possible based on surrounding colliders
        RaycastColliderFinder();
        // Organize key input commands so the player know what input to act upon
        KeyCodeOrganizer();
        // If the input is valid the player can move    
        Move();
        HandleAnimations();
        RotatePlayer();
    }

    void RaycastColliderFinder()
    {
        var ray0 = new Ray(this.transform.position, KeyCodes.ElementAt(0).Value);
        var ray1 = new Ray(this.transform.position, KeyCodes.ElementAt(1).Value);
        var ray2 = new Ray(this.transform.position, KeyCodes.ElementAt(2).Value);
        var ray3 = new Ray(this.transform.position, KeyCodes.ElementAt(3).Value);

        RaycastHit hit0;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        if (Physics.Raycast(ray0, out hit0, 1f))
        {
            if (hit0.transform.gameObject.tag == "Obstacle")
            {
                if (PossibleKeyCodes.Contains(KeyCode.W))
                {
                    PossibleKeyCodes.Remove(KeyCode.W);
                }
            }
        }
        else if (!PossibleKeyCodes.Contains(KeyCode.W))
        {
            PossibleKeyCodes.Add(KeyCode.W);
        }

        if (Physics.Raycast(ray1, out hit1, 1f))
        {
            if (hit1.transform.gameObject.tag == "Obstacle")
            {
                if (PossibleKeyCodes.Contains(KeyCode.A))
                {
                    PossibleKeyCodes.Remove(KeyCode.A);
                }
            }
        }
        else if (!PossibleKeyCodes.Contains(KeyCode.A))
        {
            PossibleKeyCodes.Add(KeyCode.A);
        }

        if (Physics.Raycast(ray2, out hit2, 1f))
        {
            if (hit2.transform.gameObject.tag == "Obstacle")
            {
                if (PossibleKeyCodes.Contains(KeyCode.S))
                {
                    PossibleKeyCodes.Remove(KeyCode.S);
                }
            }
        }
        else if (!PossibleKeyCodes.Contains(KeyCode.S))
        {
            PossibleKeyCodes.Add(KeyCode.S);
        }

        if (Physics.Raycast(ray3, out hit3, 1f))
        {
            if (hit3.transform.gameObject.tag == "Obstacle")
            {
                if (PossibleKeyCodes.Contains(KeyCode.D))
                {
                    PossibleKeyCodes.Remove(KeyCode.D);
                }
            }
        }
        else if (!PossibleKeyCodes.Contains(KeyCode.D))
        {
            PossibleKeyCodes.Add(KeyCode.D);
        }
    }


    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) < distanceUntilInputEnabled)
        {
            if (KeyCodeMemory.Count > 0)
            {
                for (int i = 0; i < KeyCodes.Count; i++)
                {
                    if (KeyCodeMemory.Last() == KeyCodes.ElementAt(i).Key &&
                        PossibleKeyCodes.Contains(KeyCodeMemory.Last()))
                    {
                        movePoint.position += KeyCodes.ElementAt(i).Value;
                    }
                }
            }
        }
    }


    void KeyCodeOrganizer()
    {
        // Add KeyCodes to list
        for (int i = 0; i < KeyCodes.Count; i++)
        {
            KeyCode currentKeyCheck = KeyCodes.ElementAt(i).Key;
            // Add KeyCodes to list
            if (Input.GetKeyDown(currentKeyCheck))
            {
                if (!KeyCodeMemory.Contains(currentKeyCheck))
                {
                    KeyCodeMemory.Add(currentKeyCheck);
                }
            }
            // Remove KeyCodes from list
            else if (Input.GetKeyUp(currentKeyCheck))
            {
                KeyCodeMemory.RemoveAll(x => x == currentKeyCheck);
            }
        }
    }

    /*
    void SetPlayerDirection()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = movePoint.position - transform.position;
        targetDirection.x = Mathf.RoundToInt(targetDirection.x);
        targetDirection.z = Mathf.RoundToInt(targetDirection.z);
        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        newDirection.x = Mathf.RoundToInt(newDirection.x);
        newDirection.z = Mathf.RoundToInt(newDirection.z);
        Debug.Log(newDirection);
        
        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        //transform.rotation = Quaternion.LookRotation(newDirection);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0,0,90), 0.2f);
    }
    */

    void RotatePlayer()
    {   Debug.Log(rotationTime);
        if (KeyCodeMemory.Count != 0)
        {
            relativePosition = (KeyCodes[KeyCodeMemory.Last()] + transform.position) - transform.position;
            targetRotation = Quaternion.LookRotation(relativePosition);
            rotating = true;
        }
        if (rotating)
        {
            rotationTime = Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
        }
        if (rotationTime > 1)
        {
            rotating = false;
        }

    }

    void HandleAnimations()
    {
        if (KeyCodeMemory.Count == 0 && isMoving)
        {
            Debug.Log("Is not moving");
            _animationManager.SetParameterBool("IsMoving", false);
            isMoving = false;
        }
        
        else if (KeyCodeMemory.Count != 0 && !isMoving)
        {
            Debug.Log("Is moving");
            _animationManager.SetParameterBool("IsMoving", true);
            isMoving = true;
        } 
    }
}