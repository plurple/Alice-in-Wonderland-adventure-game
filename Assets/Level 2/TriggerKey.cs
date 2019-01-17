using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKey : MonoBehaviour {

    public GameObject TriangleKey, CircleKey, SquareKey, Riddle;//get the different items to be created
    private bool Exited = false; //check if you have already left the trigger
    

    //when the player leaves the trigger create the riddle and 3 keys
    public void OnTriggerExit(Collider other)
    {
        if (!Exited && other.gameObject.tag == "Player")
        {
            Exited = !Exited;
            GameObject.FindWithTag("Instruction").SetActive(false);
            CreateCircleKey();
            CreateSquareKey();
            CreateTriangleKey();
            Instantiate(Riddle);
        }
    
    }

    //create the triangle key
    public void CreateTriangleKey()
    {
        Instantiate(TriangleKey);
        
    }

    //create the circle key
    public void CreateCircleKey()
    {
        Instantiate(CircleKey);
        
    }

    //create the square key
    public void CreateSquareKey()
    {
        Instantiate(SquareKey);
    }
}
