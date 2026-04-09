using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 8f;
    public float maxSpeed = 2f;
    public float dragWhenIdle = 4f;
    public float rotationSpeed = 10f;
    public float tiltAmount = 15f;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis(horizontalAxis);
        float moveZ = Input.GetAxis(verticalAxis);

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        if (movement.magnitude > 0.1f)
        {
            rb.drag = 1f;
            rb.AddForce(movement * moveForce, ForceMode.Acceleration);
        }
        else
        {
            rb.drag = dragWhenIdle;
        }

        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}