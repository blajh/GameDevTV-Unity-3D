using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float zSpeed;

    private void Update() {
        Mover();
    }

    private void Mover() {
        float xMove = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        float zMove = Input.GetAxis("Vertical") * zSpeed * Time.deltaTime;
        transform.Translate(xMove, 0, zMove);
    }
}
