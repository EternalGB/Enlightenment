using UnityEngine;
using System.Collections.Generic;
using LitJson;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Puzzle 
{

	public string puzzleName;
	public Rule rule;
	public Board example1, example2;
	public List<Board> testedExamples;
	public bool completed;

	static string dir = Application.persistentDataPath + Path.DirectorySeparatorChar + "Tested";
	static string pathPrefix = dir + Path.DirectorySeparatorChar;

	public void SaveProgress()
	{

		string fileName = pathPrefix + puzzleName;
		Debug.Log (string.Format("Saving {0} progress to {1}",puzzleName,fileName));
		if(File.Exists(fileName))
			File.Delete(fileName);
		if(!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		Stream fileStream = File.Create(fileName);
		BinaryFormatter serializer = new BinaryFormatter();
		serializer.Serialize(fileStream, new PuzzleProgress(testedExamples, completed));
		fileStream.Close();
	}

	public void LoadProgress()
	{
		PuzzleProgress progress;
		try {
			string fileName = pathPrefix + puzzleName;
			Stream fileStream = File.Open(fileName, FileMode.Open);
			Debug.Log (string.Format("Loading {0} progress from {1}",puzzleName,fileName));
			BinaryFormatter serializer = new BinaryFormatter();
			progress = (PuzzleProgress)serializer.Deserialize(fileStream);
			fileStream.Close();
		} catch {
			progress = new PuzzleProgress();
			progress.completed = false;
			progress.testedExamples = new List<Board>();
			//do nothing
		}
		completed = progress.completed;
		testedExamples = progress.testedExamples;
	}

	public void AddTestedExample(Board board)
	{
		if(testedExamples == null)
			testedExamples = new List<Board>();
		testedExamples.Add(board);
	}

	[System.Serializable]
	public struct PuzzleProgress
	{

		public List<Board> testedExamples;
		public bool completed;

		public PuzzleProgress(List<Board> testedExamples, bool completed)
		{
			this.testedExamples = testedExamples;
			this.completed = completed;
		}

	}



}

