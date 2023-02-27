using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Vector2Int startCoordinates;
    [SerializeField] private Vector2Int destinationCoordinates;

    private Node startNode;
    private Node destinationNode;
    private Node currentSearchNode;

    private Queue<Node> frontier = new Queue<Node>();
    private Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    private Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    private GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null ) {
            grid = gridManager.Grid;
        }
        startNode = new Node(startCoordinates, true);
        destinationNode = new Node(destinationCoordinates, true);
    }

    private void Start() {
        BreadthFirstSearch();
    }

    private void ExploreNeighbors() {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions) {
            Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction;                        
            if (grid.ContainsKey(neighborCoordinates)) {
                neighbors.Add(grid[neighborCoordinates]);
            }
        }

        foreach (Node neighbor in neighbors) {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable) {
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch() {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while (frontier.Count > 0 && isRunning) {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == destinationCoordinates) {
                isRunning = false;
            }
        }
    }
}