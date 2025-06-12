using UnityEngine;

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
