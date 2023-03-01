using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [Header("Camera FOV")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float zoomedOutFOV = 60f;
    [SerializeField] private float zoomedInFOV = 30f;
    [SerializeField] private float zoomSpeed = 5f;

    [Header("Mouse Sensitivity")]
    [SerializeField] private float zoomedOutSensitivity = 2f;
    [SerializeField] private float zoomedInSensitivity = 0.5f;

    private RigidbodyFirstPersonController fpsController;

    private void Awake() {
        playerCamera.fieldOfView = zoomedOutFOV;
    }

    private void Start() {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update() {
        CheckZoom();
    }

    private void CheckZoom() {
        if (Input.GetMouseButton(1) && playerCamera.fieldOfView > zoomedInFOV){
            Zoom(zoomedInFOV, zoomedInSensitivity);
        } else if (!Input.GetMouseButton(1) && playerCamera.fieldOfView < zoomedOutFOV) {
            Zoom(zoomedOutFOV, zoomedOutSensitivity);
        }
    }

    private void Zoom(float targetFOV, float targetSensitivity) {
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
        fpsController.mouseLook.XSensitivity = Mathf.Lerp(fpsController.mouseLook.XSensitivity, targetSensitivity, Time.deltaTime * zoomSpeed);
        fpsController.mouseLook.YSensitivity = Mathf.Lerp(fpsController.mouseLook.YSensitivity, targetSensitivity, Time.deltaTime * zoomSpeed);
    }
}