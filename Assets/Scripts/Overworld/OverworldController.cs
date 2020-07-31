using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverworldController : MonoBehaviour
{
	public OverworldLevel[] Levels;
	private int SelectedIndex = 0;
	private bool AxisInputDown = false;

	public TMP_Text LevelNameLabel;

    // Update is called once per frame
    void Update()
    {
		// Handle selecting a new level using the vertical axis
		if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
		{
			if (AxisInputDown == false)
			{
				SelectedIndex += Input.GetAxis("Vertical") > 0 ? 1 : -1;
			}
			// Lock the axis movement until it is let go
			AxisInputDown = true;
		}
		else AxisInputDown = false;

		// Fix the selected level index if it is out of range
		if (SelectedIndex < 0) SelectedIndex = 0;
		if (SelectedIndex >= Levels.Length) SelectedIndex = Levels.Length - 1;

		// Once a level is selected
		if (Levels[SelectedIndex] != null)
		{
			// Move to the currently selected level
			transform.position = Levels[SelectedIndex].transform.position;

			// Set the level name label
			LevelNameLabel?.SetText(Levels[SelectedIndex].name);

			// Handle Loading the level
			if (Input.GetButtonDown("Submit"))
			{
				Levels[SelectedIndex].LoadLevel();
			}
		}
	}
}
