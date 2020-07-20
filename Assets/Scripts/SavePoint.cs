using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
	private Animator Animator;
	private bool Activated = false;

	private void Start()
	{
		Animator = GetComponent<Animator>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !Activated)
		{
			Activated = true;
			// Play the activation animation sequence
			Animator.SetTrigger("Activated");

			// Fully heal the player
			if (other.GetComponent<Player>().GetHealth() < other.GetComponent<Player>().GetMaxHearts())
			{
				other.GetComponent<Player>().SetHealth(other.GetComponent<Player>().GetMaxHearts());
			}
		}
	}
}
