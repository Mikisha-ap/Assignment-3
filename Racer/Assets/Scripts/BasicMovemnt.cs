using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovemnt : MonoBehaviour
{
	public float moveSpeed = 5f;       // Walking speed
	public float jumpHeight = 2f;      // Jump strength
	public float gravity = -9.81f;     // Gravity force

	private CharacterController controller;
	private Vector3 velocity;
	private bool isGrounded;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		// Check if grounded
		isGrounded = controller.isGrounded;
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f; // Small downward force keeps grounded
		}

		// Get input
		float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
		float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

		// Move in local player space
		Vector3 move = transform.right * moveX + transform.forward * moveZ;
		controller.Move(move * moveSpeed * Time.deltaTime);

		// Jump
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		// Apply gravity
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
