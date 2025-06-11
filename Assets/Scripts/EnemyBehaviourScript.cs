using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    private bool playerInRange = false;
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
    void ShootAtPlayer()
    {

        // Calculate direction to player
        Vector3 direction = (target.position - firePoint.position).normalized;

        // Create and fire the bullet
        GameObject bullet = Instantiate(Bullet, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(direction * bulletForce);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            playerInRange = true;
        }
    }

    // Trigger Exit
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
