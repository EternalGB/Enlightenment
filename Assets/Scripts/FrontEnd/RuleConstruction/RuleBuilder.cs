using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class RuleBuilder : MonoBehaviour
{

	public GameController gc;
	public Animator puzzleSelect;
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

	public void ClearConstructionArea()
	{

		Transform[] children = contentArea.GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.GetInstanceID() != contentArea.GetInstanceID())
				Destroy(child.gameObject);
		}
		rule = null;
	}

	public void PrintRule()
	{
		Debug.Log (rule.ToString());
	}

	public void TestRule()
	{
		string message;

		bool result = gc.EvaluateRule(rule);
		ScreenSelectionController screenCont = GameObject.FindGameObjectWithTag("ScreenController").GetComponent<ScreenSelectionController>();
		if(result) {
			message = "Rule Correct! Good Job.";
			screenCont.DisplayMessage(message,SetPuzzleComplete(screenCont, gc));
		} else {
			message = "Rule Does Not Match. Try Again";
			screenCont.DisplayMessage(message,screenCont.HideMessage);
		}

	}

	UnityEngine.Events.UnityAction SetPuzzleComplete(ScreenSelectionController screenCont, GameController gc)
	{
		GameController gcc = gc;
		ScreenSelectionController ssc = screenCont;
		return () => 
		{
			gcc.SetPuzzleCompleted();
			ssc.HideMessage();
			ssc.SwapTo(puzzleSelect);
		};
	}

}

