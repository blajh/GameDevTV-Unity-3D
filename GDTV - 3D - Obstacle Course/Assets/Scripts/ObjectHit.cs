using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] private float collisionColorDuration = 3f;
    [SerializeField] private Color collisionColor = Color.black;
    private Color initialColor;
    private MeshRenderer meshRenderer;
    private float transitionTimer = 0f;
    private bool isTransitioning = false;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() {
        if(isTransitioning) {
            TransitionColor();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            initialColor = meshRenderer.material.color;
            meshRenderer.material.color = collisionColor;
            isTransitioning = true;
		}
    }

    private void ResetColor() {
        meshRenderer.material.color = initialColor;
    }

    private void TransitionColor() {
        transitionTimer += Time.deltaTime;
        float timeFraction = transitionTimer / collisionColorDuration;
        if (timeFraction < 1) {
            float r, g, b, a;
            r = Mathf.Lerp(collisionColor.r, initialColor.r, timeFraction);
            g = Mathf.Lerp(collisionColor.g, initialColor.g, timeFraction);
            b = Mathf.Lerp(collisionColor.b, initialColor.b, timeFraction);
            a = Mathf.Lerp(collisionColor.a, initialColor.a, timeFraction);
            meshRenderer.material.color = new Color(r, g, b, a);
        } else {
            isTransitioning = false;
            transitionTimer = 0f;
        }
    }
}
