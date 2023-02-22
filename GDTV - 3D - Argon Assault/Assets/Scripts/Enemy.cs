using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform parent;
    [SerializeField] private int health = 50;
    [SerializeField] private int scoreAmount = 10;

    private ScoreBoard scoreBoard;
    private PlayerController playerController;

    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        SpawnPS(hitVFX);
    }

    private void ProcessHit() {
        scoreBoard.AddToScore(scoreAmount);
        CheckHealth();
    }

    private void CheckHealth() {
        health -= playerController.GetShotPower();
        if (health <= 0) {
            KillEnemy();
        }
    }

    private void KillEnemy() {
        SpawnPS(deathVFX);
        Destroy(this.gameObject);
    }

    private void SpawnPS(GameObject particleSystem) {
        GameObject vfx = Instantiate(particleSystem, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }
}
