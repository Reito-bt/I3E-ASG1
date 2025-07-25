using UnityEngine;
/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script handles the behavior of enemy players in the game. It detects collisions with projectiles and reduces the enemy's health accordingly.
* When the enemy's health reaches zero, it is destroyed. The script also updates the score in the UI when the enemy is hit.
*/

public class EnemyPlayerBehaviour : MonoBehaviour
{
    public int health = 100; // Health of the enemy
    public int damageTakenFromPlayer = 10; // Damage taken from player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Enemy is getting hit by the bullet!");
            health -= damageTakenFromPlayer; // Reduce health when hit by a projectile
            Debug.Log("Enemy hit by projectile! Health: " + health);
            UI_Manager.AddScore(10); // Add score to UI
            Destroy(collision.gameObject); // Destroy the projectile after collision
            if (health <= 0)
            {
                Debug.Log("Enemy defeated!");
                Destroy(gameObject); // Destroy the enemy if health is zero or below
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
