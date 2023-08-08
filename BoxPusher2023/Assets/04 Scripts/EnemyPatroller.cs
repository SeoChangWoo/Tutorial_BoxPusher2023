using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatroller : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private float detectionRange = 10f;
    private float fieldOfViewAngle = 90f;

    private void Update()
    {
        Patrol();
        if(CanSeePlayer())
        {
            ChasePlayer();
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(directionToPlayer, transform.forward); // �� ���� ���� ���� ������ ����ϴ� Angle �Լ�
        if(angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange ))
            {
                Debug.DrawRay(transform.position, directionToPlayer, Color.red);
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Patrol()
    {
        if (waypoints.Length == 0)
            return;
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
