using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject attackBox; //find the trigger box to see if the melee weapon has a target
    public Animator anim; // find the animation on the sword
    private float attackTime; //check to see if the player can attack
    private float attackDelay = 0.3f; //time between attacks



    //Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); // find the sword animation
        attackTime = Time.time; // set the time so the player can attack
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is pressing the attack button
        if (Input.GetMouseButtonDown(0) && GameObject.FindWithTag("Player").GetComponent<Player>().MeleeAttack)
        {

            //play the attack animation that will then call the attack function
            anim.SetTrigger("Attack");
           
        }

    }

    //attack function called from the animation
    public void attack()
    {
        //checks if the player has a target and the melee weapon is attached
        if (attackBox.GetComponent<MeleeAttack>().haveTarget && Time.time > attackTime)
        {
            //set the target of the attack box to enemy
            GameObject enemy = GameObject.FindWithTag("Trigger").GetComponent<MeleeAttack>().target;
            //if enemy is a rabbit enemy
            if (enemy.gameObject.tag == "Enemy")
            {
                //chance of critical hit
                if (Random.Range(0, 10) == 0)
                {
                    enemy.transform.GetComponent<Enemy>().SetEnemyHealth(-20);// do damage to the enemy
                }
                else
                    enemy.transform.GetComponent<Enemy>().SetEnemyHealth(-10);//do damage to the enemy
                attackTime = Time.time + attackDelay; //make it .3 seconds between attacks
            }
            //if enemy is a boss
            else if (enemy.gameObject.tag == "Boss")
            {
                //chance of critical hit
                if (Random.Range(0, 10) == 0)
                {
                    enemy.transform.GetComponent<Boss>().SetEnemyHealth(-20); //do damage to the boos
                }
                else
                    enemy.transform.GetComponent<Boss>().SetEnemyHealth(-10);//do damage to the boss
                attackTime = Time.time + attackDelay; //make it .3 seconds beween attacks
            }
            //if enemy is a card
            else if (enemy.gameObject.tag == "Card")
            {
                //chance of a critical hit
                if (Random.Range(0, 10) == 0)
                {
                    enemy.transform.GetComponent<CardEnemy>().SetEnemyHealth(-30);// do damge to the card enemy
                }
                else
                    enemy.transform.GetComponent<CardEnemy>().SetEnemyHealth(-10); //do damge to the card enemy
                attackTime = Time.time + attackDelay; //make it .3 seconds between attacks
            }
        }
    }
}
