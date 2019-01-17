using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int enemyHealth = 50; // bosses health
    private int damage = -15; // damage boss does to player

    //set the enemies health
    public void SetEnemyHealth(int amount)
    {

        enemyHealth += amount;// add the negative amount to the bosses current health
        //when the player dies
        if (enemyHealth <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerEnergy(50);// give the player 50 energy
            //10% chance for health potion drop
            if (Random.Range(0, 10) == 0)
            {
                GameObject.FindWithTag("Player").GetComponent<Inventory>().SetHealthPotion(5);
            }
            Destroy(gameObject);//destroy the boss
        }
    }

    //find the bosses health
    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    //Attack the player
    public void Attack()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerHealth(damage);
    }

}