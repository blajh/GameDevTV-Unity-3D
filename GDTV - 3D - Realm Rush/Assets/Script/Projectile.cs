using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{    
    [SerializeField] private float projectileSpeed;
        
    private void Update() {
        Fly();
    }

    private void Fly() {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other) {        
        Destroy(gameObject);
    }
}
