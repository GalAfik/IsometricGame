using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotion : MonoBehaviour
{
	public int BlueHeartValue = 1;
	private bool InRange;
	private bool Collected = false;

	private void Update()
	{
		// Check ifthe input button is pressed and the player is within range
		if (Input.GetButtonDown("Action") && InRange && !Collected)
		{
			Collected = true;
			// Fill the player's Red hearts
			if (FindObjectOfType<Player>().GetHealth() < FindObjectOfType<Player>().GetMaxHearts())
			{
				FindObjectOfType<Player>().SetHealth(FindObjectOfType<Player>().GetMaxHearts());
			}

			// Add blue hearts to the player's health
			FindObjectOfType<Player>().SetHealth(FindObjectOfType<Player>().GetHealth() + BlueHeartValue);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) InRange = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) InRange = false;
	}
}
