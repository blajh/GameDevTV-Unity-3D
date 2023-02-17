using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust() {
        Input.GetKey(KeyCode.Space);
    }

    private void ProcessRotation() {
        Input.GetAxis("Horizontal");        
    }
}
