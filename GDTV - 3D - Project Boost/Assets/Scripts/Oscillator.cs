using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0f, 1f)] private float movementFactor;
    [SerializeField] private float period = 2f;
    private Vector3 startingPosition;

    private void Start() {
        startingPosition = transform.position;
    }

    private void Update() {
        if (period < Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSineWave + 1f) / 2f; // clamping -1,1 to 0,1 (our Range)
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
