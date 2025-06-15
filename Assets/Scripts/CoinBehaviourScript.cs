using UnityEngine;
/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script handles the interaction with coins in the game. When a player interacts with a coin, it adds to the score and destroys the coin object.
*/

public class CoinBehaviourScript : MonoBehaviour
{
    public void Interact()
    {
        UI_Manager.AddScore(10); 
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
