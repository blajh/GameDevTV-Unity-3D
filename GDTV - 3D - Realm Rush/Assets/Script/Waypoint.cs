using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject ballista;
    [SerializeField] private bool isPlaceable = false;

    private void OnMouseDown() {
        if (isPlaceable) {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }

    public bool GetIsPlaceable() {
        return isPlaceable;
    }
}
