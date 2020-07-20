using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
	private Animator Animator;

	// Start is called before the first frame update
	void Awake()
	{
		Animator = GetComponent<Animator>();
		enabled = false;
	}

	public void TriggerEnableAnimation()
	{
		// Play the enable animation
		Animator?.SetTrigger("Enable");
	}
}
