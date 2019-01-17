using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is used to save the players information between scenes
public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    public int Health; //players health
    public int Energy;//players energy
    public  int ShrinkPotion;// amount of shrink potions
    public int Cake;//amount of cake
    public int HealthPotion;//amount of health potions
    public int Size;//players size

    void Awake()
    {
        //when awoken check if any instances in the scene
        //if none in the scene don't destroy this instance
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        //otherwise destroy this object
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void SavePlayer()
    {
        GlobalControl.Instance.Health = Health; //saves the health of the player
        GlobalControl.Instance.Energy = Energy;// saves the energy
        GlobalControl.Instance.ShrinkPotion = ShrinkPotion;//saves the amount of shrink potions
        GlobalControl.Instance.Cake = Cake;//saves the amount of cake
        GlobalControl.Instance.HealthPotion = HealthPotion;//saves the number of health potions
        GlobalControl.Instance.Size = Size;//saves the size
    }


}
