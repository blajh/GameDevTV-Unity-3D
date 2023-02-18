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
    [SerializeField] private ParticleSystem leftParticles;
    [SerializeField] private ParticleSystem rightParticles;

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
            StartThrusting();
        } else {
            StopThrusting();
        }
    }

    private void ProcessRotation() {
        float Axis = Input.GetAxis("Horizontal");
        if (Axis != 0) {
            HandleRotation();

            if (Axis > 0) {
                PlayParticlesLeft();
            } else if (Axis < 0) {
                PlayParticlesRight();
            }

        } else if (Axis == 0) {
            StopBothParticles();
        }
    }

    private void StartThrusting() {
        rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(thrusterSFX);
            if (!thrusterParticles.isPlaying) {
                thrusterParticles.Play();
            }
        }
    }

    private void StopThrusting() {
        audioSource.Stop();
        thrusterParticles.Stop();
    }

    private void StopBothParticles() {
        leftParticles.Stop();
        rightParticles.Stop();
    }

    private void PlayParticlesLeft() {
        if (!leftParticles.isPlaying) {
            leftParticles.Play();
        }
    }

    private void PlayParticlesRight() {
        if (!rightParticles.isPlaying) {
            rightParticles.Play();
        }
    }

    private void HandleRotation() {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime * -Input.GetAxis("Horizontal"));
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
