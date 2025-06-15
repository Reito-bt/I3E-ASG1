using UnityEngine;
using TMPro;

public class EndingUIManager : MonoBehaviour
{
    public GameObject endingPanel; // Assign the Panel in Inspector
    public TMP_Text scoreText;
    public TMP_Text healthText;

    public void ShowEndingUI(int score, int health)
    {
        endingPanel.SetActive(true);
        scoreText.text = "Total Score: " + score;
        healthText.text = "Health Remaining: " + health;
    }

    public void HideEndingUI()
    {
        endingPanel.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
