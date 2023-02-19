using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update() {
        float xThrow = Input.GetAxis("Horizontal");        
        float yThrow = Input.GetAxis("Vertical");             
    }
}
