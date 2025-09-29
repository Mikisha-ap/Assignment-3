using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Attach this script to a game object in the scene, this could be an empty game object/a constant stationary game object i.e. track.
	// This script sets up  the player selection modes.

	public Camera cam1;       
	public Camera cam2;       
	public GameObject player1;
	public GameObject player2;
	public GameObject GameMode_pnl;
	public float raceTime = 60f;				// Starting time in seconds
	public TextMeshProUGUI timerText;
	//public Button twoPlayer;
	public int nextCheckpointIndex = 0;

	private bool isTwoPlayer = false;  // toggle this for single / split

	void Start()
	{
		SetupGameMode();		
	}

	private void Update()
	{
		// Countdown
		raceTime -= Time.deltaTime;
		if (raceTime < 0) raceTime = 0;

		// Update UI
		if (timerText != null)
			timerText.text = "Time: " + raceTime.ToString("F1");
	}
	void SetupGameMode()
	{
		if (isTwoPlayer)
		{
			// Enable both players & cameras
			player1.SetActive(true);
			player2.SetActive(true);
			cam1.gameObject.SetActive(true);
			cam2.gameObject.SetActive(true);

			// Split Screen (Horizontal)
			cam1.rect = new Rect(0, 0.5f, 1, 0.5f);  // top
			cam2.rect = new Rect(0, 0, 1, 0.5f);    // bottom
		}
		else
		{
			// Enable only player1 & camera1
			player1.SetActive(true);
			cam1.gameObject.SetActive(true);

			// Disable player2 & cam2
			player2.SetActive(false);
			cam2.gameObject.SetActive(false);

			// Full Screen for cam1
			cam1.rect = new Rect(0, 0, 1, 1);
		}
	}

	public void EnableTwoPlayerMode()
	{
		isTwoPlayer = true;
		SetupGameMode();
		GameMode_pnl.SetActive(false);
	}
		
	public void EnableSinglePlayerMode()
	{
		isTwoPlayer = false;
		SetupGameMode();
		GameMode_pnl.SetActive(false);
	}

	public void AddTime(float amount)
	{
		raceTime += amount;
	}

	public void SubtractTime(float amount)
	{
		raceTime -= amount;
		if (raceTime < 0) raceTime = 0;
	}

	public void AdvanceCheckpoint()
	{		
		nextCheckpointIndex++;
	}
}
