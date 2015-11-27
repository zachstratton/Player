using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public float chasingRange;      // Range Enemy will start to chase player.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            FollowPlayer();
        }
    }

    bool IsInRange(float range)
    {
            if (Vector3.Distance(player.transform.position, transform.position) < range)
            {
                return true;
            }
            else
            {
                return false;
            }
     }


    void FollowPlayer()
    {
            if (IsInRange(chasingRange))
            {
                nav.SetDestination(player.transform.position);
            }
            else
            {
                nav.SetDestination(transform.position);
            }

        }
}


