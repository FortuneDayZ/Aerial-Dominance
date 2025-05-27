using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 0.25f;

    public AudioClip gunShotClip;
    private AudioSource audioSource;

    private float nextFireTime = 0f;

    private Transform leftFirePoint;
    private Transform rightFirePoint;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 🔍 Automatically find fire points by name
        leftFirePoint = transform.Find("LeftFirePoint");
        rightFirePoint = transform.Find("RightFirePoint");

        // 🛑 Warn if not found (optional, helpful for debugging)
        if (leftFirePoint == null || rightFirePoint == null)
        {
            Debug.LogWarning("Fire points not found! Make sure they're named 'LeftFirePoint' and 'RightFirePoint' and are children of the Player.");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        if (leftFirePoint != null)
            Instantiate(bulletPrefab, leftFirePoint.position, leftFirePoint.rotation);
        if (rightFirePoint != null)
            Instantiate(bulletPrefab, rightFirePoint.position, rightFirePoint.rotation);

        if (gunShotClip != null)
            audioSource.PlayOneShot(gunShotClip, 0.7f); // 🎵 Slightly reduced volume
    }
}
