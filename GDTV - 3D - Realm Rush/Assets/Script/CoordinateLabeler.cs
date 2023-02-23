using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour {

	private TextMeshPro label;
	private Vector2Int coordinates = new Vector2Int();

	private void Awake() {
		label = GetComponent<TextMeshPro>();
		DisplayCoordinates();
	}

    private void Update() {
		if (!Application.isPlaying) {
			DisplayCoordinates();
			UpdateParentName();
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
}