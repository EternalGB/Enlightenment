using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class RuleBlockSlot : MonoBehaviour, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

	RuleBuilder rb;

	void Awake()
	{
		rb = GameObject.FindGameObjectWithTag("RuleBuilder").GetComponent<RuleBuilder>();
	}

	public void OnPointerUp(PointerEventData data)
	{

	}

	public void OnPointerEnter(PointerEventData data)
	{
		rb.AddPointerOver(gameObject);
	}

	public void OnPointerExit(PointerEventData data)
	{
		rb.RemovePointerOver(gameObject);
	}

}

