using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public int InitialHealth = 5;
	private int CurrentHealth;

	public Image[] Hearts;
	public Image[] BlueHearts;

	private void Start()
	{
		CurrentHealth = InitialHealth;
	}

	// Update is called once per frame
	void Update()
    {
		// Make sure Health doesn't exceed Hearts + Bonus hearts
		if (CurrentHealth > Hearts.Length + BlueHearts.Length)
		{
			CurrentHealth = Hearts.Length + BlueHearts.Length;
		}

		// Show all available hearts
		for (int i = 0; i < Hearts.Length; i++)
		{
			// Only show hearts that the player has
			if (i < CurrentHealth) Hearts[i].enabled = true;
			else Hearts[i].enabled = false;
		}

		// Show all available blue hearts (excess health over the max red hearts)
		for (int i = 0; i < BlueHearts.Length; i++)
		{
			// Only show hearts that the player has
			if (i < CurrentHealth - Hearts.Length) BlueHearts[i].enabled = true;
			else BlueHearts[i].enabled = false;
		}
	}
}
