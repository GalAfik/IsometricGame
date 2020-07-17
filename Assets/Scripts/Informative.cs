using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Informative : MonoBehaviour
{
	public SpeechBubble MessageBubble;
	public List<string> Messages; // A list of messages that may be displayed
	[Range(0.5f, 2f)] public float CameraZoomLevel = 0.8f;

	private void Start()
	{
		// Start with the message bubble disabled.
		MessageBubble?.gameObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		// Check if the player is within range
		if (other.CompareTag("Player"))
		{
			// Display a random message
			string message = Messages[Random.Range(0, Messages.Count)];
			MessageBubble?.Text.SetText(message);
			// Enable the message bubble
			MessageBubble?.gameObject.SetActive(true);

			// Zoom the camera in
			Camera.main.GetComponent<FollowCamera>().SetZoom(CameraZoomLevel);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		// Check if the player is no longer within range
		if (other.CompareTag("Player"))
		{
			// Disable the message bubble
			MessageBubble?.gameObject.SetActive(false);

			// Reset the camera zoom level
			Camera.main.GetComponent<FollowCamera>().SetZoom(1f);
		}
	}
}
