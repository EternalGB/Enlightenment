using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class RuleBuilder : MonoBehaviour
{

	public GameController gc;
	public GameObject heldBlockPrefab;
	public RectTransform contentArea;
	[SerializeField]
	List<GameObject> pointerOver;

	Rule rule;

	void Start()
	{
		pointerOver = new List<GameObject>();
	}

	public bool HasHeldBlock()
	{
		return heldBlockPrefab != null;
	}

	public void CreateHeldBlockAtPointer()
	{
		if(pointerOver.Count > 0) {
			GameObject objOver = pointerOver[0];


			if(rule == null && objOver.CompareTag("RuleConstructionArea")) {
				GameObject newBlock = (GameObject)Instantiate(heldBlockPrefab, objOver.transform.position, Quaternion.identity);
				RuleBlock block = newBlock.GetComponent<RuleBlock>();


				newBlock.transform.SetParent(contentArea);

				rule = new Rule(block.GetNode());
			} else if(objOver.CompareTag("BlockSlot")) {
				GameObject newBlock = (GameObject)Instantiate(heldBlockPrefab, objOver.transform.position, Quaternion.identity);
				RuleBlock block = newBlock.GetComponent<RuleBlock>();

				RuleBlockSlot slot = objOver.GetComponent<RuleBlockSlot>();
				newBlock.transform.SetParent(objOver.transform.parent);
				slot.SetChildInParent(block.GetNode());

				//have to manually call this because disabling the object prevents the slot from removing itself
				RemovePointerOver(objOver);
				objOver.SetActive(false);
			}
		}
		//Debug.Log (rule.ToString());
	}
	
	public void AddPointerOver(GameObject obj)
	{
		pointerOver.Insert(0,obj);
	}

	public void RemovePointerOver(GameObject obj)
	{
		pointerOver.Remove(obj);
	}

	public GameObject GetPointerOver()
	{
		if(pointerOver.Count > 0)
			return pointerOver[0];
		else
			return null;
	}

	public void PrintRule()
	{
		Debug.Log (rule.ToString());
	}
}

