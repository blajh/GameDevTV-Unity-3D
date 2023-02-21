using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    private bool isTransitioning = false;
    private bool collisionDisabled = false;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + " --triggered-- " + other.gameObject.name);
        if (isTransitioning || collisionDisabled) { return; }
        StartCrashSequence();
    }

    private void StartCrashSequence() {
        isTransitioning = true;
        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}