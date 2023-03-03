using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimatorRedirector : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private EnemyAttack enemyAttack;

    public void EnemyAttack() {
        enemyAttack.AttackHitEvent();
    }

    public void AttackFinished() {
        enemyAI.AttackFinished();
    }
}
