using UnityEngine;

public class CharcaterBehaviourScript : MonoBehaviour
{
    int health = 100;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
