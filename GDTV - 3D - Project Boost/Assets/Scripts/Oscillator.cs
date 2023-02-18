using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0f, 1f)] private float movementFactor;
    private Vector3 startingPosition;

    private void Start() {
        startingPosition = transform.position;
    }

    private void Update() {
        Vector3 offset = movementVector * movementFactor;
        transform.position = offset;
    }


}
