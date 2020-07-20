using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public int InitialHealth = 5;
	public int CurrentHealth { get; set; }
	public int MaxHearts { get; private set; }
	private int MaxBlueHearts;

	public Image[] Hearts;
	public Image[] BlueHearts;

	private void Start()
	{
		CurrentHealth = InitialHealth;
		MaxHearts = Hearts.Length;
		MaxBlueHearts = BlueHearts.Length;

		// Disable all hearts before the game starts
		foreach (Image heart in Hearts)
		{
			heart.enabled = false;
		}
		foreach (Image heart in BlueHearts)
		{
			heart.enabled = false;
		}
	}

	// Update is called once per frame
	void Update()
    {
		// Make sure Health doesn't exceed Hearts + Bonus hearts
		if (CurrentHealth > MaxHearts + MaxBlueHearts)
		{
			CurrentHealth = MaxHearts + MaxBlueHearts;
		}

		// Show all available hearts
		StartCoroutine(EnableHearts());
	}

	private IEnumerator EnableHearts()
	{
		// Show all red hearts
		for (int i = 0; i < MaxHearts; i++)
		{
			// Only show hearts that the player has
			if (i < CurrentHealth)
			{
				Hearts[i].enabled = true;
				Hearts[i].GetComponent<Heart>().TriggerEnableAnimation();
				yield return new WaitForSeconds(0.1f);
			}
			else Hearts[i].enabled = false;
		}

		// Show all available blue hearts (excess health over the max red hearts)
		for (int i = 0; i < MaxBlueHearts; i++)
		{
			// Only show hearts that the player has
			if (i < CurrentHealth - MaxHearts)
			{
				BlueHearts[i].enabled = true;
				BlueHearts[i].GetComponent<Heart>().TriggerEnableAnimation();
				yield return new WaitForSeconds(0.1f);
			}
			else BlueHearts[i].enabled = false;
		}
	}
}
