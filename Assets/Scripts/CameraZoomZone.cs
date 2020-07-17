using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class CameraZoomZone : MonoBehaviour
{
	public float ZoomLevel = 1;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			Camera.main.GetComponent<FollowCamera>().SetZoom(ZoomLevel);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			Camera.main.GetComponent<FollowCamera>().SetZoom(1f);
	}
}