using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sizing : MonoBehaviour
{
     
    public int Size = 0; //size of the player
    private enum States { Idle, Shrink, Grow } //states for if the player is changing size
    private States state = States.Idle;//make the state idle//
    
    private bool potionLabel = false;//label for no potions
    
    private bool cakeLabel = false;//label for no cakes
    private bool Minimum = false;//label for minimum size
    private bool Maximum = false;//label for maximum size

    public void SavePlayer()
    {
        GlobalControl.Instance.Size = Size;//save the players size between scenes
    }

    // Use this for initialization
    void Start()
    {
        Size = GlobalControl.Instance.Size;//set the players size between scenes
    }

    private void Update()
    {
        //heal the player on pressing 1
        if (Input.GetKeyDown("1"))
        {
            if (GameObject.FindWithTag("Player").GetComponent<Inventory>().GetHealthPotion() > 0)
            {
                GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerHealth(50);
                
            }
            else
            {
                //show message if no heal potions
                TogglePotionLabel();
                Invoke("TogglePotionLabel", 1);
            }
        }
        //shrink the player on pressing 2
        if (Input.GetKeyDown("2"))
        {
            if (GameObject.FindWithTag("Player").GetComponent<Inventory>().GetShrinkPotion() > 0)
            {
                Shrink();
                GameObject.FindWithTag("Player").GetComponent<Inventory>().SetShrinkPotion(-1);
            }
            else
            {
                //show message if no shrink potions
                TogglePotionLabel();
                Invoke("TogglePotionLabel", 1);
            }
        }
        //grow the player on pressing 3
        if (Input.GetKeyDown("3"))
        {
            if (GameObject.FindWithTag("Player").GetComponent<Inventory>().GetCake() > 0)
            {
                Grow();
                GameObject.FindWithTag("Player").GetComponent<Inventory>().SetCake(-1);
            }
            else
            {
                //show message if no cake
                ToggleCakeLabel();
                Invoke("ToggleCakeLabel", 1);
            }
        }
        //if not max or minimum size grow or shrink the player as necessary
        if (Size > -3 || Size < 3)
        {
            switch (state)
            {
                case States.Idle:
                    break;
                case States.Shrink:
                    transform.localScale /= 2;
                    Size--;
                    state = States.Idle;
                    break;
                case States.Grow:
                    transform.localScale *= 2;
                    Size++;
                    state = States.Idle;
                    break;
                default:
                    break;
            }
        }
    }

    //grow the player
    public void Grow()
    {
        state = States.Grow;
        if (Size < 3)
        {
                        
        }
        else
        {
            //show message if max size
            ToggleMaximumLabel();
            Invoke("ToggleMaximumLabel", 1);
            state = States.Idle;
            
        }

       
    }

    public void Shrink()
    {
        state = States.Shrink;
        if (Size > -3)
        {
                       
        }
        else
        {
            //show message if minimum size
            ToggleMinimumLabel();
            Invoke("ToggleMinimumLabel", 1);
            state = States.Idle;
            
        }

        
    }

    
    //show messages
    public void OnGUI()
    {
        if (Maximum)
        {
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 100), Screen.width, Screen.height), "You are maximum size!!");
        }
        if (Minimum)
        {
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 100), Screen.width, Screen.height), "You are Minimum size!!");
        }
        if (potionLabel)
        {
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 100), Screen.width, Screen.height), "You have no potions.");
        }
        if (cakeLabel)
        {

            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 100), Screen.width, Screen.height), "You have no cake.");
        }
        
    }
    //toggle potion message
    public void TogglePotionLabel()
    {
        potionLabel = !potionLabel;
    }

    //toggle cake message
    public void ToggleCakeLabel()
    {
        cakeLabel= !cakeLabel;
    }
    //toggle minimum message
    public void ToggleMinimumLabel()
    {
        Minimum = !Minimum;
    }
    //toggle maximum message
    public void ToggleMaximumLabel()
    {
        Maximum = !Maximum;
    }

}