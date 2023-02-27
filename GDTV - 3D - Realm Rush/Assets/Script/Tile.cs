using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower ballista;
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private bool isWalkable = false;
    [SerializeField] private GameObject parent;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material approveMaterial;
    [SerializeField] private Material denyMaterial;

    private GridManager gridManager;
    private Vector2Int coordinates = new Vector2Int();

    private void Awake() {
        parent = GameObject.Find("SpawnAtRuntime");
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start() {
        if(gridManager != null) {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);            
            if(!isWalkable ) {
                gridManager.BlockNode(coordinates);
            }
        }
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
