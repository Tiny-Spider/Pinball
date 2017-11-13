using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure OnCollisionEnter will get called on this object
[RequireComponent(typeof(Collider))]
public class LoseArea : MonoBehaviour {

	/// <summary>
	/// Will check if a ball collided with this object
	/// </summary>
	/// <param name="collider"></param>
	void OnTriggerEnter(Collider collider) {
		Ball ball = collider.transform.GetComponent<Ball>();

		if (ball) {
			// Could change this to .gameObject if we want entire thing gone
			// But for now we just destroy the script so the ball stays
			Destroy(ball);

			// Sometimes Destory is quick enough and sometimes not
			Game.instance.CheckGameState();
			StartCoroutine(UpdateGame());
		}
	}

	/// <summary>
	/// Call the CheckGameState one frame later because of slow Destroy(...) 
	/// </summary>
	/// <returns></returns>
	IEnumerator UpdateGame() {
		yield return null;

		Game.instance.CheckGameState();
	}
}
