using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [Tooltip("This will be the view of the enemy, if player enters enemy will track and follow")][SerializeField] GameObject lightBeam;
    //private Enemy_View enemyView;

    public enum AIState { patrol, chase, attack };

    public bool playerDetected = false;

    public AIState currentState;
    private NavMeshAgent agent;
    private GameObject player;
    private float distanceToPlayer;
    private Material mat;
    [SerializeField] ParticleSystem ps;

    [Range(3, 15)][SerializeField] int maxDis;
    [SerializeField] Transform[] navPoints;
    private int currentPointIndex;

    public bool isStunned = false;

    // Start is called before the first frame update
    void Start()
    {
        currentState = AIState.patrol;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentPointIndex = 0;
        //enemyView = lightBeam.GetComponent<Enemy_View>();
        mat = lightBeam.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStunned)
        {
            DetermineStates();
        }       
    }

    private void DetermineStates()
    {
        /*distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= 3.0f)
        {
            currentState = AIState.attack;
        }
        else if (enemyView.playerDetected == true && distanceToPlayer <= maxDis)*/
        //if (enemyView.playerDetected)
        if(playerDetected)
        {
            currentState = AIState.chase;
            mat.color = Color.red;
        }
        else
        {
            currentState = AIState.patrol;
            mat.color = Color.yellow;
        }
        HandleStates();
    }

    public void HandleStates()
    {
        switch (currentState)
        {
            case AIState.patrol:
                if (!agent.pathPending && agent.remainingDistance <= 0.5f)
                {
                    agent.SetDestination(navPoints[currentPointIndex].position);
                    currentPointIndex++;

                    if (currentPointIndex >= navPoints.Length)
                    {
                        currentPointIndex = 0;
                    }
                }
                break;
            //Sets des to player
            case AIState.chase:
                agent.SetDestination(player.transform.position);
                break;
            case AIState.attack:
                break;
            default:
                Debug.LogError("Unknown State");
                break;
        }
    }

    public IEnumerator Stun()
    {
        mat.color = Color.green;
        Debug.Log("stunned");
        ps.Play();

        isStunned = true;
        agent.isStopped = true;

        yield return new WaitForSeconds(3.0f);

        agent.isStopped = false;
        isStunned = false;

        mat.color = Color.yellow;
        
        CalculateClosestNavPos();
    }

    public void CalculateClosestNavPos()
    {
        float[] distance = new float[navPoints.Length];
        int closestNavPointIndex = 0;

        for (int i = 0; i < navPoints.Length; i++)
        {
            distance[i] = Vector3.Distance(transform.position, navPoints[i].position);
            if (distance[i] < distance[closestNavPointIndex])
            {
                closestNavPointIndex = i;
            }
        }
        Debug.Log(closestNavPointIndex);
        currentPointIndex = closestNavPointIndex;
    }
}
