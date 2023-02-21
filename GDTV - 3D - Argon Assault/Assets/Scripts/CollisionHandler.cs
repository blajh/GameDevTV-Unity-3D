using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log(this.name + " --triggered-- " + other.gameObject.name);
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log($"{this.name} **collided with** {collision.gameObject.name}");
    }
}
