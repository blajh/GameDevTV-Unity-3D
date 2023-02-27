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

    private TextMeshPro label;
	private Vector2Int coordinates = new Vector2Int();
	private Waypoint waypoint;

	private void Awake() {
		label = GetComponent<TextMeshPro>();
		label.enabled = false;
		DisplayCoordinates();
		waypoint = GetComponentInParent<Waypoint>();
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
        if (waypoint.GetIsPlaceable()) {
			label.color = defaultColor;
		} else {
			label.color = blockedColor;
		}
    }

    private void DisplayCoordinates() {
		coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
		coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
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