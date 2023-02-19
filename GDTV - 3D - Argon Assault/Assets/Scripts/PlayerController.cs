using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;


    private void Update() {
        float xThrow = Input.GetAxis("Horizontal");        
        float yThrow = Input.GetAxis("Vertical");

        transform.localPosition = new Vector3(transform.localPosition.x + xThrow * moveSpeed * Time.deltaTime,
                                              transform.localPosition.y + yThrow * moveSpeed * Time.deltaTime,
                                              transform.localPosition.z);

    }
}
