using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevControls : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.LeftShift))
		{
			Time.timeScale = 2f;
		}
		else
		{
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
    }
}
