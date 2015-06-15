using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PropertyCheckSelector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

	GameController gc;
	public Text selectedText;
	public RectTransform dropDownList;
	public GameObject listItemPrefab;
	List<IPropertyChecker> checkers;
	[SerializeField]
	int selectedItemIndex;

	public delegate void SelectedHandler(IPropertyChecker checker);
	public event SelectedHandler OnCheckerSelected;

	public NotPropertyToggle notToggle;

	void Start()
	{
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		checkers = new List<IPropertyChecker>();
		//generate all checks
		checkers.Add(new PropertyCheckers.Identity());
		foreach(string property in gc.pieceInfo.properties.Keys) {
			foreach(string value in gc.pieceInfo.properties[property]) {
				checkers.Add(new PropertyCheckers.PropertyHasValue(property, value));
			}
		}
		//TODO - piece specific properties e.g. face value etc.

		//generate the selectable list
		for(int i = 0; i < checkers.Count; i++) {
			IPropertyChecker check = checkers[i];
			DropDownListItem listItem = Instantiate(listItemPrefab).GetComponent<DropDownListItem>();
			listItem.transform.SetParent(dropDownList);
			listItem.Init(this, check.ToString(), i);

		}

		/*
		//add the negations of each property
		for(int i = 0; i < checkers.Count; i++) {
			IPropertyChecker check = new PropertyCheckers.Not(checkers[i]);
			DropDownListItem listItem = Instantiate(listItemPrefab).GetComponent<DropDownListItem>();
			listItem.transform.SetParent(dropDownList);
			listItem.Init(this, check.ToString(), i);
			
		}
		*/

		dropDownList.gameObject.SetActive(false);

		selectedItemIndex = -1;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		dropDownList.gameObject.SetActive(true);
	}

	public void SetSelectedIndex(int index)
	{
		selectedItemIndex = index;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		if(selectedItemIndex >= 0) {
			selectedText.text = checkers[selectedItemIndex].ToString();
			UpdateSelectedChecker();
			//selectedItemIndex = -1;
		}
		dropDownList.gameObject.SetActive(false);
	}

	public void OnDrag(PointerEventData data)
	{
		//have to have this here to intercept the up event when the drag ends
	}

	void UpdateSelectedChecker()
	{
		if(OnCheckerSelected != null) {
			IPropertyChecker checker = checkers[selectedItemIndex];
			if(notToggle.isNot)
				checker = new PropertyCheckers.Not(checker);
			OnCheckerSelected(checker);
		}
	}

	public void ToggleNot()
	{
		notToggle.ToggleNot();
		if(selectedItemIndex >= 0) {
			UpdateSelectedChecker();
		}
	}
}

