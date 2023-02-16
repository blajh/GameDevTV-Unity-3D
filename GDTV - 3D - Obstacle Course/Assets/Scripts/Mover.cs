using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update() {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
}
