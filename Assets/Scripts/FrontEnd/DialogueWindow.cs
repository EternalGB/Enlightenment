using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DialogueWindow : MonoBehaviour
{

	public Text text;
	public Button confirmButton;

	public void DisplayMessage(string message, UnityAction confirmCallback)
	{
		gameObject.SetActive(true);
		text.text = message;
		confirmButton.onClick.AddListener(confirmCallback);
	}

	void OnDisable()
	{
		confirmButton.onClick.RemoveAllListeners();
	}


}

