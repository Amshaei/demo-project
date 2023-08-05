using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemyPrefab; // You will assign your TestEnemyPrefab here through Inspector
    public GameObject currentEnemy; // reference to the current enemy

    void Start() {
        SpawnEnemy();
    }

    public void SpawnEnemy() {
        // Instantiate the enemy at this game object's position
        currentEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}