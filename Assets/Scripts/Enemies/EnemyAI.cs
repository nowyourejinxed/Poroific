using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform currentTarget;
    public string playerTag; 
    public float stopDistance = 2.0f;
    public float aggroRange = 5.0f; //will need to tune and set collision/explosion/dmg
    private NavMeshAgent enemyController;
    

    void Start()
    {
        enemyController = GetComponent<NavMeshAgent>();
        FindAndSetTarget();
    }

    void Update()
    {
        
            Vector3 directionToTarget = currentTarget.position - transform.position;
            Vector3 stoppingPosition = currentTarget.position - directionToTarget.normalized * stopDistance;
            
            enemyController.SetDestination(stoppingPosition);
        
    }
    private void FindAndSetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        Transform closestEnemy = player.transform;
        if(closestEnemy != null)
        {
            currentTarget = closestEnemy;
        }
    }
}
