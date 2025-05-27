using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject gameOverScreen; // Drag your image here in the Inspector
    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverScreen.SetActive(false); // Hide image at start
    }

    public void TakeDamage(int amount)
    {
        if (isGameOver) return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true); // Show the image
    }
}
