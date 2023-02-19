using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float xClampRange = 10f;
    [SerializeField] private float yClampRange = 5f;
    [SerializeField] private float yClampCenter = 2f;

    [Header("Rotations")]
    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float controlPitchFactor = -10f;
    [SerializeField] private float positionYawFactor = 2f;
    [SerializeField] private float controlRollFactor = -20f;
    [SerializeField] private bool affectPitch = true;
    [SerializeField] private bool affectYaw = true;
    [SerializeField] private bool affectRoll = true;

    private float xThrow, yThrow;

    private void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {

        float pitchDueToPosition = (transform.localPosition.y - yClampCenter) * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;
                
        float roll = xThrow * controlRollFactor;

        if (affectPitch) {
            transform.localRotation = Quaternion.Euler(pitch, transform.localRotation.y, transform.localRotation.z);
        }

        if (affectYaw) {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, yaw, transform.localRotation.z);
        }

        if (affectRoll) {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, roll);
        }
    }

    private void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * moveSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = yThrow * moveSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yClampCenter - yClampRange, yClampCenter + yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
