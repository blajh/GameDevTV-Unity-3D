using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // [SerializeField] private int maxHealth = 200;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private int currentHealth;

    private void Start() {
        currentHealth = startHealth;
    }

    public void Damage(int damage) {
        currentHealth -= damage;        
        if(currentHealth < 0) {
            Debug.Log("Player Died");
        }
    }        
}