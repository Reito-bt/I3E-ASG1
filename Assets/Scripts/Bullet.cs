using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject); // Destroy the bullet when it hits the environment
        }
       
    
        if (collision.gameObject.CompareTag("GreenDoor"))
        {
            Destroy(gameObject); // Destroy the door if it collides with a bullet
        }
    
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
