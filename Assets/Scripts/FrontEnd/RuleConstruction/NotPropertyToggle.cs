using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotPropertyToggle : MonoBehaviour
{

	const string notText = "NOT";

	public Text text;
	public bool isNot = false;

	public void ToggleNot()
	{
		isNot = !isNot;
		if(isNot) {
			text.text = notText;
		} else {
			text.text = "";
		}
	}

}

