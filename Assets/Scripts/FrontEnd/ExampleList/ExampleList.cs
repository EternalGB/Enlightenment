using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExampleList : MonoBehaviour
{

	public GameController gc;
	public RectTransform examplesContainer;
    public ScrollRect scrollRect;
	public Scrollbar scrollBar;
	public FollowsDisplay followsDisplay;
	public GameObject examplePrefab;
	public List<DisplayExample> exampleDisplays;
    ScreenController sc;
    bool listDirty = false;

	void Start()
	{
        sc = GetComponent<ScreenController>();
        sc.OnOpenComplete += sc_OnOpenComplete;
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
		//newExample.transform.SetParent(examplesContainer);
        //de.SetSize(scrollRect.rect);
		exampleDisplays.Add(de);
        listDirty = true;
        Debug.Log("Adding example to list");
	}

    void sc_OnOpenComplete()
    {
        Debug.Log("Doing open complete. Dirty list ? " + listDirty);
        if(listDirty)
        {
            int start = scrollBar.numberOfSteps;
            for(int i = start; i < exampleDisplays.Count; i++)
            {
                DisplayExample de = exampleDisplays[i];
                de.GetComponent<RectTransform>().SetParent(examplesContainer);
                de.SetSize(scrollRect.GetComponent<RectTransform>().rect);
            }

            scrollBar.numberOfSteps = exampleDisplays.Count;
            scrollRect.horizontalNormalizedPosition = 1f;
            scrollBar.onValueChanged.Invoke(scrollBar.value);

            listDirty = false;
        }
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
        scrollBar.numberOfSteps = 0;
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

