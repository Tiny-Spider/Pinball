using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure OnCollisionEnter will get called on this object
[RequireComponent(typeof(Collider))]
public class FieldScore : MonoBehaviour {
	public int score;

	private GameScore gameScore;

	void Start() {
		gameScore = Game.instance.score;
	}

	/// <summary>
	/// Will check if a ball collided with this object
	/// If there is a ball it will add the score to GameScore script
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision) {
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball) {
			gameScore.AddScore(score);
		}
	}
}
