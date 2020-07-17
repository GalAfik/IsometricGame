using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
	public int PointValue = 100;
	public TMP_Text Label;

	// Start is called before the first frame update
	void Start()
	{
		// Set the point value label
		Label?.SetText("+" + PointValue);
	}
}
