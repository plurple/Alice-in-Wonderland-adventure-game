using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject target; //get the enemy target
    public bool haveTarget = false; //check if you have a target fals eby default
    
    //when enemy, boss or card stays within the trigger	set target
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss" || other.gameObject.tag == "Card")
        haveTarget = true;
        target = other.gameObject;

    }

    //when the card, boss or enemy leaves the trigger remove target
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            haveTarget = false;
            target = null;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        //when the target dies within the trigger and nothing else is within the trigger
		if(haveTarget && target == null)
        {
            
            haveTarget = !haveTarget;
        }
	}
}
