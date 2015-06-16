using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using LitJson;
using UnityEngine.Events;

public class PuzzleList : MonoBehaviour
{

	public GameController gc;
	public ExampleList el;
	public ScreenSelectionController ssc;
	public TextAsset jsonFile;
	public RectTransform puzzleArea;
	public GameObject puzzleButtonPrefab;

	List<Puzzle> puzzles;
	Puzzle currentPuzzle = null;

	void OnEnable()
	{
		ClearPuzzleArea();
		LoadFromJson(jsonFile.text);
		foreach(Puzzle puzzle in puzzles) {

			GameObject button = (GameObject)Instantiate(puzzleButtonPrefab);
			button.transform.SetParent(puzzleArea);
			button.GetComponentInChildren<Text>().text = puzzle.puzzleName;
			button.GetComponent<Button>().onClick.AddListener(StartPuzzle(puzzle));
		}
	}


	public UnityAction StartPuzzle(Puzzle puzzle)
	{
		Puzzle puzzleRefCopy = puzzle;
		return () =>
		{
			if(currentPuzzle != null)
				currentPuzzle.SaveProgress(el.GetExamples());


			el.ClearExampleList();

			gc.SetRule(puzzleRefCopy.rule);
			List<Board> testedExamples = puzzleRefCopy.LoadProgress();
			foreach(Board board in testedExamples) {
				el.AddExample(board);
			}
			if(!el.ContainsExample(puzzleRefCopy.example1))
				el.AddExample(puzzleRefCopy.example1);
			if(!el.ContainsExample(puzzleRefCopy.example2))
				el.AddExample(puzzleRefCopy.example2);
			ssc.SwapTo(el.GetComponent<Animator>());

			currentPuzzle = puzzleRefCopy;
		};
	}

	public void ClearPuzzleArea()
	{
		
		Transform[] children = puzzleArea.GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.GetInstanceID() != puzzleArea.GetInstanceID())
				Destroy(child.gameObject);
		}
	}

	public void LoadFromJson(string json)
	{
		JsonData data = JsonMapper.ToObject(json);
		puzzles = new List<Puzzle>();
		JsonData puzzleList = data["Puzzles"];
		for(int i = 0; i < puzzleList.Count; i++) {
			JsonData puzzleJson = puzzleList[i];
			Puzzle puzzle = new Puzzle();
			puzzle.puzzleName = (string)puzzleJson["Name"];
			Debug.Log (string.Format("Loading {0} from json", puzzle.puzzleName));
			puzzle.rule = RuleDict.rules[(string)puzzleJson["RuleKey"]];
			puzzle.example1 = Board.FromJson(puzzleJson["Example1"]);
			puzzle.example2 = Board.FromJson(puzzleJson["Example2"]);
			//puzzle.LoadProgress();
			puzzles.Add(puzzle);
		}
	}


}

