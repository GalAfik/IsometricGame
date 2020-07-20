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

	public Heart[] Hearts;
	public Heart[] BlueHearts;

	private void Start()
	{
		CurrentHealth = InitialHealth;
		MaxHearts = Hearts.Length;
		MaxBlueHearts = BlueHearts.Length;
	}

	// Update is called once per frame
	void Update()
    {
		// Make sure Health doesn't exceed Hearts + Bonus hearts
		if (CurrentHealth > MaxHearts + MaxBlueHearts) CurrentHealth = MaxHearts + MaxBlueHearts;
		if (CurrentHealth < 0) CurrentHealth = 0;

		// Show all available hearts
		StartCoroutine(ShowHearts());
	}

	private IEnumerator ShowHearts()
	{
		// Show all red hearts
		for (int i = 0; i < MaxHearts; i++)
		{
			// Only show hearts that the player has
			if (i < CurrentHealth)
			{
				Hearts[i].GetComponent<Animator>().ResetTrigger("Break");
				Hearts[i].GetComponent<Animator>().SetTrigger("Enable");
				yield return new WaitForSeconds(0.1f);
			}
			else if (Hearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Enable"))
			{
				Hearts[i].GetComponent<Animator>().ResetTrigger("Enable");
				Hearts[i].GetComponent<Animator>().SetTrigger("Break");
			}
		}

		// Show all available blue hearts (excess health over the max red hearts)
		for (int i = 0; i < MaxBlueHearts; i++)
		{
			// Only show hearts that the player has
			if (i < CurrentHealth - MaxHearts)
			{
				BlueHearts[i].GetComponent<Animator>().ResetTrigger("Break");
				BlueHearts[i].GetComponent<Animator>().SetTrigger("Enable");
				yield return new WaitForSeconds(0.1f);
			}
			else if (BlueHearts[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Enable"))
			{
				BlueHearts[i].GetComponent<Animator>().ResetTrigger("Enable");
				BlueHearts[i].GetComponent<Animator>().SetTrigger("Break");
			}
		}
	}
}
