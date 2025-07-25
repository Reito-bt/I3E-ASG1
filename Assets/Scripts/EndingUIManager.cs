using UnityEngine;
using TMPro;
/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script manages the ending UI of the game, displaying the final score and health remaining when the game ends.
* It uses a singleton pattern to ensure that only one instance of the UI manager exists, allowing easy access to the UI elements from other scripts.
*/

public class EndingUIManager : MonoBehaviour
{
    public GameObject endingPanel; // Assign the Panel in Inspector
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public static EndingUIManager Instance; // Singleton instance
    void Start()
    {
        endingPanel.SetActive(false); // Ensure the ending panel is hidden at the start
    }


    public void ShowEndingUI(int score, int health)
    {
        endingPanel.SetActive(true);
        scoreText.text = "Total Score: " + score;
        healthText.text = "Health Remaining: " + health;
    }
    void Awake()
    {
        Instance = this; // Ensure that there is only one instance of UI_Manager
    }
}
