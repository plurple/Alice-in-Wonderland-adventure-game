using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int Health = 100;//players health
    private int Energy = 100;//players energy
    private bool HealthFullLabel = false;//check if the players health full
    public bool MeleeAttack = false;//check if player has melee weapon equiped
    public Camera camera;//check if you can see the weapon

    //return the players health
    public int GetPlayerHealth()
    {
        return Health;
    }

    //adjust the players health depending on action
    public void SetPlayerHealth(int amount)
    {
        //when losing health
        if (amount < 0)
            Health += amount;
        //when healing with 50 or more health
        else if (Health < 100 && Health >= 50)
        {
            Health = 100;
            GameObject.FindWithTag("Player").GetComponent<Inventory>().SetHealthPotion(-1);
        }
        //when healing with less than 50 health
        else if (Health < 50)
        {
            Health += amount;
            GameObject.FindWithTag("Player").GetComponent<Inventory>().SetHealthPotion(-1);
        }
        //when trying to heal on full health display message
        else if (Health == 100)
        {
            ToggleHealthFull();
            Invoke("ToggleHealthFull", 1);

        }
            
    }

    //return the players energy
    public int GetPlayerEnergy()
    {
        return Energy;
    }

    //adjust the players energy
    public void SetPlayerEnergy(int amount)
    {
        if (amount < 0)
            Energy += amount;
        else if (Energy + amount > 100)
            Energy = 100;
        else
            Energy += amount;
    }

    //save the players health and energy
    public void SavePlayer()
    {
        GlobalControl.Instance.Health = Health;
        GlobalControl.Instance.Energy = Energy;
    }



        // Use this for initialization
        void Start ()
    {
		Health = GlobalControl.Instance.Health;// set the players health at the start of new scene
        Energy = GlobalControl.Instance.Energy; //set the players energy at the start of new scene
        camera.enabled = false; // make the weapon not visible when non equiped
    }
	
	// Update is called once per frame
	void Update ()
    {
        //use Q to switch between melee and ranged attack
		if(Input.GetKeyDown("q") && gameObject.GetComponent<Inventory>().haveWeapon)
        {
            MeleeAttack = !MeleeAttack;
            camera.enabled = MeleeAttack;//enable weapon camera
        }

        //when player dies load menu scene
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    //when you pick up a weapon make it visible
    public void PickUpWeapon()
    {
        MeleeAttack = !MeleeAttack;
        camera.enabled = MeleeAttack;
    }


    //toggle the health full label
    public void ToggleHealthFull()
    {
        HealthFullLabel = !HealthFullLabel;
    }

    //display health and energy and messages when required
    public void OnGUI()
    {
        GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 + 300), Screen.width, Screen.height), "Health: " + Health);
        GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 + 312), Screen.width, Screen.height), "Energy: " + Energy);
        if (HealthFullLabel)
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 100), Screen.width, Screen.height), "Your Health is Full.");
    }

    
}
