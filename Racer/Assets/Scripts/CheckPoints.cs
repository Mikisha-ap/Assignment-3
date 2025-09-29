using UnityEngine;

public class CheckPoints : MonoBehaviour
{
	public int checkpointIndex;
	public float targetTime = 10f; // expected arrival (seconds since race start)
	public float bonus = 5f;       // time added if early
	public float penalty = 3f;     // time removed if late

	private bool triggered = false;
	private GameManager raceManager;

	void Start()
	{
		raceManager = FindObjectOfType<GameManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (triggered) return;
		if (!other.CompareTag("Player")) return;

		// Only allow correct checkpoint in sequence
		if (checkpointIndex == raceManager.nextCheckpointIndex)
		{
			float elapsed = Time.timeSinceLevelLoad;

			if (elapsed <= targetTime)
			{
				raceManager.AddTime(bonus);
				Debug.Log("Checkpoint " + checkpointIndex + " reached early! +" + bonus + "s");
			}
			else
			{
				raceManager.SubtractTime(penalty);
				Debug.Log("Checkpoint " + checkpointIndex + " reached late! -" + penalty + "s");
			}

			triggered = true;
			raceManager.AdvanceCheckpoint();
		}
		else
		{
			Debug.Log("Wrong checkpoint! Expected " + raceManager.nextCheckpointIndex);
		}
	}
}

