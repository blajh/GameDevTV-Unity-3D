using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour {

	[SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f, 0.5f, 0f);

    private TextMeshPro label;
	private Vector2Int coordinates = new Vector2Int();
	private GridManager gridManager;

	private void Awake() {
		gridManager = FindObjectOfType<GridManager>();
		label = GetComponent<TextMeshPro>();
		label.enabled = false;
		DisplayCoordinates();		
	}

    private void Update() {
		if (!Application.isPlaying) {
			DisplayCoordinates();
			UpdateParentName();
		}

		SetLabelColor();
		ToggleLabels();
	}

    private void SetLabelColor() {

		if (gridManager == null) { return; }

		Node node = gridManager.GetNode(coordinates);

		if (node == null) { return; }

		if (!node.isWalkable) {
			label.color = blockedColor;
		} else if (node.isPath) {
			label.color = pathColor;
		} else if (node.isExplored) {
			label.color = exploredColor;
		} else {
			label.color = defaultColor;
		}
    }

    private void DisplayCoordinates() {
		if (gridManager == null) { return; }
		coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
		coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
		label.text = coordinates.x + "," + coordinates.y;
    }

	private void UpdateParentName() {
		transform.parent.name = coordinates.ToString();
	}

	private void ToggleLabels() {
		if(Input.GetKeyDown(KeyCode.C)) {
			label.enabled = !label.IsActive();
		}
	}
}