using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 target;

    private void FixedUpdate()
    {
        Rigidbody unitRB = gameObject.GetComponent<Rigidbody>();
        unitRB.velocity = target * moveSpeed;
    }
}
