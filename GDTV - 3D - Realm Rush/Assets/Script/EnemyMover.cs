using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] private float moveSpeed = 1f;
	[SerializeField] [Range(0f, 5f)] private float rotationDuration = 1f;
    [SerializeField] private bool rotateCorners = false;	

	private List<Node> path = new List<Node>();
    private GridManager gridManager;
    private Pathfinder pathfinder;
    private Enemy enemy;

    private void Awake() {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }
    
    private void OnEnable() {
		RecalculatePath();
		ReturnToStart();
		StartCoroutine(FollowPath());
	}

	private void RecalculatePath() {
		path.Clear();
        path = pathfinder.GetNewPath();
	}

	private void ReturnToStart() {
		transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
	}

	private IEnumerator FollowPath() {
        for (int i = 0; i < path.Count; i++) {

            float rotationTime = 0f;
            Vector3 targetDir = gridManager.GetPositionFromCoordinates(path[i].coordinates) - transform.position;
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
                Vector3 endPos = gridManager.GetPositionFromCoordinates(path[i].coordinates);
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