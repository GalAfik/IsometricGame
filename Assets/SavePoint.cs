using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
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
			// Play the activation animation sequence
			Animator.SetTrigger("Activated");
		}
	}
}
