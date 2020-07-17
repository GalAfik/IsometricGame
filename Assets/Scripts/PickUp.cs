using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	private Animator Animator;

	private void Start()
	{
		Animator = GetComponent<Animator>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// Play the collected animation when the player collects this object
			Animator.SetTrigger("Collected");
		}
	}
}
