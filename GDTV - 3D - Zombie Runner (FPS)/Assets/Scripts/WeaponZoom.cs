using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [Header("Camera FOV")]
    [SerializeField] private RigidbodyFirstPersonController fpsController;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float zoomedOutFOV = 60f;
    [SerializeField] private float zoomedInFOV = 30f;
    [SerializeField] private float zoomSpeed = 5f;

    [Header("Mouse Sensitivity")]
    [SerializeField] private float zoomedOutSensitivity = 2f;
    [SerializeField] private float zoomedInSensitivity = 0.5f;
        
    private WeaponMove weaponMove;
    private bool weaponSwitched = false;

    private void Awake() {
        playerCamera.fieldOfView = zoomedOutFOV;
    }

    private void Start() {
        weaponMove = FindObjectOfType<WeaponMove>();
    }

    private void OnEnable() {
        weaponMove = FindObjectOfType<WeaponMove>();
    }

    private void Update() {
        CheckZoom();
        CheckSwitch();
    }

    public void CheckZoom() {
        if (weaponSwitched) {
            Zoom(zoomedOutFOV, zoomedOutSensitivity);
            weaponMove.MoveWeaponsOut();
        } else if (Input.GetMouseButton(1)) {
            Zoom(zoomedInFOV, zoomedInSensitivity);
            weaponMove.MoveWeaponsIn();
        } else if (!Input.GetMouseButton(1)) {
            Zoom(zoomedOutFOV, zoomedOutSensitivity);
            weaponMove.MoveWeaponsOut();
        }
    }

    private void CheckSwitch() {
        if (Input.GetMouseButtonDown(1)) {
            NewZoom();
        }    
    }

    private void Zoom(float targetFOV, float targetSensitivity) {
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
        fpsController.mouseLook.XSensitivity = Mathf.Lerp(fpsController.mouseLook.XSensitivity, targetSensitivity, Time.deltaTime * zoomSpeed);
        fpsController.mouseLook.YSensitivity = Mathf.Lerp(fpsController.mouseLook.YSensitivity, targetSensitivity, Time.deltaTime * zoomSpeed);
    }

    public void SwitchWeapon() {
        weaponSwitched = true;
    }

    private void NewZoom() {
        weaponSwitched = false;
    }
}