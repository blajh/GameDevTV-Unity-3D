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
    
    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }        
    }

    public void OnDamageTaken() {
        isProvoked = true;
    }

    private void EngageTarget() {

        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }

        else if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void AttackTarget() {        
        animator.SetBool("attack", true);
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
}