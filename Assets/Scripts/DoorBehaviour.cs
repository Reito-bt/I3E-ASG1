using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    bool doorOpen = false;
    public void Interact()
    {
        if (doorOpen == true)
        {
            // If the door is open, close it
            Vector3 doorRotation = transform.eulerAngles;
            // Toggle the door's rotation between 90 and 0 degrees on the Y-axis
            doorRotation.y -= 90f;
            transform.eulerAngles = doorRotation;
            doorOpen = false; // Update the state of the door to closed
        }
        else if (doorOpen == false)
        {
            // If the door is closed, open it
            Vector3 doorRotation = transform.eulerAngles;
            // Toggle the door's rotation between 0 and 90 degrees on the Y-axis
            doorRotation.y += 90f;
            transform.eulerAngles = doorRotation;
            doorOpen = true; // Update the state of the door to open
        }
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
