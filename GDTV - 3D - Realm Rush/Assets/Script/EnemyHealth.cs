using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider hpslider;
    [SerializeField] private int maxHitPoints = 5;

    [Tooltip("Adds amount to Max Hit Points when enemy dies")]
    [SerializeField] private int difficultyRamp = 1;
    private int currentHitPoints;
    private Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable() {
        currentHitPoints = maxHitPoints;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other) {
        currentHitPoints--;
        UpdateUI();
        CheckHP();
    }

    private void CheckHP() {
        if (currentHitPoints <= 0) {
            gameObject.SetActive(false);
            enemy.RewardGold();
            maxHitPoints += difficultyRamp;
        }
    }

    private void UpdateUI() {
        hpslider.value = (float) currentHitPoints / maxHitPoints;
    }
}
