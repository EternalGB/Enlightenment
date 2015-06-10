using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class RuleBlockCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	
	public RuleBuilder rb;
	public GameObject nodePrefab;
	public RectTransform ghost;
	
	public void OnPointerDown(PointerEventData data)
	{
		rb.heldBlockPrefab = nodePrefab;
		ghost.gameObject.SetActive(true);
		//ghost.GetComponent<Image>().color = new Color(255,255,255,128);
		ghost.GetComponent<Image>().sprite = nodePrefab.GetComponent<RuleBlock>().previewSprite;
		ghost.position = data.position;
	}
	
	public void OnDrag (PointerEventData data)
	{

		if(rb.HasHeldBlock()) {
			ghost.position = data.position;
		}

	}


	public void OnPointerUp(PointerEventData data)
	{
		Debug.Log (name + " Pointer Up");
		if(rb.HasHeldBlock()) {
			rb.CreateHeldBlockAtPointer();
			ghost.gameObject.SetActive(false);
		}

	}

	
}

