using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	private Animator Animator;
	private bool Collected = false;

	private void Start()
	{
		Animator = GetComponent<Animator>();

		// Start the Idle animation on a random frame to vary monster animations
		AnimatorStateInfo state = Animator.GetCurrentAnimatorStateInfo(0);
		Animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !Collected)
		{
			Collected = true;
			// Play the collected animation when the player collects this object
			Animator.SetTrigger("Collected");
		}
	}
}
