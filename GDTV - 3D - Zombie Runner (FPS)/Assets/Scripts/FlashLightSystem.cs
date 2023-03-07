using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] private float lightIntensityDecay = 0.1f;
    [SerializeField] private float lightAngleDecay = 1f;
    [SerializeField] private float minimumAngle = 20f;

    private Light myLight;
    private float initialAngle;
    private float initialIntensity;

    private void Awake() {
        myLight = GetComponent<Light>();
        initialIntensity = myLight.intensity;
        initialAngle = myLight.spotAngle;
    }

    private void Update() {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    private void DecreaseLightAngle() {
        if (myLight.spotAngle <= minimumAngle) {
            return;
        }
        myLight.spotAngle -= lightAngleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity() {
        myLight.intensity -= lightIntensityDecay * Time.deltaTime;
    }

    public void ResetFlashLight() {
        myLight.intensity = initialIntensity;
        myLight.spotAngle = initialAngle;
    }
}