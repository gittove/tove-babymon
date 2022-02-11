using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class PlayerControllerNoGrid1 : MonoBehaviour
{
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private LayerMask _surfaceLayerMask;
    private Rigidbody _rb;
    private Vector3 _dir;
    private Quaternion _rotation;
    
    // Events
    [SerializeField] private UnityEvent _isRunningEvent;

    // Colliders
    private CapsuleCollider _capsuleCollider;
    private BoxCollider _boxCollider;

    // Floats
    [SerializeField] private float _rayDistanceMultiplier = 1.5f;
    [SerializeField] private float _shpereRadiusGroundCheck = 0.5f;
    [SerializeField] private float _gravityIncreasesDown = 1.2f;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _rotationSpeed = 20f;

    private float _horizontalInput;
    private float _verticalInput;
    
    // Booleans
    private bool _isMoving;
    private bool _isJumping;
    private bool _isFalling;
    private bool _aboutToLand; 
    private bool _jumpWasPressed;
    private bool _becameGrounded;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        
        // Get colliders
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _boxCollider = GetComponent<BoxCollider>();
        
        // Set booleans
        _isMoving = false;
        _isJumping = false;
        _isFalling = false;
        _aboutToLand = false;
        _jumpWasPressed = false;
        _becameGrounded = false;
    }

    private void Update()
    {   
        // Check if keys were pressed
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _isMoving = _horizontalInput != 0 || _verticalInput != 0 ? true : false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpWasPressed = true;
        }   
    }

    private void FixedUpdate()
    {   
        // Jumping
        if (_jumpWasPressed && IsGrounded())
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z);
            _isJumping = true;
        } else _isJumping = false;
        
        // Check falling
        if (IsGrounded() && _rb.velocity.y < -1f && !_becameGrounded)
        { 
            _becameGrounded = true;
            _animationManager.PlayLandingGrunt();
            _isFalling = false;
            _aboutToLand = true;
            StartCoroutine(DisableGroundedTrigger());
        } 
        
        // Moving 
        float gravityMultiplier = _rb.velocity.y < 0 ? _gravityIncreasesDown : 1f;
        _dir = new Vector3(_horizontalInput, 0f, _verticalInput).normalized * _movementSpeed;
        _rb.velocity = new Vector3(_dir.x, _rb.velocity.y * gravityMultiplier, _dir.z);
        
        // Rotating
        if (_dir.magnitude > 0.05f)
            _rotation = Quaternion.LookRotation(_dir, Vector3.up);
        transform.rotation = Quaternion.Slerp(
            transform.rotation, _rotation, 
            Time.deltaTime * _rotationSpeed);
        
        HandleAnimations();
        _jumpWasPressed = false;
        _isFalling = true;
    }

    IEnumerator DisableGroundedTrigger()
    {
        yield return new WaitForSeconds(0.5f);
        _becameGrounded = false;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        Physics.SphereCast(
            _capsuleCollider.bounds.center,                             // Origin of ray (center of capsule collider)
            _shpereRadiusGroundCheck,                                    // Sphere radius
            Vector3.down,                                               // Direction of ray
            out hit,                                                    // Information about hit object
            _capsuleCollider.bounds.extents.y * _rayDistanceMultiplier,  // Maximum distance of ray (half the height of the collider)
            _surfaceLayerMask);                                          // Player is only supposed to be able to jump on certain layers
        
        Debug.DrawRay(
            _capsuleCollider.bounds.center, 
            Vector3.down * (_capsuleCollider.bounds.extents.y * _rayDistanceMultiplier));

        float dot = Vector3.Dot(hit.normal, Vector3.up);
        
        if (dot > 0.6f) 
            return true;
        else return false;
    }
    
    void HandleAnimations()
    {
        //Play jumping animation
        if (_isJumping)
        {
            _animationManager.SetParameterTrigger("jump");
            _isJumping = false;
        }

        //Play running animation
        else if (_isMoving && !_isJumping)
        {
            _animationManager.SetParameterBool("IsMoving", true);
            if (Time.frameCount % 60 == 0)
                _isRunningEvent.Invoke();
        }

        //Play idle animation
        else if (!_isMoving && !_isJumping)
            _animationManager.SetParameterBool("IsMoving", false);
    }

    public void OnPause(bool isPause)
    {
        this.enabled = isPause ? false : true;
        _rb.velocity = new Vector3(0, 0, 0);
        _animationManager.SetParameterBool("IsMoving", false);
    }
}
