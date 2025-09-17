using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Camera cam1;       // Assign in Inspector
	public Camera cam2;       // Assign in Inspector
	public GameObject player1;
	public GameObject player2;

	public bool isTwoPlayer = false;  // toggle this for single / split

	void Start()
	{
		SetupGameMode();
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
}
