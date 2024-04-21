using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool inStunRange = false;
    private Enemy_AI enemyRef;

    void Update()
    {
        if (inStunRange && Input.GetKeyDown(KeyCode.E) && !enemyRef.isStunned)
        {
            StartCoroutine(enemyRef.Stun());           
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("EnemyStun"))
        {
            inStunRange = true;
            enemyRef = col.gameObject.GetComponentInParent<Enemy_AI>();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("EnemyStun"))
        {
            inStunRange = false;
            enemyRef = null;
        }
    }
}
