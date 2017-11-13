using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public static Game instance { get; private set; }

	public bool isActive = false;
	public bool ballReady = true;
	public int ballCount = 3;
	public Text ballCountText;

	[Header("Game UI")]
	public RectTransform menuPanel;
	public RectTransform gamePanel;
	public RectTransform endPanel;

	[Header("Ball")]
	public int ballStartCount = 3;
	public GameObject ballDisplay;
	public Ball ballPrefab;
	public Transform ballSpawnPoint;

	public GameScore score { get; private set; }
	public GameController controller { get; private set; }

	void Awake() {
		instance = this;

		score = GetComponent<GameScore>();
		controller = GetComponent<GameController>();
	}

	void Start() {
		isActive = false;

		SetBallReady(false);

		// Display the right UI panel
		menuPanel.gameObject.SetActive(true);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(false);
	}
	
	/// <summary>
	/// Start the game, will apply the correct Actives and show right panel
	/// </summary>
	public void StartGame() {
		isActive = true;
		ballCount = ballStartCount;
		ballCountText.text = ballCount.ToString();

		SetBallReady(true);

		score.ClearScore();

		// Display the right UI panel
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(true);
		endPanel.gameObject.SetActive(false);
	}

	/// <summary>
	/// End the game, will apply the correct Actives and show right panel
	/// </summary>
	public void EndGame() {
		isActive = false;

		// Display the right UI panel
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(true);
	}

	/// <summary>
	/// Shoot a ball from the spawnpoint with a set force
	/// </summary>
	/// <param name="force"></param>
	public void ShootBall(float force) {
		// Remove one ball from the count and update the UI
		ballCount--;
		SetBallReady(false);

		// Spawn it at the spawnPoint and add force
		Ball ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
		ball.AddForce(ballSpawnPoint.forward * force);
	}

	/// <summary>
	/// When a ball is taken out of the game this will get called
	/// It will either spawn a new ball or end the game
	/// </summary>
	public void CheckGameState() {
		// Find all balls in the current scene
		int activeBallCount = FindObjectsOfType<Ball>().Length;

		// If there isn't any left then take action
		if (activeBallCount <= 0) {
			// If we can't spawn another one we game over
			if (ballCount <= 0) {
				EndGame();
				SetBallReady(false);
			}
			else {
				SetBallReady(true);
			}
		}
	}

	/// <summary>
	/// Make the game ready for shooting a ball
	/// Will also update the fake display ball and the UI
	/// </summary>
	/// <param name="ready"></param>
	void SetBallReady(bool ready) {
		ballReady = ready;
		ballDisplay.SetActive(ready);
		ballCountText.text = ballCount.ToString();
	}
}
