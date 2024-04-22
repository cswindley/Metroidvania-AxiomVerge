using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_View : MonoBehaviour
{
    //public bool playerDetected = false;
    private Enemy_AI enemyAIRef;

    void Start()
    {
        enemyAIRef = GetComponentInParent<Enemy_AI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemyAIRef.playerDetected = true;
            Debug.Log("Player detected");
        }
    }
     
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {                       
            
            enemyAIRef.CalculateClosestNavPos();
            enemyAIRef.playerDetected = false;
        }
    }
}
