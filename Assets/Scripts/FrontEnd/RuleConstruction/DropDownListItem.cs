using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Text))]
public class DropDownListItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	public PropertyCheckSelector controller;
	public Color highlighted, notHighlighted;
	Text text;
	int index;

	void Awake()
	{
		text = GetComponent<Text>();
		text.color = notHighlighted;
	}

	public void Init(PropertyCheckSelector controller, string display, int index)
	{
		this.controller = controller;
		text.text = display;
		this.index = index;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		text.color = highlighted;
		controller.SetSelectedIndex(index);
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		text.color = notHighlighted;
		controller.SetSelectedIndex(-1);
	}

}

