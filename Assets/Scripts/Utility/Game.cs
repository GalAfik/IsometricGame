using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	// Dev cheats control
	public bool DevControls = false;
	private bool Paused = false;

	// Service objects
	public OverworldCamera OverworldCamera;
	public MessageSystem MessageSystem;

	// Update is called once per frame
	void Update()
	{
		if (DevControls)
		{
			if (!Paused)
			{
				if (Input.GetKey(KeyCode.LeftShift)) Time.timeScale = 2f; // Speed up time
				else Time.timeScale = 1f; // Set timescale back to normal
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				// Quit the game
				Application.Quit();
			}

			if (Input.GetKeyDown(KeyCode.R))
			{
				// Reload the current scene
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

			if (Input.GetKeyDown(KeyCode.Return))
			{
				// Toggle pausing the game
				if (!Paused) Time.timeScale = 0f;
				else Time.timeScale = 1f;
				Paused = !Paused;
			}

			if (Input.GetKeyDown(KeyCode.M))
			{
				MessageSystem.DisplayMessage("This is a test!!!");
			}
		}
	}

	public void LoadLevel(string scene)
	{
		try
		{
			SceneManager.LoadScene(scene);
		}
		catch (System.Exception)
		{
			print("This level is not available in the scene manager!");
		}
	}
}
