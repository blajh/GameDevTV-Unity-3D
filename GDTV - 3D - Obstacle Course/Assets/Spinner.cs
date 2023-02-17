using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 90f;

    private void Update() {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}
