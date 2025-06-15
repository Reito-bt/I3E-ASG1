using UnityEngine;
using UnityEngine.SceneManagement;

/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script handles the character's behavior in the game, including interactions with doors, keys, coins, and projectiles. It manages health, score, and interactions with the environment.
* It also handles respawning when the character's health reaches zero.
*/

public class CharcaterBehaviourScript : MonoBehaviour
{
    private DoorBehaviour door;
    private EndingUIManager ending; // Reference to the ending script for interaction
    public AudioClip shootClip; // Assign this in the Inspector
    public AudioClip coinClip; // Assign this in the Inspector for key collection sound
    public AudioClip oofClip; // Assign this in the Inspector for damage sound
    public float laserDamageCooldown = 1f; // Time between damage ticks
    public float lastLaserDamageTime = 0f;
    public AudioClip doorClip; // Assign this in the Inspector for door interaction sound
    private AudioSource audioSource;
    private GameObject coinObject;
    private KeyBehaviour key; // Reference to the key that the character can collect
    private CoinBehaviourScript coin; // Reference to the coin that the character can collect
    private bool canInteract = false; // Flag to check if the character can interact with objects
    public float InteractionDistance = 5f; // Distance within which the character can interact with objects
    public int score = 0; // Score of the character
    public int damagetakenfromEnemy = 10; // Damage taken from enemy
    public GameObject Projectile; // Reference to the projectile prefab
    public float fireStrength = 1000f; // Speed of the projectile
    public int health = 100; // Health of the character
    public int coinsUncollected = 0; // Number of coins collected by the character

    public Transform SpawnPoint; // Reference to the player's transform if needed

    public bool greenKeyCollected = false; // Flag to check if the green key is collected

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision) // Handle collisions with other objects
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Character collided with projectile!");
            health -= damagetakenfromEnemy; // Reduce health when hit by a projectile
            audioSource.PlayOneShot(oofClip); // Play damage sound
            UI_Manager.UpdateHealth(health); // Update UI when hit by laser
            Debug.Log("Character hit by projectile! Health: " + health);
            Destroy(collision.gameObject); // Destroy the projectile after collision
        }
    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            if (Time.time - lastLaserDamageTime >= laserDamageCooldown) // Check if enough time has passed since the last damage tick
            {
                health -= damagetakenfromEnemy;
                audioSource.PlayOneShot(oofClip); // Play damage sound
                UI_Manager.UpdateHealth(health);
                lastLaserDamageTime = Time.time; // Update the last damage time
            }
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Initialize character health or other properties if needed
        Debug.Log("Character initialized with health: " + health);
        UI_Manager.UpdateHealth(health); // Update UI with initial health

        coinsUncollected = GameObject.FindGameObjectsWithTag("Coin").Length;
        UI_Manager.UpdateCoins(coinsUncollected); // Optional: show on UI

    }

    void OnFire()
    {
        GameObject newProjectile = Instantiate(Projectile, SpawnPoint.position, Projectile.transform.rotation);
        Vector3 fireForce = SpawnPoint.forward * fireStrength;
        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);

        if (shootClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootClip);
        }
    }

    public void CollectGreenKey(GameObject keyObject)
    {
        greenKeyCollected = true;
        Debug.Log("Green key collected!");
        Destroy(keyObject);
    }

    void Respawn()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
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
            audioSource.PlayOneShot(doorClip); // Play the door interaction sound
            canInteract = false;
        }
        if (canInteract && coinObject != null)
        {
            coin = coinObject.GetComponent<CoinBehaviourScript>();
            coin.Interact(); // Call the Interact method on the coin script
            score += 10; // Increase score by 10
            coinsUncollected--;
            UI_Manager.UpdateCoins(coinsUncollected); // Update the UI with the remaining coins
            audioSource.PlayOneShot(coinClip); // Play the coin collection sound
            canInteract = false;
            return;
        }

        if (canInteract && ending.gameObject.CompareTag("car"))
        {
            Debug.Log("Character interacted with the car: " + ending.name);
            ending.ShowEndingUI(score, health); // Call the method to show the ending UI
            canInteract = false;
            return;
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
        coinObject = null;

        if (Physics.Raycast(SpawnPoint.position, transform.forward, out hitInfo, InteractionDistance))
        {
            if (hitInfo.collider.CompareTag("GreenDoor"))
            {
                canInteract = true;
                door = hitInfo.collider.GetComponent<DoorBehaviour>();
            }

            else if (hitInfo.collider.CompareTag("GreenKey"))
            {
                canInteract = true;
                key = hitInfo.collider.GetComponent<KeyBehaviour>();
                // Here you can add logic to collect the key, e.g., increase score or inventory
            }

            else if (hitInfo.collider.CompareTag("Coin"))
            {
                canInteract = true;
                coinObject = hitInfo.collider.gameObject;
            }

            else if (hitInfo.collider.CompareTag("car"))
            {
                canInteract = true;
                Debug.Log("Character looking at the car: " + hitInfo.collider.name);
                // Here you can add logic to interact with the car, e.g., enter or exit
                ending = hitInfo.collider.GetComponent<EndingUIManager>();

            }
        }
        if (health <= 0)
        {
            Respawn();
        }
    }
}
