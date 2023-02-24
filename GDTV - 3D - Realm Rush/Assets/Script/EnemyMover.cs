using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	[SerializeField] private List<Waypoint> path = new List<Waypoint>();
	[SerializeField] [Range(0f, 5f)] private float moveSpeed = 1f;
	[SerializeField] [Range(0f, 5f)] private float rotationDuration = 1f;

    private void Start() {
		StartCoroutine(FollowPath());
	}

	private IEnumerator FollowPath() {
		foreach (Waypoint waypoint in path) {

			float rotationTime = 0f;
			Vector3 targetDir = waypoint.transform.position - transform.position;

            Quaternion newRot = Quaternion.LookRotation(targetDir, Vector3.up);

			while (transform.rotation != newRot) {
				rotationTime += Time.deltaTime;
				transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationTime / rotationDuration);
				yield return null;
			}

			if (transform.rotation == newRot) {

                Vector3 startPos = transform.position;
                Vector3 endPos = waypoint.transform.position;
                float travelPercent = 0f;

				while (travelPercent < 1f) {
					travelPercent += Time.deltaTime * moveSpeed;
					transform.position = Vector3.Lerp(startPos, endPos, travelPercent);			
					yield return new WaitForEndOfFrame();
				}
            }
		}
	}
}