using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		// Keep this object around after scene transitions
		DontDestroyOnLoad(gameObject);
    }
}
