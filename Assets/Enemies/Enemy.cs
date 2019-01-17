using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyHealth = 20;//enemys health amount
    private int damage = -5;// amount of damage the enemy does

    //change the enemies health when attacked
    public void SetEnemyHealth(int amount)
    {
        
        enemyHealth += amount;//reduce the enemies health by the negative attack
        //when the enemy dies
        if (enemyHealth <= 0)
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerEnergy(20);//give the player some energy
            //chance that the enemy drops health potions
            if (Random.Range(0, 10) == 0)
            {
                GameObject.FindWithTag("Player").GetComponent<Inventory>().SetHealthPotion(5);//increase the amount of health potions for the player
            }
            Destroy(gameObject);//destroy the enemy      
        }
    }

    //find the enemies health
    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    //do damge to the player
    public void Attack()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().SetPlayerHealth(damage);
    }

}
