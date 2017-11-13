using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Game))]
public class GameScore : MonoBehaviour {
	public int score { get; private set; }

	public Text scoreText;
	public string scoreTextFormat = "Score: {0}";

	public Text scoreEndText;
	public string scoreEndTextFormat = "Final Score: {0}";

	/// <summary>
	/// Add score to the current score
	/// </summary>
	/// <param name="score">Amount</param>
	public void AddScore(int score) {
		this.score += score;
		UpdateScore();
	}

	/// <summary>
	/// Clear the current score
	/// </summary>
	public void ClearScore() {
		score = 0;
		UpdateScore();
	}

	/// <summary>
	/// Update the score UI elements with correct formatting
	/// </summary>
	void UpdateScore() {
		scoreText.text = string.Format(scoreTextFormat, this.score);
		scoreEndText.text = string.Format(scoreEndTextFormat, this.score);
	}
}
