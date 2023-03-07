using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private FlashLightSystem flashlight;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInChildren<FlashLightSystem>() != null) {
            flashlight = other.gameObject.GetComponentInChildren<FlashLightSystem>();
            flashlight.ResetFlashLight();
            Destroy(gameObject);
        }
    }
}