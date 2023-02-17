using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float thrustPower = 1000f;
    [SerializeField] private float rotationPower = 1f;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
    }

    private void ProcessRotation() {
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime * -Input.GetAxis("Horizontal"));
        }
    }
}
