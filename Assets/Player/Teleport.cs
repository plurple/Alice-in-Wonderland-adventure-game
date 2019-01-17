using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    //when the player enters the trigger save the player and load scene 2
    private void OnTriggerEnter(Collider other)
    {
        GameObject Player = GameObject.FindWithTag("Player");
        if (other.gameObject.tag == "Player")
        {
            Player.GetComponent<Player>().SavePlayer();
            Player.GetComponent<Inventory>().SavePlayer();
            SceneManager.LoadScene("Level 2/Level 2");
            
        }
    }
	
}
