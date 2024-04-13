using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int killCount = 0;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("I RAN SOMEONE OVER");
            Destroy(collider.gameObject);
            killCount++;
        }
    }
}
