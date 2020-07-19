using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{
	public int HeartValue = 1;
	private bool Collected = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !Collected)
		{
			Collected = true;
			// Add hearts to the player's health if the current health is less than the max red hearts
			if (other.GetComponent<Player>().GetHealth() < other.GetComponent<Player>().GetMaxHearts())
			{
				other.GetComponent<Player>().SetHealth(other.GetComponent<Player>().GetHealth() + HeartValue);
			}
		}
	}
}
