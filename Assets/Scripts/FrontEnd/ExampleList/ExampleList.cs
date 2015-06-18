using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExampleList : MonoBehaviour
{

	public GameController gc;
	public RectTransform examplesContainer;
	public Scrollbar scrollBar;
	public FollowsDisplay followsDisplay;
	public GameObject examplePrefab;
	public List<DisplayExample> exampleDisplays;

	void Start()
	{
		scrollBar.onValueChanged.AddListener(UpdateFollows);
	}

	public bool ContainsExample(Board board)
	{
		foreach(DisplayExample example in exampleDisplays) {
			if(example.BoardEquals(board))
				return true;
		}
		return false;
	}

	public void AddExample(Board board)
	{
		GameObject newExample = (GameObject)Instantiate(examplePrefab);
		DisplayExample de = newExample.GetComponent<DisplayExample>();
		de.SetDisplay(gc, board);
		newExample.transform.SetParent(examplesContainer);
		exampleDisplays.Add(de);

		scrollBar.numberOfSteps = exampleDisplays.Count;
		scrollBar.value = 1;
		scrollBar.onValueChanged.Invoke(scrollBar.value);

	}

	public void UpdateFollows(float value)
	{
		//float partition = 1/exampleDisplays.Count;
		int index = Mathf.FloorToInt(value*exampleDisplays.Count);
		if(index >= exampleDisplays.Count)
			index = exampleDisplays.Count-1;
		followsDisplay.SetFollows(exampleDisplays[index].GetEvaluation());
	}

	public void ClearExampleList()
	{
		
		Transform[] children = examplesContainer.GetComponentsInChildren<Transform>(true);
		foreach(Transform child in children) {
			if(child.GetInstanceID() != examplesContainer.GetInstanceID())
				Destroy(child.gameObject);
		}
		exampleDisplays = new List<DisplayExample>();
	}

	public List<Board> GetExamples()
	{
		List<Board> examples = new List<Board>();
		foreach(DisplayExample de in exampleDisplays) {
			examples.Add(de.GetBoard());
		}
		return examples;
	}

}

