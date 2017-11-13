using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure this has a rigidbody to do GetComponent on
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	public Rigidbody rigidBody { get; private set; }

	void Awake() {
		rigidBody = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Add a instantaneous force to the ball
	/// </summary>
	/// <param name="force"></param>
	public void AddForce(Vector3 force) {
		rigidBody.AddForce(force, ForceMode.VelocityChange);
	}
}
