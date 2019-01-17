using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    //when the player enters the trigger make the rabbit move through the maze
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            GameObject.FindWithTag("Rabbit").GetComponent<AI>().enabled = true;
    }
}
