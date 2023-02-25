using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] private int poolSize = 10;
    [SerializeField] [Range(0.1f, 30f)] private float spawnTimer = 1f;

    private float timer = 0f;
    private GameObject[] pool;

    private void Awake() {
        PopulatePool();
    }

    private void PopulatePool() {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++) {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    private void Update() {
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        if (timer < spawnTimer) {
            timer += Time.deltaTime;
        } else {
            EnableObjectInPool();
            timer = 0f;
        }
    }

    private void EnableObjectInPool() {
        for (int i = 0; i < poolSize; i++) {
            if (!pool[i].activeSelf) {
                pool[i].SetActive(true);
                return;
            }
        }
        return;
    }
}
