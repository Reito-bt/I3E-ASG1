using UnityEngine;
/*
*Author: Muhammad Rasuli Bin Rosli
*Date: 16/6/2025
*Description: This script handles the behavior of doors in the game. It allows the player to open and close doors by toggling their rotation on the Y-axis.
* The door's state is tracked using a boolean variable, and the door's rotation is adjusted accordingly when the player interacts with it.
*/


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
