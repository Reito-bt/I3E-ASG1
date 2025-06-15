using UnityEngine;

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
