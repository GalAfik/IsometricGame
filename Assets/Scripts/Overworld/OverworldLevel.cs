using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScenePicker))]

public class OverworldLevel : MonoBehaviour
{
	// Include the ServiceLocator
	private Game Game;

	// The scene referenced by this level marker
	private string Scene;

	private void Start()
	{
		// Get the ServiceLocator
		Game = FindObjectOfType<Game>();

		// Get the scene reference from the scene picker script
		Scene = GetComponent<ScenePicker>()?.scenePath;
	}

	public void LoadLevel()
	{
		// Load this level
		Game.LoadLevel(Scene);
	}
}
