using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
	[SerializeField] private float timeToDrop = 3f;
	private Rigidbody my_rigidbody;

	private void Awake() {
		my_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update() {
		CheckDrop();
	}

	private void CheckDrop() {
		if (Time.time >= timeToDrop) {
			my_rigidbody.useGravity = true;
		}
	}
}
