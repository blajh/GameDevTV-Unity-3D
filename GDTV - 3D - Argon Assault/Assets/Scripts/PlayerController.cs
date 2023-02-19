using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float xClampRange = 10f;
    [SerializeField] private float yClampRange = 5f;
    [SerializeField] private float yClampCenter = 2f;

    private void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0);
    }

    private void ProcessTranslation() {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * moveSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = yThrow * moveSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yClampCenter - yClampRange, yClampCenter + yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
