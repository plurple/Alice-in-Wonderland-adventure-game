using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private int ShrinkPotion;//number of shrink potions
    private int Cake;//amount of cake
    private int HealthPotion;//number of health potions
    public bool haveTriangleKey = false;//check if have the triangle key
    private bool haveCircleKey = false;//check if have circle key
    private bool haveSquareKey = false;//check if have the square key
    public bool haveAKey = false;// check if the player has any key
    public bool haveWeapon = false;// check if the player has the sword
    
    

    //returns number of health potions
    public int GetHealthPotion()
    {
        return HealthPotion;
    }

    //adjusts the number of health potions
    public void SetHealthPotion(int amount)
    {
        HealthPotion += amount;
    }

    //returns the number of shrink potions
    public int GetShrinkPotion()
    {
        return ShrinkPotion;
    }

    //adjusts the amount of shrink potions
    public void SetShrinkPotion(int amount)
    {
        ShrinkPotion += amount;
    }

    //returns the amount of cake
    public int GetCake()
    {
        return Cake;
    }

    //adjusts the amount of cake
    public void SetCake(int amount)
    {
        Cake += amount;
    }


    //adds the sword to the inventory
    public void AddWeapon()
    {
        if (!haveWeapon)
        {
            haveWeapon = !haveWeapon;
            gameObject.GetComponent<Player>().PickUpWeapon();//sets the have weapon bool true for the player so they can now attack
        }
    }

    //adds a key to the inventory
    public void AddKey(int key)
    {
        //when you first pick up a key sets have a key to true
        if (!haveAKey)
        haveAKey = !haveAKey;
        //if you pick the first key
        if (key == 1)
        {
            
            if (haveCircleKey)
            {
                haveCircleKey = !haveCircleKey;
                haveTriangleKey = !haveTriangleKey;
                GameObject.FindWithTag("Trigger").GetComponent<TriggerKey>().CreateCircleKey();
            }
            //checked if you have the square key to switch keys on the table
            else if (haveSquareKey)
            {
                haveSquareKey = !haveSquareKey;
                haveTriangleKey = !haveTriangleKey;
                GameObject.FindWithTag("Trigger").GetComponent<TriggerKey>().CreateSquareKey();
            }
            else
            {
                haveTriangleKey = !haveTriangleKey;
            }
        }
        //if you pick the 2nd key
        if (key == 2)
        {
            //checked if you have the triangle key to switch keys on the table
            if (haveTriangleKey)
            {
                haveTriangleKey = !haveTriangleKey;
                haveCircleKey = !haveCircleKey;
                GameObject.FindWithTag("Trigger").GetComponent<TriggerKey>().CreateTriangleKey();
            }
            //checked if you have the square key to switch keys on the table
            else if (haveSquareKey)
            {
                haveSquareKey = !haveSquareKey;
                haveCircleKey = !haveCircleKey;
                GameObject.FindWithTag("Trigger").GetComponent<TriggerKey>().CreateSquareKey();
            }
            else
            {
                haveCircleKey = !haveCircleKey;
            }
        }
        //pick the third key
        if (key == 3)
        {
            //checked if you have the triangle key to switch keys on the table
            if (haveTriangleKey)
            {
                haveTriangleKey = !haveTriangleKey;
                haveSquareKey = !haveSquareKey;
                GameObject.FindWithTag("Trigger").GetComponent<TriggerKey>().CreateTriangleKey();
            }
            //checked if you have the circle key to switch keys on the table
            else if (haveCircleKey)
            {
                
                haveCircleKey = !haveCircleKey;
                haveSquareKey = !haveSquareKey;
                GameObject.FindWithTag("Trigger").GetComponent<TriggerKey>().CreateCircleKey();
            }
            else
            {
                haveSquareKey = !haveSquareKey;
            }
        }

    }

    //save the inventory
    public void SavePlayer()
    {
        
        GlobalControl.Instance.HealthPotion = HealthPotion;
        GlobalControl.Instance.Cake = Cake;
        GlobalControl.Instance.ShrinkPotion = ShrinkPotion;

    }

    // Use this for initialization
    void Start ()
    {
        ShrinkPotion = GlobalControl.Instance.ShrinkPotion; //set the amount of shrink potions in a new scene
        Cake = GlobalControl.Instance.Cake; //set the amount of cakes in a new scene
        HealthPotion = GlobalControl.Instance.HealthPotion; //set the amount of health potion in a new scene
        

    }
	

    //writes out the inventory to the right side of the screen
    public void OnGUI()
    {

        GUI.Label(new Rect((Screen.width -110), (Screen.height / 2), Screen.width, Screen.height), "Inventory:");
        GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 12), Screen.width, Screen.height), "HealthPotions: " + HealthPotion);
        GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 24), Screen.width, Screen.height), "ShrinkPotions: " + ShrinkPotion);
        GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 36), Screen.width, Screen.height), "Cake:          " + Cake);
        if (haveWeapon)
            GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 48), Screen.width, Screen.height), "Magic Sword");
        if (haveTriangleKey)
            GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 60), Screen.width, Screen.height), "Triangle Key ");
        if (haveCircleKey)
            GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 60), Screen.width, Screen.height), "Circle Key ");
        if (haveSquareKey)
            GUI.Label(new Rect((Screen.width - 110), (Screen.height / 2 + 60), Screen.width, Screen.height), "Square Key ");
    }
}
