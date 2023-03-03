using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // [SerializeField] private int maxHealth = 200;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private ParticleSystem bloodSplatFX;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyAI enemyAI;

    private void Start() {
        currentHealth = startHealth;
    }

    public void TakeDamage(int damage) {
        BroadcastMessage("OnDamageTaken");
        bloodSplatFX.Play();
        currentHealth -= damage;
        if (currentHealth <= 0) {
            animator.SetTrigger("die");
            enemyAI.Die();
        }
    }
}