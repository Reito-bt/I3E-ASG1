using UnityEngine;
/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script handles the behavior of keys in the game. When a player collides with a key, it allows the player to collect the key and interact with doors that require that key.
* The key can be collected by the player, and it will trigger the player's key collection method.
*/


public class KeyBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CharcaterBehaviourScript>();
        if (player != null)
        {
            player.CollectGreenKey(gameObject);
        }
    }
}
