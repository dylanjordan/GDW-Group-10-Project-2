using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    [HideInInspector]
    public GameObject playerRef;

    private bool isDead;

    private void OnEnable()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    //Controls Frequency of FOV Checks
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (!isDead)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    //Checks given angle in fov radius for non-obscured targets
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        if (rangeChecks.Length != 0) //If a target is present, proceed
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2) //If target is within view angle, proceed
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                //If no object is obstructing the view of target, proceed
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer) //If target is no longer present, reset bool value
        {
            canSeePlayer = false;
        }
    }
}
