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

	private void OnMouseOver()
	{
		// Look at this level marker
		Game.OverworldCamera.LookAt(transform);
		Game.OverworldCamera.SetZoom(4f);
		print("test");
	}

	private void OnMouseExit()
	{
		/*
		// Look away from this level
		Game.OverworldCamera.LookAt(null);
		Game.OverworldCamera.SetZoom(1f);
		*/
	}

	private void OnMouseDown()
	{
		// Load this level TODO
		Game.LoadLevel(Scene);
	}
}
