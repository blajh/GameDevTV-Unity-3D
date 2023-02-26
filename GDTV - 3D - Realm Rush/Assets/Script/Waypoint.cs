using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower ballista;
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private GameObject parent;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material approveMaterial;
    [SerializeField] private Material denyMaterial;

    private void Awake() {
        parent = GameObject.Find("SpawnAtRuntime");
    }

    private void OnMouseEnter() {
        CheckCanBuild();
    }

    private void OnMouseExit() {
        RenderVisual(false);
    }

    private void RenderVisual(bool state) {
        meshRenderer.enabled = state;
    }

    private void CheckCanBuild() {
        bool canBuild = ballista.CanBuild();

        if (canBuild && isPlaceable ) {
            meshRenderer.material = approveMaterial;
            RenderVisual(true);
        }

        else if (!canBuild || !isPlaceable) {
            meshRenderer.material = denyMaterial;
            RenderVisual(true);
        }
        
    }

    private void OnMouseDown() {
        PlaceTower();
        CheckCanBuild();
    }

    private void PlaceTower() {
        if (isPlaceable) {
            bool isPlaced = ballista.CreateTower(ballista, transform.position, parent);
            isPlaceable = !isPlaced;
        }
    }

    public bool GetIsPlaceable() {
        return isPlaceable;
    }
}
