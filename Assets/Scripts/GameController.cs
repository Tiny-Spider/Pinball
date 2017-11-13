using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Game))]
public class GameController : MonoBehaviour {

	[Header("Flippers")]
	public HingeJoint leftFlipper;
	public HingeJoint rightFlipper;
	public float flipperActiveAngle = 45;

	[Header("Ball")]
	public Vector2 minMaxForce = new Vector2(10, 20);
	public float powerGain = 1.2f;
	public Image powerImage;

	private Game game;

	private float power;

	void Awake() {
		game = GetComponent<Game>();
	}

	void Update() {
		// Do whatever we want when game is running
		if (game.isActive) {
			if (game.ballReady) {
				ShootInput();
			}
		}

		// Allow flippers in main menu
		FlipperInput();
	}

	/// <summary>
	/// Manages the spring angle values based upon the Input
	/// </summary>
	void FlipperInput() {
		// Left spring
		JointSpring leftSpring = leftFlipper.spring;
		leftSpring.targetPosition = Input.GetKey(KeyCode.A) ? -flipperActiveAngle : 0f;
		leftFlipper.spring = leftSpring;

		// Right spring
		JointSpring rightSpring = rightFlipper.spring;
		rightSpring.targetPosition = Input.GetKey(KeyCode.D) ? flipperActiveAngle : 0f;
		rightFlipper.spring = rightSpring;
	}

	/// <summary>
	/// Manages the input for shooting a ball
	/// </summary>
	void ShootInput() {
		// If the key is down gain power
		if (Input.GetKey(KeyCode.Space)) {
			power += powerGain * Time.deltaTime;
		}

		// When released add the based on 0..1 between the minMaxForce
		if (Input.GetKeyUp(KeyCode.Space)) {
			game.ShootBall(minMaxForce.x + (Mathf.Clamp01(power) * (minMaxForce.y - minMaxForce.x)));
			power = 0f;
		}

		// Update the UI (will automaticly clamp between 0..1)
		powerImage.fillAmount = power;
	}
}
