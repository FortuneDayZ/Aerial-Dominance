using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Bounds backgroundBounds;

    void Start()
    {
        // Grab the background's bounds using its SpriteRenderer
        GameObject background = GameObject.Find("Background");
        if (background != null)
        {
            SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                backgroundBounds = sr.bounds;
            }
            else
            {
                Debug.LogWarning("No SpriteRenderer found on Background!");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject named 'Background' found!");
        }
    }

    void LateUpdate()
    {
        // Clamp the player within the bounds
        float clampedX = Mathf.Clamp(transform.position.x, backgroundBounds.min.x, backgroundBounds.max.x);
        float clampedY = Mathf.Clamp(transform.position.y, backgroundBounds.min.y, backgroundBounds.max.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
