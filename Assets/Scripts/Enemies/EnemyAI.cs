using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform currentTarget;
    public string playerTag; 
    public float stopDistance = 2.0f;
    public float aggroRange = 5.0f; //will need to tune and set collision/explosion/dmg
    private EnemyMovement enemyController;
    

    void Start()
    {
        enemyController = GetComponent<EnemyMovement>();
        FindAndSetTarget();
    }

    void Update()
    {
        
            Vector3 directionToTarget = currentTarget.position - transform.position;
            Vector3 stoppingPosition = currentTarget.position - directionToTarget.normalized * stopDistance;
            
            enemyController.target = stoppingPosition;
            //set destination to stoppingPosition
            Rigidbody unitRB = gameObject.GetComponent<Rigidbody>();
            unitRB.velocity = stoppingPosition * 1f;
            if(unitRB.transform.position == stoppingPosition)
            {
                unitRB.velocity = new Vector3(0, 0);
            }
        
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
