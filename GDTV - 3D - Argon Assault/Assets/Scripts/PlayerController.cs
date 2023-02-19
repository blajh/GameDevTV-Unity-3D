using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update() {
        
        float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);
        
        float horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrow);
    }
}
