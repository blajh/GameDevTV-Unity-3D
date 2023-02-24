using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlacable = false;
    [SerializeField] private GameObject ballista;

    private void OnMouseDown() {
        if (isPlacable) {
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlacable = false;
        }
    }
}
