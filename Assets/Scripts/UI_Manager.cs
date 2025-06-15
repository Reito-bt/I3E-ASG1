using UnityEngine;
using TMPro;
/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script manages the UI elements in the game, including health, score, and coins. It provides static methods to update these values without needing to reference the player directly.
*/

public class UI_Manager : MonoBehaviour
{
    public TMP_Text healthText; // Reference to the TextMeshPro text component for displaying health
    public TMP_Text scoreText; // Reference to the TextMeshPro text component for displaying score
    public TMP_Text coinsText; // Assign in Inspector
    public static UI_Manager Instance;




    private int score = 0; // Player's score

    void Awake()
    {
        Instance = this; // Ensure that there is only one instance of UI_Manager
    }

    public static void UpdateHealth(float currentHealth)
    // Update the health display in the UI without needing to reference the player directly
    {
        if (Instance != null && Instance.healthText != null) // Check if Instance and healthText are not null
            Instance.healthText.text = "Health: " + Mathf.RoundToInt(currentHealth); // Update the health text
    }

    public static void AddScore(int points)
    {
        if (Instance != null && Instance.scoreText != null)
        {
            Instance.score += points;
            Instance.scoreText.text = "Score: " + Instance.score;
        }
    }

    public static void UpdateCoins(int coinsLeft)
    {
        if (Instance != null && Instance.coinsText != null)
        {
            Instance.coinsText.text = "Coins Left: " + coinsLeft;
        }
    }
    
}
