using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3[] waypoints;
    int waypointIndex;
    Vector3 target;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //
    BehaviourState state;

    //
    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateDestination();
    }

    public void SetState(BehaviourState state)
    {
        Debug.Log(state);
        this.state = state;
    }

    private void Update()
    {
        switch (state)
        {
            case BehaviourState.PATROL:
                Patroling();
                break;
            case BehaviourState.CHASE:
                Chasing();
                break;
            case BehaviourState.ATTACK:
                Attacking();
                break;
        }
    }

    private void Patroling()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
        }

        UpdateDestination();
    }

    private void UpdateDestination()
    {
        target = waypoints[waypointIndex];
        agent.SetDestination(target);
    }

    private void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }
    
    private void Chasing()
    {
        Debug.Log("Chasing Player");
        agent.SetDestination(player.position);
    }

    private void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack Code
            Debug.Log("Attacking Player");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
