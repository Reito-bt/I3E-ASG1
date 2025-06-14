using UnityEngine;

public class CharcaterBehaviourScript : MonoBehaviour
{
    private DoorBehaviour door; // Reference to the door that the character can interact with
    private bool canInteract = false; // Flag to check if the character can interact with objects
    public float InteractionDistance = 5f; // Distance within which the character can interact with objects
    public int score = 0; // Score of the character
    public int damagetakenfromEnemy = 10; // Damage taken from enemy
    public GameObject Projectile;

    public float fireStrength = 1000f; // Speed of the projectile

    public int health = 100;

    public Transform SpawnPoint; // Reference to the player's transform if needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Character collided with laser!");
            health -= damagetakenfromEnemy;
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
        GameObject newProjectile = Instantiate(Projectile, SpawnPoint.position, Projectile.transform.rotation);
        Vector3 fireForce = SpawnPoint.forward * fireStrength;
        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);
    }

    void OnInteract()
    {
        if (canInteract && door != null)
        {
            door.Interact();
            canInteract = false;
        }

        if (canInteract && key != null)
        {
            Debug.Log("Character collected the key: " + key.name);
            // Here you can add logic to collect the key, e.g., increase score or inventory
            Destroy(key.gameObject); // Destroy the key after collection
            canInteract = false;
        }
        else
        {
            Debug.Log("No object to interact with");
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(SpawnPoint.position, transform.forward * InteractionDistance, Color.red);
        canInteract = false;
        door = null;
        key = null;

        if (Physics.Raycast(SpawnPoint.position, transform.forward, out hitInfo, InteractionDistance))
        {
            if (hitInfo.collider.CompareTag("GreenDoor"))
            {
                canInteract = true;
                door = hitInfo.collider.GetComponent<DoorBehaviour>();
                Debug.Log("Character can interact with the door: " + hitInfo.collider.name);
            }

            if (hitInfo.collider.CompareTag("GreenKey"))
            {
                canInteract = true;
                Debug.Log("Character can collect the key: " + hitInfo.collider.name);
                // Here you can add logic to collect the key, e.g., increase score or inventory
            }
        }
    }
}
