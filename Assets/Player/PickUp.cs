using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int lengthOfRay = 5; //length ray is active
    public Camera camera; //camera the ray is being shot from
    string hitPoint; //name of the item being hit by ray
    private List<string> inventory = new List<string>(); //list of gameobject names that you can interact with


    //add all of the gameobject tags to the list
    private void Start()
    {
        inventory.Add("ShrinkPotion");
        inventory.Add("HealthPotion");
        inventory.Add("Cake");
        inventory.Add("TriangleKey");
        inventory.Add("SquareKey");
        inventory.Add("CircleKey");
        inventory.Add("Door");
        inventory.Add("CorrectDoor");
        inventory.Add("Weapon");
    }

    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit; // find the ray direction
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition); //find the ray origin
        //calculate the ray
        if (Physics.Raycast(ray, out hit, lengthOfRay))
        {
            hitPoint = hit.transform.tag;//set the hitpoints name to the hit items tag name
            
            //check F is pressed
            if (Input.GetKeyDown("f"))
            {
                //make sure the ray is hitting something
                if (hit.collider != null)
                {
                    //check if a shrinkpotion
                    if (hitPoint == "ShrinkPotion")
                    {
                        
                        Destroy(hit.transform.gameObject); //destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().SetShrinkPotion(3);//add shrinkpotions to the inventory
                    }
                    //check if a healthpotion
                    if (hitPoint == "HealthPotion")
                    {
                        
                        Destroy(hit.transform.gameObject);//destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().SetHealthPotion(5);//add health potions to the inventory
                    }
                    //check if a cake
                    else if (hitPoint == "Cake")
                    {
                        
                        Destroy(hit.transform.gameObject);//destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().SetCake(3);//add cakes to the inventorry


                    }
                    //check if triangle key
                    else if (hitPoint == "TriangleKey")
                    {
                       
                        Destroy(hit.transform.gameObject);//destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().AddKey(1);//add trianglekey to the inventory


                    }
                    //check if circle key
                    else if (hitPoint == "CircleKey")
                    {
                        
                        Destroy(hit.transform.gameObject);//destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().AddKey(2);//add circlekey to the inventory


                    }
                    //check if square key
                    else if (hitPoint == "SquareKey")
                    {
                        
                        Destroy(hit.transform.gameObject);//destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().AddKey(3);//add squarekey to the inventory

                    }
                    //check if a door
                    else if (hitPoint == "Door" && GameObject.FindWithTag("Player").GetComponent<Inventory>().haveAKey)
                    {
                        
                        GameObject.FindWithTag("Door").GetComponent<Punishment>().Punish();//punish the player for choosing the wrong door


                    }
                    //check if correctdoor
                    else if (hitPoint == "CorrectDoor" && GameObject.FindWithTag("Player").GetComponent<Inventory>().haveAKey)
                    {
                        
                        GameObject.FindWithTag("CorrectDoor").GetComponent<CorrectDoor>().AnswerPuzzle();//check if player answered riddle correctly

                    }
                    //check if weapon
                    else if (hitPoint == "Weapon")
                    {
                        
                        Destroy(hit.transform.gameObject);//destroy the item you are hitting
                        GameObject.FindWithTag("Player").GetComponent<Inventory>().AddWeapon();//add a weapon to the inventory
                    }



                }
               
               
            }
            

        }
        else
        {
            hitPoint = null;// set the hitpoint to nothing to remove the interaction message
        }


    }

    
    public void OnGUI()
    {
        //check if ray is pointing to any interactable items
        foreach (string item in inventory)
        {
            if (hitPoint == item)
            {
                 GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 96), Screen.width, Screen.height), "Press F to Interact.");//display a message if you can interact with the itme pointed to
            }
        }
    }

}