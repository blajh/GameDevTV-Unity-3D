using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 3f;

    private void Update() {
        Destroy(gameObject, destroyDelay);
    }
}
