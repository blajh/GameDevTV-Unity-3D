using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustPower = 1000f;
    [SerializeField] private float rotationPower = 1f;
    [SerializeField] private AudioClip thrusterSFX;

    [SerializeField] private ParticleSystem thrusterParticles;

    private Rigidbody rb;
    private AudioSource audioSource;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(thrusterSFX);
                thrusterParticles.Play();
            }
        } else {
            audioSource.Stop();
            thrusterParticles.Stop();
        }
    }

    private void ProcessRotation() {
        if (Input.GetAxis("Horizontal") != 0) {
            rb.freezeRotation = true; // freezing rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime * -Input.GetAxis("Horizontal"));
            rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
        }
    }
}
