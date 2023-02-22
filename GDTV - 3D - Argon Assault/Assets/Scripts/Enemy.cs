using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private Transform parent;
    [SerializeField] private int scoreAmount = 10;

    private ScoreBoard scoreBoard;

    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        KillEnemy();
    }

    private void ProcessHit() {
        scoreBoard.AddToScore(scoreAmount);
    }

    private void KillEnemy() {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
