using UnityEngine;
using System.Collections;

//https://www.youtube.com/watch?v=OYwQFpJIFGg&index=7&list=WL

public class ClickToMove : MonoBehaviour {

    public float attackDistance = 10f;
    public float attackSpeed = .5f;
    public int damagePerAttack = 20;


    //private Animator anim;

    private NavMeshAgent navMeshAgent;
    private Transform targetedEnemy;


    //private bool walking; - Animation
    private bool enemyClicked;
    private float nextAttack;



	// Use this for initialization
	void Awake ()
    {
        // anim = GetComponent<Animator>();
        navMeshAgent = GetComponent <NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButton("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }
                else
                {
                    //walking = true;
                    enemyClicked = false;
                    navMeshAgent.destination = hit.point;
                    navMeshAgent.Resume();
                }
            }
        }

        if (enemyClicked)
        {
            MoveAndAttack();
        }
       

	}

    //moves toward target & chase
    private void MoveAndAttack()
    {
        if (targetedEnemy == null)
            return;
        navMeshAgent.destination = targetedEnemy.position;
        if (navMeshAgent.remainingDistance >= attackDistance)
        {
            navMeshAgent.Resume();
            //walking = true;
        }
        //rotates player to enemy
        if (navMeshAgent.remainingDistance <= attackDistance)
        {
            transform.LookAt(targetedEnemy);
            //Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackSpeed;
                EnemyHealth enemyHealth = (EnemyHealth)targetedEnemy.GetComponent("EnemyHealth");
                enemyHealth.TakeDamage(damagePerAttack);                                                                                                             
            }
            navMeshAgent.Stop();
            //walking = false;
        }
    }
}
