using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEnemy : MonoBehaviour
{
    private int enemyHealth = 30; //card enemies starting health
    private int damage = -10; // amount of damage the card ewnemy does

    //reduces the card enemies health when attacked
    public void SetEnemyHealth(int amount)
    {

        enemyHealth += amount;//reduces the enemies health by the players attack
        //when the card enemy dies
        if (enemyHealth <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerEnergy(30);// give the player some energy
            //10% chance of the enemy droping some health potions
            if (Random.Range(0, 10) == 0)
            {
                GameObject.FindWithTag("Player").GetComponent<Inventory>().SetHealthPotion(5);// change the number of health potion the player has
            }
            Destroy(gameObject); //destroy the card enemy
        }
    }

    //find out the enemies health
    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    //make the enemy attack the player
    public void Attack()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerHealth(damage);// do damage to the player
    }

   
}