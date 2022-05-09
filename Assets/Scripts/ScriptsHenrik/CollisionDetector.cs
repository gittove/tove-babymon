using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private GameObject _carryBabyBarCanvas;
    [SerializeField] private GameObject _carryBabyBar;
    [SerializeField] private ScriptableVariableInt _carryBabyTime;
    [SerializeField] private KeyCode pickupKeyCode;
    [SerializeField] public string playerID;
    private GameObject MoveableObject;
    private GameObject _currentlyHeldObject;
    private GameObject Baby;
    private IDictionary<GameObject, float> multipleMoveables = new Dictionary<GameObject, float>{};
    private Coroutine pickUpBaby;
    private Rigidbody _rbPlayer;

    // Components
    public PlayerControllerNoGrid1 movement;
    private Material _carryBabyBarMat;

    // Events
    [SerializeField] private UnityEvent isPickingUpEvent;
    [SerializeField] private UnityEvent isDroppingEvent;

    // Floats
    [SerializeField] private float smoothSpeed = 1f;
    [SerializeField] private float pickUpTime = 1.2f;
    
    // Ints
    private int _carryTime;

    // Booleans
    private bool canPickup;
    private bool isGrabbing;
    private bool isHoldingBaby;

    void Awake() 
    {
        playerID         = "001";
        canPickup        = false;
        isGrabbing       = false;
        _carryTime       = _carryBabyTime.Value;
        _carryBabyBarMat = _carryBabyBar.GetComponent<Image>().material;

        _carryBabyBarMat.SetFloat("_StartTime", _carryTime);
        _carryBabyBarCanvas.SetActive(false);

        _rbPlayer = GetComponentInParent<Rigidbody>();
    }

    void Update() 
    {
        HandleMultiplePickups();
        PickupObject();
        if (isGrabbing || isHoldingBaby)
            _animationManager.SetParameterBool("IsCarrying", true);
        else
            _animationManager.SetParameterBool("IsCarrying", false);
    }

    private void LateUpdate() 
    {
        TranslatePickup();
    }
    
    /*
    If the player is close to a moveable object and is not already carrying an object
    the player will start carrying the object if "pickupkeyCode" is pressed
    If pickupKeyCode is pressed while the player is holding an object, the object will be released
    */
    void PickupObject()
    {
        if (canPickup && !isGrabbing)
        {
            if (Input.GetKeyDown(pickupKeyCode))
            {
                if (isHoldingBaby) return;
                isGrabbing = true;

                _currentlyHeldObject = MoveableObject;

                // Slightly move the grabbers for a moment
                transform.localPosition = new Vector3(
                    transform.localPosition.x, 
                    transform.localPosition.y, 
                    transform.localPosition.z-0.3f);
                
                // Set moveable object to be a child to grabbers
                _currentlyHeldObject.transform.parent = this.transform;
                
                // Turn on Kinematic and Trigger for the moveable object
                if (_currentlyHeldObject.TryGetComponent(out Rigidbody rbody))
                {
                    rbody.isKinematic = true;
                }
                if (_currentlyHeldObject.TryGetComponent(out Collider collider))
                {
                    collider.isTrigger = true;
                }
                
                // Set player ID to the objects ID
                playerID = _currentlyHeldObject.GetComponent<ObjectID>().objectID;
                
                // Play pickup animation and start Coroutine to make the player stand still
                StartCoroutine(DisablePlayerMovement());
                return;
            } 
        }

        else if (Input.GetKeyDown(pickupKeyCode) && (isGrabbing || isHoldingBaby))
        {
            if (isHoldingBaby)
            {
                PutDownBaby();
                return;
            }

            isGrabbing = false;

            // Release the moveable object by nulling its parent
            _currentlyHeldObject.transform.parent = null;
            
            // Turn off Kinematic and Trigger for the moveable object
            if (_currentlyHeldObject.TryGetComponent(out Rigidbody rbody))
            {
                rbody.isKinematic = false;
            }
            if (_currentlyHeldObject.TryGetComponent(out Collider collider))
            {
                collider.isTrigger = false;
            }
            
            // Reset the player ID
            playerID = "001";

            // Reset the grabbers to the original position
            transform.localPosition = new Vector3(
                transform.localPosition.x, 
                transform.localPosition.y, 
                transform.localPosition.z + 0.3f);
            
            _currentlyHeldObject = null;
        }
    }

    IEnumerator DisablePlayerMovement()
    {
        movement.enabled = false;
        _rbPlayer.velocity = new Vector3(0, 0, 0);
        _animationManager.SetParameterBool("IsPickup", true);
        yield return new WaitForSeconds(pickUpTime);
        _animationManager.SetParameterBool("IsPickup", false);
        movement.enabled = true;
    }
    
    void TranslatePickup()
    {
        if (isHoldingBaby)
        {
            Vector3 desiredPosition = this.transform.position;
            Vector3 smoothedPosition = Vector3.Slerp(
                Baby.transform.position, 
                desiredPosition, 
                smoothSpeed * Time.deltaTime);
            Baby.transform.position = smoothedPosition;
        }
        else if (isGrabbing)
        {   
            // The movable object will smoothly move towards the grabbers position
            Vector3 desiredPosition = this.transform.position;
            Vector3 smoothedPosition = Vector3.Slerp(
                MoveableObject.transform.position, 
                desiredPosition, 
                smoothSpeed * Time.deltaTime);
            MoveableObject.transform.position = smoothedPosition;
        }
    }
    
    private void OnTriggerEnter(Collider coll) 
    {
        if(coll.gameObject.tag == "Moveable" || coll.gameObject.tag == "Toy") 
        {
            multipleMoveables.Add(
                coll.gameObject, 
                Vector3.Distance(
                    coll.gameObject.transform.position, 
                    this.transform.position));
        }
    }

    private void OnTriggerExit(Collider coll) 
    {
        multipleMoveables.Remove(coll.gameObject);
    }
    
    void HandleMultiplePickups()
    {
        if(multipleMoveables.Count > 0)
        {
            canPickup = true;
            float min = float.MaxValue;
            foreach (var item in multipleMoveables)
            {
                if (item.Value < min)
                {
                    MoveableObject = item.Key;
                    min = item.Value;
                }
            }
        } else canPickup = false; 
    }
    
    public void PickUpBaby(GameObject baby)
    {
        if (!isGrabbing)
        {
            Baby                                                   = baby;
            Baby.GetComponent<NavMeshAgentController>().wantPickUp = true;
        }
    }

    private void PutDownBaby()
    {
        GetComponent<PlayerInteractor>().isHoldingBaby         = false;
        isHoldingBaby                                          = false;
        _carryBabyBarCanvas.SetActive(false);

        StopCoroutine(pickUpBaby);

        Baby.GetComponent<NavMeshAgent>().enabled = true;
        Baby.transform.parent                     = null;

        StartCoroutine(DisablePlayerMovement()); // Can remove put down animation for baby...

        playerID                                  = "001";

        transform.localPosition = new Vector3(
            transform.localPosition.x, 
            transform.localPosition.y, 
            transform.localPosition.z + 0.3f);
        Baby.GetComponent<NavMeshAgentController>().wantPickUp = false;
        Baby.GetComponent<NavMeshAgentController>().isPickedUp = false;
    }

    public void OnPickupBaby()
    {
        if (Baby.GetComponent<NavMeshAgentController>().paused)
        {
            Baby.GetComponent<NavMeshAgentController>().paused = false;
        }
        
        GetComponent<PlayerInteractor>().isHoldingBaby         = true;
        isHoldingBaby                                          = true;
        _carryBabyBarCanvas.SetActive(true);
        
        pickUpBaby = StartCoroutine(PickUpBabyTimer(_carryTime, Baby.GetComponent<BabyController>()));
            
        transform.localPosition = new Vector3(
            transform.localPosition.x, 
            transform.localPosition.y, 
            transform.localPosition.z-0.3f);
            
        Baby.transform.parent = this.transform;
            
        playerID = Baby.GetComponent<ObjectID>().objectID;
            
        multipleMoveables.Clear();
            
        StartCoroutine(DisablePlayerMovement());
    }

    IEnumerator PickUpBabyTimer(float time, BabyController controller)
    {
        float _timer = 0f;
        
        while (true)
        {
            _timer += Time.deltaTime;
            _carryBabyBarMat.SetFloat("_TimeValue", _timer);
            if (_timer > time)
            {
                controller.OnWellbeingInteract("003");
                PutDownBaby();
                yield break;
            }

            yield return null;
        }
    }



/*
    void TranslatePickup2()
    {
        // The center of the arc
        Vector3 center = (MoveableObject.transform.position + new Vector3(0, 1, 0));

        // move the center a bit downwards to make the arc vertical
        //center -= new Vector3(0, 1, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = MoveableObject.transform.position - center;
        Vector3 setRelCenter = transform.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        MoveableObject.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        MoveableObject.transform.position += center;

    }
    */
    
    /*
    If the player collides with an object that can be moved, canPickup is set to true
    MoveAbleObject is set to be the object in the scene the player collided with
    If the player exits the collision zone, canPickup is set to false
    */


    

    // following is WIP and nice to have instead of triggers
    /*void ExplosionDamage(Vector3 center, float radius)
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(center, radius, hitColliders, moveableLayerMask);
        for (int i = 0; i < numColliders; i++)
        {
            Debug.Log(hitColliders[i].transform.position);
            Debug.Log(hitColliders); 
        }
    }
    */

}