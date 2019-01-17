using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCursor : MonoBehaviour

{
    

    // Use this for initialization
    void Start ()
    {
        //used to lock the curser onto the screen on the main menu when you reload the menu.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
