using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float fallLimit = -5f;

    public float pushForce = 4f;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private Rigidbody rb;
    private GameManager gameManager;
    private bool isEliminated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (isEliminated) return;

        float moveX = Input.GetAxis(horizontalAxis);
        float moveZ = Input.GetAxis(verticalAxis);

        Vector3 movement = new Vector3(-moveX, 0f, -moveZ).normalized;

        Vector3 targetVelocity = movement * moveSpeed;

        rb.velocity = new Vector3(
            targetVelocity.x,
            rb.velocity.y,
            targetVelocity.z
        );

        CheckFall();
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerMovement otherPlayer = collision.gameObject.GetComponent<PlayerMovement>();

        if (otherPlayer != null)
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

            if (otherRb != null)
            {
                Vector3 pushDirection = collision.transform.position - transform.position;
                pushDirection.y = 0f;
                pushDirection.Normalize();

                otherRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

    void CheckFall()
    {
        if (transform.position.y < fallLimit)
        {
            isEliminated = true;

            if (gameManager != null)
            {
                gameManager.PlayerDied(gameObject);
            }
        }
    }
}