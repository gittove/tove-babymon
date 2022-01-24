using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public Transform grabbers;
    private IDictionary<KeyCode, Vector3> KeyCodes = new Dictionary<KeyCode, Vector3>
    {
        { KeyCode.W, new Vector3(0, 0, 1) },
        { KeyCode.A, new Vector3(-1, 0, 0) },
        { KeyCode.S, new Vector3(0, 0, -1) },
        { KeyCode.D, new Vector3(1, 0, 0) }

    };
    private List<KeyCode> KeyCodeMemory = new List<KeyCode>();
    
    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        KeyCodeOrganizer();
        Move();
        SetPlayerDirection();
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
                    if(KeyCodeMemory.Last() == KeyCodes.ElementAt(i).Key)
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
            else if(Input.GetKeyUp(currentKeyCheck))
            {
                 KeyCodeMemory.RemoveAll(x=>x==currentKeyCheck);
            }
        }
    }

    void SetPlayerDirection()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = movePoint.position - transform.position;
        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.Log(singleStep);
        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
