using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 2f;
    [SerializeField] private ParticleSystem explosionPS;     

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
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        explosionPS.Play();        
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}