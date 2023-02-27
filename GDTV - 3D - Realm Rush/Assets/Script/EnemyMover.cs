using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
	[SerializeField] private List<Tile> path = new List<Tile>();
	[SerializeField] [Range(0f, 5f)] private float moveSpeed = 1f;
	[SerializeField] [Range(0f, 5f)] private float rotationDuration = 1f;
    [SerializeField] private bool rotateCorners = false;	
    private Enemy enemy;

    private void OnEnable() {
		FindPath();
		ReturnToStart();
		StartCoroutine(FollowPath());
	}

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

	private void FindPath() {
		path.Clear();
		GameObject parent = GameObject.FindGameObjectWithTag("Path");
		foreach(Transform child in parent.transform) {
			Tile waypoint = child.GetComponent<Tile>();
			if (waypoint != null) {
				path.Add(waypoint);
			}
		}
	}

	private void ReturnToStart() {
		transform.position = path[0].transform.position;
	}

	private IEnumerator FollowPath() {
        foreach (Tile waypoint in path) {

            float rotationTime = 0f;
            Vector3 targetDir = waypoint.transform.position - transform.position;
            if (targetDir == Vector3.zero) {
                targetDir.x = Vector3.kEpsilon;
            }

            Quaternion newRot = Quaternion.LookRotation(targetDir, Vector3.up);

            while (transform.rotation != newRot && rotateCorners) {
                rotationTime += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationTime / rotationDuration);
                yield return null;
            }

            if (transform.rotation == newRot || !rotateCorners) {

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
        FinishPath();
    }

    private void FinishPath() {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}