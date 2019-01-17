using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crosshair : MonoBehaviour
{
    public Texture2D crosshair; //texture for the crosshair

	//displays the crosshair
    private void OnGUI()
    {
        float xMin = (Screen.width - Input.mousePosition.x) - (crosshair.width / 2);//crosshairs x position
        float yMin = (Screen.height - Input.mousePosition.y) - (crosshair.height / 2);//crosshairs y porsition
        GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width, crosshair.height), crosshair);//draw the crosshair
    }
}
