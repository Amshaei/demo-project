using UnityEngine;

public class TestEnemy : MonoBehaviour {
    public float health = 100f;
    private Spawner spawner; // reference to the Spawner script
    private Rigidbody _rigidbody;


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidBody() {
        return _rigidbody;
    }


    void Start() {
        // Find the Spawner object and get the Spawner script
        spawner = GameObject.FindObjectOfType<Spawner>();
    }

    // This method reduces the enemy's health
    public void TakeDamage(float amount) {
        health -= amount;

        // if health has fallen below zero, deactivate it 
        if (health <= 0f) {
            Die();
        }
    }

    // This method 'kills' the enemy
    void Die() {
        // Inform the spawner that this enemy died
        spawner.SpawnEnemy();

        // Destroy the enemy object
        Destroy(gameObject);
    }
}