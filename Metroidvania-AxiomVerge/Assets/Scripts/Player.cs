using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool inStunRange = false;
    private Enemy_AI enemyRef;

    [SerializeField] GameObject pressEPrompt;

    [SerializeField] GameObject blueLightBlank;
    [SerializeField] GameObject blueLight;
    [SerializeField] GameObject redLightBlank;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject redGate;

    [SerializeField] private GameObject gate;

    [SerializeField] private AudioClip stunSound;
    [SerializeField] private AudioClip keycardSound;

    void Update()
    {
        if (inStunRange && Input.GetKeyDown(KeyCode.E) && !enemyRef.isStunned)
        {
            pressEPrompt.SetActive(false);
            AudioManager.Instance.Play(stunSound);
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

        if (col.CompareTag("WinTransition"))
        {
            SceneManager.LoadScene("WinScene");
        }

        if (col.CompareTag("BlueKeycard"))
        {
            blueLight.SetActive(true);
            blueLightBlank.SetActive(false);
            Destroy(col.gameObject);
            Destroy(gate);
            AudioManager.Instance.Play(keycardSound);
            
        }

        if (col.CompareTag("RedKeycard"))
        {
            redGate.SetActive(false);
            redLight.SetActive(true);
            redLightBlank.SetActive(false);
            Destroy(col.gameObject);
            
            AudioManager.Instance.Play(keycardSound);
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
