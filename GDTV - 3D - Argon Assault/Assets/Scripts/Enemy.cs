using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int health = 50;
    [SerializeField] private int scoreAmount = 10;

    private GameObject parentGameObject;
    private ScoreBoard scoreBoard;
    private PlayerController playerController;

    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        playerController = FindObjectOfType<PlayerController>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody() {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        SpawnPS(hitVFX);
    }

    private void ProcessHit() {
        CheckHealth();
    }

    private void CheckHealth() {
        health -= playerController.GetShotPower();
        if (health <= 0) {
            KillEnemy();
        }
    }

    private void KillEnemy() {
        scoreBoard.AddToScore(scoreAmount);
        SpawnPS(deathVFX);
        Destroy(this.gameObject);
    }

    private void SpawnPS(GameObject particleSystem) {
        GameObject vfx = Instantiate(particleSystem, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
