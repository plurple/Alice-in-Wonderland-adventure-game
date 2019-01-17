using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInstructions : MonoBehaviour
{
    private bool Instructions; //to check if the instructions are needed


    //when the player enters the trigger show the message
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Instructions = true;

        }

    }


    //when the player leaves the trigger don't show the message
    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            Instructions = false;

        }
    }

    //handle showing the messages
    public void OnGUI()
    {
        if (Instructions)
        {
            GUI.Label(new Rect((Screen.width / 2 - 100), (Screen.height / 2 - 232), Screen.width, Screen.height), "Once you have picked up the sword you can press LMB to attack");
            GUI.Label(new Rect((Screen.width / 2 - 90), (Screen.height / 2 - 220), Screen.width, Screen.height), "You can press Q to switch to attacking with magic.");
            GUI.Label(new Rect((Screen.width / 2 - 100), (Screen.height / 2 - 208), Screen.width, Screen.height), "Which allows you to attack from a distance but requires Energy");
        }
    }
}
