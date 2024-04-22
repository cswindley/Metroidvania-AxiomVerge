using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool inStunRange = false;
    private Enemy_AI enemyRef;

    [SerializeField] GameObject pressEPrompt;

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
            pressEPrompt.SetActive(true);
            enemyRef = col.gameObject.GetComponentInParent<Enemy_AI>();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("EnemyStun"))
        {
            inStunRange = false;
            pressEPrompt.SetActive(false);
            enemyRef = null;
        }
    }
}
