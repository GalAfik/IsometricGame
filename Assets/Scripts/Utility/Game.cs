using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
	// Dev cheats control
	public bool DevControls = false;

	// Service objects
	public OverworldCamera OverworldCamera;

	// Update is called once per frame
	void Update()
	{
		if (DevControls)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				// Speed up time
				Time.timeScale = 2f;
			}
			else
			{
				// Set timescale back to normal
				Time.timeScale = 1f;
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
