using UnityEngine;
using System.Collections;

public class ToolGridController : MonoBehaviour
{

	public ScreenSelectionController screenCont;
	bool isOpen;
	public Animator toolGrid;

	void Awake()
	{
		isOpen = false;
	}

	public void ToggleToolGrid()
	{
		if(isOpen) {
			screenCont.GoBack();
			isOpen = false;
		} else {
			screenCont.SwapTo(toolGrid);
			isOpen = true;
		}
	}

	public void SetClosed()
	{
		isOpen = false;
	}

}

