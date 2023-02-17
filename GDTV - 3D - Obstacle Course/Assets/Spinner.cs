using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float xSpin = 0f;
    [SerializeField] private float ySpin = 90f;
    [SerializeField] private float zSpin = 0f;

    private void Update() {
        transform.Rotate(xSpin * Time.deltaTime, ySpin * Time.deltaTime, zSpin * Time.deltaTime);
    }
}
