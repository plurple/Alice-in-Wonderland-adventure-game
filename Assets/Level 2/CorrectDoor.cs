using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectDoor : MonoBehaviour
{
    
    //checks the answer to the puzzle
    public void AnswerPuzzle()
    {
        GameObject Player = GameObject.FindWithTag("Player"); //finds the player
        //checks the player has the correct key and is the correct size
        if (Player.GetComponent<Inventory>().haveTriangleKey && GameObject.FindWithTag("Player").GetComponent<Sizing>().Size == -1)
        {

            Player.GetComponent<Player>().SavePlayer(); //saves the players health and energy
            Player.GetComponent<Inventory>().SavePlayer();// saves the players inventory
            SceneManager.LoadScene("Level 3/Level 3"); // loads the 3rd level
        }
        else
        {
            //if not the correct size or key hurt the player
            GameObject.FindWithTag("Door").GetComponent<Punishment>().Punish();
        }
    }
}
