using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // [SerializeField] private int maxHealth = 200;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private ParticleSystem bloodSplatFX;

    private void Start() {
        currentHealth = startHealth;
    }

    public void TakeDamage(int damage) {
        BroadcastMessage("OnDamageTaken");
        bloodSplatFX.Play();
        currentHealth -= damage;
        if (currentHealth <= 0) { 
            Destroy(gameObject);
        }
    }
}