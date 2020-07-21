using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
	public TMP_Text PointsText;
	public float DisplayTime = 1f;
	private float DisplayTimer;
	private Animator Animator;

	private void Start()
	{
		Animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (DisplayTimer > 0)
		{
			Animator.SetTrigger("Display"); // Trigger
			Animator.ResetTrigger("Dismiss");
		}
		else
		{
			Animator.SetTrigger("Dismiss"); // Trigger
			Animator.ResetTrigger("Display");
		}

		// Decrement the timer
		DisplayTimer -= Time.deltaTime;
	}

	private void OnGUI()
	{
		PointsText?.SetText(FindObjectOfType<Game>().GetPoints().ToString());
	}

	public void DisplayPoints()
	{
		// Add time to the display timer
		DisplayTimer = DisplayTime;
	}
}
