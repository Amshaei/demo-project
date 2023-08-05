using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 20f;
    public float lifeDuration = 2f;
    public float knockbackForce = 50f;
    private float lifeTimer;
    private Rigidbody rb;

    private void OnEnable() {
        lifeTimer = lifeDuration;

        // Get the Rigidbody component and set the velocity
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    private void Update() {
        // decrease the life timer
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) {
            // deactivate the bullet instead of destroying it
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        var enemy = collision.gameObject.GetComponent<TestEnemy>();
        if (enemy != null) {
            var rigidbody = enemy.GetRigidBody();
            if (rigidbody != null) {
                Vector3 direction = collision.contacts[0].point - transform.position;
                direction = direction.normalized;

                Debug.Log("Applying force: " + (direction * knockbackForce));  // Log the force being applied
                rigidbody.AddForce(direction * knockbackForce, ForceMode.Impulse);
            }

            // Deactivate the bullet instead of destroying it
            this.gameObject.SetActive(false);
        }
    }

    // Cleanup velocity on disable
    private void OnDisable() {
        if (rb != null) {
            rb.velocity = Vector3.zero;
        }
    }
}
