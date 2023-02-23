using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	[SerializeField] private List<Waypoint> path = new List<Waypoint>();

	private void Start() {
		PrintWaypointNames();
	}

	private void PrintWaypointNames() {
		foreach (Waypoint waypoint in path) {
			Debug.Log(waypoint.name);
		}
	}
}
