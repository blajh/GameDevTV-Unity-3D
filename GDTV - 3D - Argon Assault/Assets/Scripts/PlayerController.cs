using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;

    private void OnEnable() {
        movement.Enable();
    }

    private void OnDisable() {
        movement.Disable();
    }

    private void Update() {

        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;

        //float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log(verticalThrow);
        
        //float horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log(horizontalThrow);
    }
}
