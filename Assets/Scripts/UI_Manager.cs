using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text healthText; // Reference to the TextMeshPro text component for displaying health
    public TMP_Text scoreText; // Reference to the TextMeshPro text component for displaying score

    public static UI_Manager Instance;

    public AudioClip damageClip;
    private AudioSource audioSource;

    

    private int score = 0; // Player's score

    void Awake()
    {
        Instance = this; // Ensure that there is only one instance of UI_Manager
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    public static void UpdateHealth(float currentHealth)
    // Update the health display in the UI without needing to reference the player directly
    {
        if (Instance != null && Instance.healthText != null)
            Instance.healthText.text = "Health: " + Mathf.RoundToInt(currentHealth);

        if (Instance.damageClip != null)
                Instance.audioSource.PlayOneShot(Instance.damageClip);
    }

    public static void AddScore(int points)
    {
        if (Instance != null && Instance.scoreText != null)
        {
            Instance.score += points;
            Instance.scoreText.text = "Score: " + Instance.score;
        }
    }
}
