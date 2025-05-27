using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public Transform[] spawnPoints; // Array of spawn locations
    public float spawnInterval = 3f; // Time between spawns

    void Start()
    {
        // Start the repeating enemy spawn
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length); // Pick a random spawn point
        Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
    }
}
