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

    private void Start() {
        currentHitPoints = maxHitPoints;
    }

    private void OnTriggerEnter(Collider other) {
        currentHitPoints--;
        hpslider.value = (float) currentHitPoints / maxHitPoints;
        CheckHP();
    }

    private void CheckHP() {
        if (currentHitPoints <= 0) {
            Destroy(gameObject);
        }
    }
}
