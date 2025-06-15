using UnityEngine;

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
