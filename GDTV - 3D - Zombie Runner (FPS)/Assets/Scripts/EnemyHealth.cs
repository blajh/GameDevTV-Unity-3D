using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int hitPoints = 100;
    [SerializeField] private ParticleSystem bloodSplatFX;

    public void TakeDamage(int damage) {        
        bloodSplatFX.Play();
        hitPoints -= damage;
        if (hitPoints <= 0) { 
            Destroy(gameObject);
        }
    }
}