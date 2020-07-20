using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	private bool InRange;
	private bool Collected = false;

	private Animator Animator;

	private void Start()
	{
		Animator = GetComponent<Animator>();

		// Start the Idle animation on a random frame to vary monster animations
		AnimatorStateInfo state = Animator.GetCurrentAnimatorStateInfo(0);
		Animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
	}

	private void Update()
	{
		// Check ifthe input button is pressed and the player is within range
		if (Input.GetButtonDown("Action") && InRange && !Collected)
		{
			Collected = true;
			// Set the collected animation
			Animator.SetTrigger("Collected");
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
