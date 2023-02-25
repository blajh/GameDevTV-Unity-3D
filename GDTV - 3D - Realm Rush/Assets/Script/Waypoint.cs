using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject ballista;
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private GameObject parent;

    private void Awake() {
        parent = GameObject.Find("SpawnAtRuntime");
    }

    private void OnMouseDown() {
        PlaceTower();
    }

    private void PlaceTower() {
        if (isPlaceable) {
            Instantiate(ballista, transform.position, Quaternion.identity, parent.transform);
            isPlaceable = false;
        }
    }

    public bool GetIsPlaceable() {
        return isPlaceable;
    }
}
