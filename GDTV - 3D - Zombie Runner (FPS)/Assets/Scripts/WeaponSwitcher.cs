using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int currentWeaponIndex = 0;

    private void Start() {
        SetWeaponActive();
    }

    private void SetWeaponActive() {
        int weaponIndex = 0;

        foreach (Transform weapon in transform) {
            if (weaponIndex == currentWeaponIndex) {
                weapon.gameObject.SetActive(true);
                weapon.GetComponent<WeaponZoom>().CheckZoom();
            } else {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void Update() {
        SwitchWeapon();
    }

    private void SwitchWeapon() {
        CheckKeyboardInput();
        CheckMouseInput();
    }

    private void CheckMouseInput() {
        if (Input.mouseScrollDelta.y > 0) {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0) {
                currentWeaponIndex = transform.childCount - 1;
            }
            SetWeaponActive();
        }

        else if (Input.mouseScrollDelta.y < 0) {
            currentWeaponIndex++;
            if (currentWeaponIndex > transform.childCount - 1) {
                currentWeaponIndex = 0;
            }
            SetWeaponActive();
        }
    }

    private void CheckKeyboardInput() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeaponIndex = 0;
            SetWeaponActive();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeaponIndex = 1;
            SetWeaponActive();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            currentWeaponIndex = 2;
            SetWeaponActive();
        }
    }
}
