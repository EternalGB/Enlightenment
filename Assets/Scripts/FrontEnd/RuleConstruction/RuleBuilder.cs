using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class RuleBuilder : MonoBehaviour
{

	public GameObject heldBlockPrefab;
	public RectTransform contentArea;
	[SerializeField]
	List<GameObject> pointerOver;

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
			if(objOver.CompareTag("RuleConstructionArea")) {
				GameObject newBlock = (GameObject)Instantiate(heldBlockPrefab, objOver.transform.position, Quaternion.identity);
				newBlock.transform.SetParent(contentArea);
			}
		}
	}

	public void AddPointerOver(GameObject obj)
	{
		pointerOver.Insert(0,obj);
	}

	public void RemovePointerOver(GameObject obj)
	{
		pointerOver.Remove(obj);
	}
}

