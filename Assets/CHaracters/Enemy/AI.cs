using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    
    public Transform Player; // find the player.
    public Vector3[] patrolPoints; // store any patrol points for the enemies.
    private int patrolPoint = 0; //number of patrol points.
    private NavMeshAgent agent; // find the navmesh agent to be able to set the new destination.
    private float attackTime; // check to see if enemy can attack
    private float attackDelay = 1.5f; //time betwwen enemy attacks
    public bool randomPatrol = false; // check if the enemy is randomly roaming

    void Patrol()
    {
        agent.isStopped = false; // makes sure the enemy is moving
        
        if (patrolPoints.Length > 0) //checks if enemy is patroling.
        {
        
            
            agent.SetDestination(patrolPoints[patrolPoint]); //sets next destination point

            //moves the enemy onto the next patrolpoint
            if (transform.position == patrolPoints[patrolPoint] || Vector3.Distance(transform.position, patrolPoints[patrolPoint]) < 5f)
            {
                patrolPoint++;

                //finds a random point for the roamers
                if (randomPatrol)
                    patrolPoint = Random.Range(0, patrolPoints.Length);
            }

            //checks if out of the patrol array of points
            if (patrolPoint >= patrolPoints.Length)
            {
                patrolPoint = 0;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        attackTime = Time.time; // sets the time when the enemy is created

        //sets the original random point for the roamers
        if (randomPatrol)
        {

            patrolPoint = Random.Range(0, patrolPoints.Length);

        }

    }

    // Update is called once per frame
    void Update()
    {
        //when the enemy is closer than 20 follow the player
        if (Vector3.Distance(transform.position, Player.position) < 20)
        {

            agent.destination = Player.position;// set the enemys destination to the players position
            //when the player is within 5 and it has been 1.5 seconds since last attack.
            if (Vector3.Distance(transform.position, Player.position) <= 5 && Time.time > attackTime)
            {
                //if rabbit enemy call the rabbit's attack
                if (gameObject.tag == "Enemy")
                {
                    gameObject.GetComponent<Enemy>().Attack();

                }
                //if boss enemy call the boss's attack
                else if (gameObject.tag == "Boss")
                    gameObject.GetComponent<Boss>().Attack();
                //if card enemy call the cardenemy's attack
                else if (gameObject.tag == "Card")
                    gameObject.GetComponent<CardEnemy>().Attack();

                //make the check for attack 1.5 seconds in the future
                attackTime = Time.time + attackDelay;
            }
        }
        else
        {
            //call the patrol function when not in range of the player
            Patrol();
        }
    }

}
