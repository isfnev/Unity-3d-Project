using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float rotationSpeed = 10f;

    private Vector3 moveInput, targetVelocity;
    private Vector3 moveVelocity;
    private float x, z;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        moveInput = new Vector3(x, 0f, z);
    }

    void FixedUpdate()
    {
        targetVelocity = moveSpeed * moveInput;
        moveVelocity = Vector3.Lerp(moveVelocity, targetVelocity, (moveInput.magnitude > 0 ? acceleration : deceleration) * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
    }
}
