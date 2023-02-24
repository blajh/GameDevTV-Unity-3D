using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider hpslider;
    [SerializeField] private int maxHitPoints = 5;
    private int currentHitPoints;

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
        }
    }

    private void UpdateUI() {
        hpslider.value = (float) currentHitPoints / maxHitPoints;
    }
}
