using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool isSpinning = false;
    private float spinDuration = 2f;
    private float spinTimer = 0f;
    private Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (!isSpinning)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();
        }

        if (isSpinning)
        {
            spinTimer -= Time.deltaTime;

            if (spinTimer <= 0f)
            {
                isSpinning = false;
                transform.rotation = originalRotation; // Snap back to original rotation
                rb.angularVelocity = 0f; // Stop any leftover spinning force
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isSpinning = true;
            spinTimer = spinDuration;
            rb.angularVelocity = 360f;

            // Apply damage to the player
            PlayerHealth health = GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}
