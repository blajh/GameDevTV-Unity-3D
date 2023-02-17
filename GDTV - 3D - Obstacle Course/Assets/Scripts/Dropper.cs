using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
	[SerializeField] private float timeToDrop = 3f;
	private Rigidbody my_rigidbody;
	private MeshRenderer my_meshRenderer;

	private void Awake() {
		my_rigidbody = GetComponent<Rigidbody>();
		my_meshRenderer = GetComponent<MeshRenderer>();
	}

	private void Start() {
		my_rigidbody.useGravity = false;
		my_meshRenderer.enabled = false;
	}

	private void Update() {
		CheckDrop();
	}

	private void CheckDrop() {
		if (Time.time >= timeToDrop) {
			my_meshRenderer.enabled = true;
			my_rigidbody.useGravity = true;
		}
	}
}
