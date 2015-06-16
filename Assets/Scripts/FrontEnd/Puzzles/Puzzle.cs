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
	//public List<Board> testedExamples;
	public bool solved;

	static string dir = Application.persistentDataPath + Path.DirectorySeparatorChar + "Tested";
	static string pathPrefix = dir + Path.DirectorySeparatorChar;

	public void SaveProgress(List<Board> testedExamples)
	{

		string fileName = pathPrefix + puzzleName;
		Debug.Log (string.Format("Saving {0} progress to {1}",puzzleName,fileName));
		if(File.Exists(fileName))
			File.Delete(fileName);
		if(!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		Stream fileStream = File.Create(fileName);
		BinaryFormatter serializer = new BinaryFormatter();
		serializer.Serialize(fileStream, testedExamples);
		fileStream.Close();
	}

	public List<Board> LoadProgress()
	{
		List<Board> testedExamples;
		try {
			string fileName = pathPrefix + puzzleName;
			Stream fileStream = File.Open(fileName, FileMode.Open);
			Debug.Log (string.Format("Loading {0} progress from {1}",puzzleName,fileName));
			BinaryFormatter serializer = new BinaryFormatter();
			testedExamples = (List<Board>)serializer.Deserialize(fileStream);
			fileStream.Close();
		} catch {
			testedExamples = new List<Board>();
			//do nothing
		}
		return testedExamples;
	}




}

