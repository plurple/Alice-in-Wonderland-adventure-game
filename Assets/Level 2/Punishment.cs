using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punishment : MonoBehaviour {

	
    //reduce players health when not answering puzzle correctly
    public void Punish()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerHealth(-10);
    }
}
