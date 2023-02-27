using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Node currentSearchNode;
    private Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    private GridManager gridManager;

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start() {
        ExploreNeighbors();
    }

    private void ExploreNeighbors() {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions) {
            Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction;            
            if (gridManager == null) { return; }
            Node neighbor = gridManager.GetNode(neighborCoordinates);            
            if (neighbor == null) { return; }            
            neighbors.Add(neighbor);

            // TODO remove after testing            
            Dictionary<Vector2Int, Node> grid = gridManager.Grid;
            grid[neighborCoordinates].isExplored = true;
            grid[currentSearchNode.coordinates].isPath = true;
        }
    }
}
