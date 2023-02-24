using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float seconds;
    private float timer = 0f;

    private void Update() {
        CheckTime();
    }

    private void CheckTime() {
        if (timer < seconds) {
            timer += Time.deltaTime;
        } else {
            timer = 0f;
            Destroy(gameObject);
        }
    }
}
