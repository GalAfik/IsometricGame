using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour
{
	public TMP_Text Text;
	private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
		Animator = GetComponent<Animator>();
    }

	public void DisplayMessage(string message)
	{
		Text.SetText(message);
		Animator?.SetTrigger("Display");
	}
}
