using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyMovement movement;
    private FieldOfView fov;

    private BehaviourState state;

    //
    void OnEnable()
    {
        movement = GetComponent<EnemyMovement>();
        fov = GetComponent<FieldOfView>();
    }

    //
    void Update()
    {
        if (fov.canSeePlayer && Vector3.Distance(transform.position, fov.playerRef.transform.position) < fov.viewRadius / 2)
            state = BehaviourState.ATTACK;
        else if (fov.canSeePlayer)
            state = BehaviourState.CHASE;
        else
            state = BehaviourState.PATROL;

        movement.SetState(state);
    }
}

public enum BehaviourState
{
    PATROL = 0,
    CHASE = 1,
    ATTACK = 2
}