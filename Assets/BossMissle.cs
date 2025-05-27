using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 moveDirection;

    void Start()
    {
        // Set the movement direction to "up" at the time of firing
        moveDirection = transform.up;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Damage the player
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1); // Adjust the damage if needed
            }

            Destroy(gameObject); // Remove the missile
        }

        
    }
}

