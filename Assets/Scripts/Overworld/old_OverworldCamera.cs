using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCamera : MonoBehaviour
{
	public float MoveSpeed = 5f;
	private Vector3 Velocity;
	private float ZoomLevel = 1;
	private Vector3 InitialLookDirection;
	private bool CanMove = true;

	[Range(0.01f, 1.0f)] public float SmoothFactor = 0.01f;

	private void Start()
	{
		// Detach from the player
		transform.parent = null;

		// Get the initial looking direction
		InitialLookDirection = transform.forward;
	}

	// Update is called once per frame
	private void Update()
	{
		if (CanMove)
		{
			Move();
		}
	}

	void Move()
	{
		// Handle velocity
		Velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		// Apply velocity vector
		transform.position = Vector3.Slerp(transform.position, transform.position + Velocity, SmoothFactor);
	}

	// If the target is null, look back in the original direction and unlock movement
	public void LookAt(Transform target)
	{
		if (target != null)
		{
			transform.LookAt(target);
			//CanMove = false;
		}
		else
		{
			transform.LookAt(InitialLookDirection);
			//CanMove = true;
		}
	}

	public void SetZoom(float zoom)
	{
		Debug.Assert(zoom > 0);
		ZoomLevel = zoom;
	}
}
