using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class RuleBlockSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

	RuleBuilder rb;
	public int childIndex;

	public delegate void SlotFilledHandler(INode child);
	public event SlotFilledHandler OnSlotFilled;

	void Awake()
	{
		rb = GameObject.FindGameObjectWithTag("RuleBuilder").GetComponent<RuleBuilder>();
	}
	
	public void OnPointerEnter(PointerEventData data)
	{
		rb.AddPointerOver(gameObject);
	}

	public void OnPointerExit(PointerEventData data)
	{
		rb.RemovePointerOver(gameObject);
	}

	public void SetChildInParent(INode child)
	{
		if(OnSlotFilled != null)
			OnSlotFilled(child);
	}

}

