using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;

    private void Update() {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * zSpeed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime, 0, 0);
        
        //transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
    }
}
