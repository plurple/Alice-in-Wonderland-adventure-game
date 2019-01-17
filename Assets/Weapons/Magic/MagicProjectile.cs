using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public Camera camera; //camera to raycast from
    string hitPoint; //a string to check if can see an enemy
    public ParticleSystem Magic; //particle system to represent the magic
    private bool EnergyEmptyLabel; //bool to check if you are out of energy
    private float attackTime; //makes sure you can attack
    private float attackDelay = 0.7f;//time delay between attacks


    // Use this for initialization
    void Start()
    {
        attackTime = Time.time; //set the initial attack
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; //finds the direction the ray is firing in.

        Ray ray = camera.ScreenPointToRay(Input.mousePosition); //sets the origin of the ray
        //checks if anything is in the ray for a distance of 25
        if (Physics.Raycast(ray, out hit, 25))
        {
            
            hitPoint = hit.transform.tag; //sets the tag of the object hit to hitpoint
            
            //finds if the attack button is down and the magic attack is active
            if (Input.GetMouseButtonDown(0) && !GameObject.FindWithTag("Player").GetComponent<Player>().MeleeAttack)
            {
                //makes sure the ray is hitting something
                if (hit.collider != null)
                {
                    
                    //makes sure the thing hit is an enemy
                    if (hitPoint == "Enemy")
                    {
                        
                        GameObject player = GameObject.FindWithTag("Player");//finds the player
                        //makes sure the player has enough energy to use magic and that it has been .7 seconds since a magic attack
                        if (player.GetComponent<Player>().GetPlayerEnergy() >= 20 && Time.time > attackTime)
                        {
                            player.GetComponent<Player>().SetPlayerEnergy(-20);//reduces the players energy
                            Magic.enableEmission = true;//allows the particles to be played
                            Magic.Play();//plays the particle system
                            //10% chance to critical hit
                            if (Random.Range(0, 10) == 0)
                            {
                                hit.transform.GetComponent<Enemy>().SetEnemyHealth(-20);//damage the enemy
                            }
                            else
                                hit.transform.GetComponent<Enemy>().SetEnemyHealth(-10);//damage the enemy
                            attackTime = Time.time + attackDelay;//create attackdelay
                        }
                        //if no energy tell the player this
                        else if (player.GetComponent<Player>().GetPlayerEnergy() < 20)
                        {
                            ToggleEnergyEmpty();
                            Invoke("ToggleEnergyEmpty", 1);
                        }
                         else
                                Magic.enableEmission = false; //disallows the magic stream
                    }
                    //makes sure the thing hit is an enemy boss
                    else if (hitPoint == "Boss")
                    {
                        
                        GameObject player = GameObject.FindWithTag("Player");//finds the player
                        //makes sure the player has enough energy to use magic and that it has been .7 seconds since a magic attack
                        if (player.GetComponent<Player>().GetPlayerEnergy() >= 20 && Time.time > attackTime)
                        {
                            player.GetComponent<Player>().SetPlayerEnergy(-20);//reduces the players energy
                            Magic.enableEmission = true;//allows the particles to be played
                            Magic.Play();//plays the particle system
                            //10% chance to critical hit
                            if (Random.Range(0, 10) == 0)
                            {
                                hit.transform.GetComponent<Boss>().SetEnemyHealth(-30);//damage the enemy
                            }
                            else
                                hit.transform.GetComponent<Boss>().SetEnemyHealth(-10);//damage the enemy
                            attackTime = Time.time + attackDelay;//create attackdelay
                        }
                        //if no energy tell the player this
                        else if (player.GetComponent<Player>().GetPlayerEnergy() < 20)
                        {
                            ToggleEnergyEmpty();
                            Invoke("ToggleEnergyEmpty", 1);
                        }
                         else
                                Magic.enableEmission = false;//disallows the magic stream
                    }
                    //makes sure the thing hit is an enemy card
                    else if (hitPoint == "Card")
                    {

                        GameObject player = GameObject.FindWithTag("Player");//finds the player
                        //makes sure the player has enough energy to use magic and that it has been .7 seconds since a magic attack
                        if (player.GetComponent<Player>().GetPlayerEnergy() >= 20 && Time.time > attackTime)
                        {
                            player.GetComponent<Player>().SetPlayerEnergy(-20);//reduces the players energy
                            Magic.enableEmission = true;//allows the particles to be played
                            Magic.Play();//plays the particle system
                            //10% chance to critical hit
                            if (Random.Range(0, 10) == 0)
                            {
                                hit.transform.GetComponent<CardEnemy>().SetEnemyHealth(-30);//damage the enemy
                            }
                            else
                                hit.transform.GetComponent<CardEnemy>().SetEnemyHealth(-10);//damage the enemy
                            attackTime = Time.time + attackDelay;//create attackdelay
                        }
                        //if no energy tell the player this
                        else if (player.GetComponent<Player>().GetPlayerEnergy() < 20)
                        {
                            ToggleEnergyEmpty();
                            Invoke("ToggleEnergyEmpty", 1);
                        }
                        else
                            Magic.enableEmission = false;
                    }


                }
            }
        }
    }

    //turn the no energy warnign on and off
    public void ToggleEnergyEmpty()
    {
        EnergyEmptyLabel = !EnergyEmptyLabel;
    }

    //show the no energy warning
    public void OnGUI()
    {
        if (EnergyEmptyLabel)
            GUI.Label(new Rect((Screen.width / 2 - 60), (Screen.height / 2 - 100), Screen.width, Screen.height), "You have no Energy!");
    }
}
