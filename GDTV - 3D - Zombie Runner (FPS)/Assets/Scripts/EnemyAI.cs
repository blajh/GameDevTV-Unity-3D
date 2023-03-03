using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private Animator animator;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private bool isAttacking = false;
    private bool isAlive = true;    
    
    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (isAlive) {
            distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (isProvoked) {
                EngageTarget();
            } else if (distanceToTarget <= chaseRange) {
                isProvoked = true;
            }        
        }
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    private void EngageTarget() {

        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance && !isAttacking) {
            ChaseTarget();
        }

        else if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
            isAttacking = true;
        }
    }

    public void AttackFinished() {
        isAttacking = false;
    }

    private void AttackTarget() {        
        animator.SetBool("attack", true);
    }

    public bool IsPlayerInRange() {
        return distanceToTarget <= navMeshAgent.stoppingDistance + 0.5f;
    }

    private void ChaseTarget() {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void Die() {
        isAlive = false;
        animator.SetBool("attack", false);
    }
}