using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTimer = 1f;
    private float timer = 0f;

    private void Update() {
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        if (timer < spawnTimer) {
            timer += Time.deltaTime;
        } else {
            Instantiate(enemyPrefab, transform);
            timer = 0f;
        }
    }
}
