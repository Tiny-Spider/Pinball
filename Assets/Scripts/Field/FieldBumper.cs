using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure OnCollisionEnter will get called on this object
[RequireComponent(typeof(Collider))]
public class FieldBumper : MonoBehaviour {
	// How strong will the ball be reflected
	public float bounceForce = 1.3f;

	/// <summary>
	/// Will check if a ball collided with this object
	/// If so, apply a negative force of the first contact point times the bounceForce
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision) {
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball) {
			ball.AddForce(-(collision.contacts[0].normal * bounceForce));
		}
	}
}
