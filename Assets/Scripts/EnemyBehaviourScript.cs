using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public int damageTakenFromPlayer = 10; // Damage taken from player
    public int health = 100; // Health of the enemy
    public float shootingRange = 10f; // Range within which the enemy can shoot
    public GameObject Bullet; // Bullet prefab to be fired
    public Transform firePoint;
    public float bulletForce = 500f;
    public float fireRate = 2f; // seconds between shots
    public Transform target; // player transform
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        InvokeRepeating(nameof(ShootAtPlayer), 1f, fireRate);
        
    }

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
    void ShootAtPlayer()
    {

        // Calculate direction to player
        Vector3 direction = (target.position - firePoint.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > shootingRange) return; // Check if the player is within shooting range


        // Create and fire the bullet
        GameObject bullet = Instantiate(Bullet, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(direction * bulletForce);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
