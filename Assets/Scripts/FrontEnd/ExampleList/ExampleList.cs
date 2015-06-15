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

}

