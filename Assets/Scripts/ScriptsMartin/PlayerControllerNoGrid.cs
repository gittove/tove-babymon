using UnityEngine;

public class PlayerControllerNoGrid : MonoBehaviour
{
    private Rigidbody rb;

    public float movementSpeed = 5f;
    public float jumpForce = 5f;

    Vector3 dir;
    Quaternion rotation;

    public LayerMask groundMask;
    public Transform groundCheck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        if(dir.magnitude > 0.05f)
            rotation = Quaternion.LookRotation(dir, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 20f);
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, 0f, y).normalized * movementSpeed;

        float gravityMultiplier = rb.velocity.y < 0 ? 1.2f : 1f;

        rb.velocity = new Vector3(dir.x, rb.velocity.y * gravityMultiplier, dir.z);
    }
    public bool Grounded() => Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
}