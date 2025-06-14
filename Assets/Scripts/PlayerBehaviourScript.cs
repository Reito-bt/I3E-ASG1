using UnityEngine;

public class CharcaterBehaviourScript : MonoBehaviour
{
    private DoorBehaviour door; // Reference to the door that the character can interact with
    private KeyBehaviour key; // Reference to the key that the character can collect
    private bool canInteract = false; // Flag to check if the character can interact with objects
    public float InteractionDistance = 5f; // Distance within which the character can interact with objects
    public int score = 0; // Score of the character
    public int damagetakenfromEnemy = 10; // Damage taken from enemy
    public GameObject Projectile; // Reference to the projectile prefab
    public float fireStrength = 1000f; // Speed of the projectile

    public int health = 100; // Health of the character

    public Transform SpawnPoint; // Reference to the player's transform if needed

    public bool greenKeyCollected = false; // Flag to check if the green key is collected

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision) // Handle collisions with other objects
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Character collided with laser!");
            health -= 10; // Reduce health when hit by a laser
            UI_Manager.UpdateHealth(health); // Update UI when hit by laser
            Debug.Log("Character hit by laser! Health: " + health);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Character collided with projectile!");
            health -= damagetakenfromEnemy;
            UI_Manager.UpdateHealth(health); // Update UI when hit by laser
            Debug.Log("Character hit by projectile! Health: " + health);
            Destroy(collision.gameObject); // Destroy the projectile after collision
        }
    }
    void Start()
    {
        // Initialize character health or other properties if needed
        Debug.Log("Character initialized with health: " + health);
        UI_Manager.UpdateHealth(health); // Update UI with initial health
        
    }

    void OnFire()
    {
        GameObject newProjectile = Instantiate(Projectile, SpawnPoint.position, Projectile.transform.rotation);
        Vector3 fireForce = SpawnPoint.forward * fireStrength;
        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);
    }

    public void CollectGreenKey(GameObject keyObject)
    {
        greenKeyCollected = true;
        Debug.Log("Green key collected!");
        Destroy(keyObject);
    }

    void OnInteract()
    {
    // Collect the key if looking at it
        if (canInteract && key != null && key.gameObject.CompareTag("GreenKey") && !greenKeyCollected)
        {
            CollectGreenKey(key.gameObject);
            canInteract = false;
            return;
        }

        // Open the door if looking at it and key is collected
        if (canInteract && door != null && door.gameObject.CompareTag("GreenDoor") && greenKeyCollected)
        {
            Debug.Log("Character interacted with the door: " + door.name);
            door.Interact();
            canInteract = false;
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
                key = hitInfo.collider.GetComponent<KeyBehaviour>();
                Debug.Log("Character can collect the key: " + hitInfo.collider.name);
                // Here you can add logic to collect the key, e.g., increase score or inventory
            }
        }
    }
}
