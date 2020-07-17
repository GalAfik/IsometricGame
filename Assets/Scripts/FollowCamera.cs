using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform ObjectToFollow;
	private Vector3 CameraOffset;
	private float ZoomLevel = 1;

	[Range(0.01f, 1.0f)] public float SmoothFactor = 0.01f;

	private void Start()
	{
		// Detach from the player
		transform.parent = null;

		// Find the initial offset
		if (ObjectToFollow != null)
			CameraOffset = transform.position - ObjectToFollow.position;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (ObjectToFollow != null)
		{
			Vector3 newPosition = ObjectToFollow.position + (CameraOffset * ZoomLevel);
			transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);
		}
	}

	public void SetZoom(float zoom)
	{
		Debug.Assert(zoom > 0);
		ZoomLevel = zoom;
	}
}
