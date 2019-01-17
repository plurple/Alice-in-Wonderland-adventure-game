using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInstructions : MonoBehaviour {

    private bool Instructions = false; // check if instructions on


    //when in trigger display the message
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
                Instructions = true;
            
        }

    }

    // when you leave the trigger don't display the message
    void OnTriggerExit(Collider other)
    {
        Instructions = false;

    }

    //handle displaying messages
    public void OnGUI()
    {
        if (Instructions)
        {
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 108), Screen.width, Screen.height), "Pickup the Blue potions and press 1 to Heal.");
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 120), Screen.width, Screen.height), "Pickup the purple potions and press 2 to Shrink.");
        }
        
    }
}

