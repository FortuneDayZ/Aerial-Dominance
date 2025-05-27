using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
            Destroy(other.gameObject); // Destroy bullet

            if (health <= 0)
            {
                Destroy(gameObject); // Destroy enemy
            }
        }
    }
}
