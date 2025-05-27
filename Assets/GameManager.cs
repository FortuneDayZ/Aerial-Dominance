using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int enemiesDefeated = 0;
    public int enemiesPerBoss = 30;
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;

    public float enemySpeedModifier = 1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void OnEnemyKilled()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= enemiesPerBoss)
        {
            enemiesDefeated = 0;
            enemySpeedModifier += 0.1f; // Makes future enemies slightly faster
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
    }
}
