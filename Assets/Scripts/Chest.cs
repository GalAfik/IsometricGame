using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
	public int PointValue = 100;
	public TMP_Text Label;

	private bool InRange;
	private bool Collected = false;

	private Animator Animator;

	// Start is called before the first frame update
	private void Start()
	{
		Animator = GetComponent<Animator>();

		// Set the point value label
		Label?.SetText("+" + PointValue);
	}

	private void Update()
	{
		// Check ifthe input button is pressed and the player is within range
		if (Input.GetButtonDown("Action") && InRange && !Collected)
		{
			Collected = true;
			// Add points
			FindObjectOfType<Game>().SetPoints(FindObjectOfType<Game>().GetPoints() + PointValue);

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
