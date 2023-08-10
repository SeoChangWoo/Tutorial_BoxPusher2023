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

    public float attackRange = 2f; // 공격 가능한 거리
    public bool isAttacking = false;
    public Animator monsterAnim;

    private void Update()
    {
        Patrol();
        if(CanSeePlayer())
        {
            if (!isAttacking)
            {
                ChasePlayer();
            }
            if (Vector3.Distance(transform.position, player.position) < attackRange)
            {
                Debug.Log("공격 시작");
                AttackPlayer();
            }
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(directionToPlayer, transform.forward); // 두 인자 벡터 간의 각도를 계산하는 Angle 함수
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

    void AttackPlayer()
    {
        isAttacking = true;
        monsterAnim.SetTrigger("Attack");
        CheckPlayerCollision(player);
        // 일정 시간 후에 다시 공격 가능 상태로 변경
        Invoke("ResetAttackState", 2f);
    }
    void ResetAttackState()
    {
        isAttacking = false;
    }

    void CheckPlayerCollision(Transform playerTransform)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, LayerMask.GetMask("Player"));
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == playerTransform.gameObject)
            {
                Debug.Log("Player bumped into the monster!");
                // 여기에 부딪친 플레이어에게 추가적인 처리를 하면 됩니다.
            }
        }
    }
}
