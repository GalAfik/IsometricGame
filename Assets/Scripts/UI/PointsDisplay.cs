using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
	public TMP_Text PointsText;
	private Animator Animator;

	private void Start()
	{
		Animator = GetComponent<Animator>();
	}

	private void OnGUI()
	{
		PointsText?.SetText(FindObjectOfType<Game>().GetPoints().ToString());
	}

	public void Display()
	{
		Animator.SetTrigger("Display");
	}
}
