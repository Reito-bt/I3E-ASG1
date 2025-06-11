using UnityEngine;

public class CharcaterBehaviourScript : MonoBehaviour
{
    public GameObject Projectile;

    public float fireStrength = 10f; // Speed of the projectile

    public int health = 100;

    public Transform SpawnPoint; // Reference to the player's transform if needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Character collided with laser!");
            health -= 10;
            Debug.Log("Character hit by laser! Health: " + health);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Character collided with projectile!");
            health -= 20;
            Debug.Log("Character hit by projectile! Health: " + health);
            Destroy(collision.gameObject); // Destroy the projectile after collision
        }
    }
    void Start()
    {
        // Initialize character health or other properties if needed
        Debug.Log("Character initialized with health: " + health);
        
    }

    void OnFire()
    {
        GameObject newProjectile = Instantiate(Projectile, SpawnPoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(direction * fireStrength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
