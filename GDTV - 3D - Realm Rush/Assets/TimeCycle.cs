using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    [SerializeField] private Light sunLight;

    [Header("Intensity - start - mid - end")]
    [SerializeField] private Vector3 intensity;

    [Header("Rotation")]
    [SerializeField] private Vector3 startRotation;
    [SerializeField] private Vector3 midRotation;
    [SerializeField] private Vector3 endRotation;

    [Header("Color")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color midColor;
    [SerializeField] private Color endColor;

    [Header("Cycle")]
    [SerializeField] private float cycleDurationSeconds;

    [Header("Debug")]
    [SerializeField] private bool useDebugSlider = false;
    [SerializeField] [Range(0f, 1f)] private float cyclePercentage;

    private float halfTime;

    private void Start() {
        halfTime = cycleDurationSeconds / 2;
    }

    private void Update() {
        RunCycle();
    }

    private void RunCycle() {
        
        if (!useDebugSlider) {
            
            SetSlider();
            SetColor();
            SetRotation();
            SetIntensity();

        } else {
            
            SetColor();
            SetRotation();
            SetIntensity();
        }
    }

    private void SetSlider() {
        cyclePercentage = Time.timeSinceLevelLoad / cycleDurationSeconds;
    }

    private void SetColor() {
        if (Time.timeSinceLevelLoad < halfTime) {
            sunLight.color = Color.Lerp(startColor, midColor, cyclePercentage * 2);
        } 
        
        else if (Time.timeSinceLevelLoad > halfTime) {
            sunLight.color = Color.Lerp(midColor, endColor, (cyclePercentage - 0.5f) * 2);
        }
    }

    private void SetRotation() {
        if (Time.timeSinceLevelLoad < halfTime) {
            Vector3 rotation = Vector3.Lerp(startRotation, midRotation, cyclePercentage * 2);
            sunLight.transform.rotation = Quaternion.Euler(rotation);
        } else if (Time.timeSinceLevelLoad > halfTime) {
            Vector3 rotation = Vector3.Lerp(midRotation, endRotation, (cyclePercentage - 0.5f) * 2);
            sunLight.transform.rotation = Quaternion.Euler(rotation);
        }
    }

    private void SetIntensity() {
        if (Time.timeSinceLevelLoad < halfTime) {
            sunLight.intensity = Mathf.Lerp(intensity.x, intensity.y, cyclePercentage * 2);
        } else if (Time.timeSinceLevelLoad > halfTime) {
            sunLight.intensity = Mathf.Lerp(intensity.y, intensity.z, (cyclePercentage - 0.5f) * 2);
        }
    }
}
