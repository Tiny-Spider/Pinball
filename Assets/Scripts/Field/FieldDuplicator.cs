using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure OnCollisionEnter will get called on this object
[RequireComponent(typeof(Collider))]
public class FieldDuplicator : MonoBehaviour {
	public int ballCount = 1;
	public float cooldown = 1f;

	private Game game;
	private float nextCooldown;

	void Start() {
		game = Game.instance;
	}

	/// <summary>
	/// Will check if a ball collided with this object
	/// Has a set cooldown, if it has passed it will spawn a set amount of balls on the same spot
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision) {
		Ball ball = collision.transform.GetComponent<Ball>();

		if (ball && Time.time > nextCooldown) {
			nextCooldown = Time.time + cooldown;

			for (int i = 0; i < ballCount; i++) {
				Instantiate(game.ballPrefab, ball.transform.position, ball.transform.rotation);
			}
		}
	}
}
