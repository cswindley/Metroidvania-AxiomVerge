using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_View : MonoBehaviour
{
    public bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerDetected = true;
            Debug.Log("Player detected");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetected = false;
        Debug.Log("Player detected");
    }
}
