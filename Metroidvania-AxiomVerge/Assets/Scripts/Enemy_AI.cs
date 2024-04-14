using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [Tooltip("This will be the view of the enemy, if player enters enemy will track and follow")][SerializeField] GameObject lightBeam;
    private Enemy_View enemyView;

    enum AIState { patrol, chase, attack };

    private AIState currentState;
    private NavMeshAgent agent;
    private GameObject player;
    private float distanceToPlayer;

    [Range(3, 15)][SerializeField] int maxDis;
    [SerializeField] Transform[] navPoints;
    private int currentPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentState = AIState.patrol;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentPointIndex = 0;
        enemyView = lightBeam.GetComponent<Enemy_View>();
    }

    // Update is called once per frame
    void Update()
    {
        DetermineStates();
        HandleStates();
    }

    private void DetermineStates()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= 3.0f)
        {
            currentState = AIState.attack;
        }
        else if (enemyView.playerDetected == true && distanceToPlayer <= maxDis)
        {
            currentState = AIState.chase;
        }
        else
        {
            currentState = AIState.patrol;
        }
        HandleStates();
    }

    private void HandleStates()
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
}
