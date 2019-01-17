using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeInstructions : MonoBehaviour {

    private bool Instructions = false; //make the instructions false by default
    
    //check if the player enters the trigger volume
    void OnTriggerEnter(Collider other)
    {
        //only triggers for the player
        if (other.gameObject.tag == "Player")
        { 
                Instructions = true;//make the instructions appear
        }
            
    }

    //when the player leaves the trigger box turn off the instructions
    void OnTriggerExit(Collider other)
    {
        Instructions = false; //make the instructions false

    }

    //used to display text on the screen
    public void OnGUI()
    {
        //when the instructions are active display the message
        if (Instructions)
        GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 120), Screen.width, Screen.height), "Pickup the cakes and press 3 to Grow.");
    }
}
