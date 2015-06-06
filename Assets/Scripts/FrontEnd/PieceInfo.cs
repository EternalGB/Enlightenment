using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using LitJson;

public class PieceInfo 
{

	public Dictionary<Piece, Sprite> imageDict;
	public Dictionary<string, List<string>> properties;
	public string horizontalSortBy, verticalSortBy, cycleBy;
	public Sprite blankImage;

	public PieceInfo(string jsonText)
	{
		JsonData data = JsonMapper.ToObject(jsonText);
		imageDict = new Dictionary<Piece, Sprite>();
		properties = new Dictionary<string, List<string>>();
		horizontalSortBy = (string)data["Meta"]["HorizontalSortBy"];
		verticalSortBy = (string)data["Meta"]["VerticalSortBy"];
		cycleBy = (string)data["Meta"]["CycleBy"];
		JsonData props = data["Properties"];
		foreach(string property in props.Keys) {
			properties.Add(property, new List<string>());
			for(int i = 0; i < props[property].Count; i++) {
				properties[property].Add((string)props[property][i]);
			}
		}
		JsonData pieces = data["Pieces"];
		for(int i = 0; i < pieces.Count; i++) {
			Piece next = new Piece();
			foreach(string property in pieces[i]["Properties"].Keys) {
				next.AddProperty(property, (string)pieces[i]["Properties"][property]);
			}
			string imageName = (string)(pieces[i]["ImageName"]);
			int index = (int)pieces[i]["SpriteIndex"];
			//Debug.Log (string.Format("{0}\t adding {1}_{2}",next, imageName, index));
			imageDict.Add(next, Resources.LoadAll<Sprite>("PieceImages/" + imageName)[index]);
		}

		string blankImageName = (string)data["Meta"]["EmptyPieceImage"];
		blankImage = Resources.Load<Sprite>("PieceImages/" + blankImageName);
	}

	public Piece CyclePiece(Piece piece)
	{
		//clone a new piece
		piece = new Piece(piece);
		List<string> values = properties[cycleBy];
		string val = piece.GetPropertyValue(cycleBy);
		int index = values.FindIndex(x => x.Equals(val));
		index = (index+1)%values.Count;
		val = values[index];
		piece.SetPropertyValue(cycleBy, val);
		return piece;
	}

	/*
	public List<ImageDictEntry> dict;

	public Sprite GetImage(Piece piece)
	{
		foreach(ImageDictEntry entry in dict) {
			Dictionary<string, string>.Enumerator props = piece.GetProperties();
			do {
				KeyValuePair<string, string> piecePair = props.Current;
				foreach(PropertyValuePair dictPair in entry.properties) {
					if(piecePair.Key.Equals(dictPair.property) && piecePair.Value.Equals(dictPair.value))
						return entry.image;
				}
			} while(props.MoveNext());
		}
		return null;
	}

	[System.Serializable]
	public struct ImageDictEntry
	{

		public string name;
		public List<PropertyValuePair> properties;
		public Sprite image;

	}

	[System.Serializable]
	public struct PropertyValuePair
	{

		public string property, value;

		public PropertyValuePair(string property, string value)
		{
			this.property = property;
			this.value = value;
		}
		
		public override bool Equals (object obj)
		{
			if(obj.GetType().IsAssignableFrom(typeof(PropertyValuePair))) {
				PropertyValuePair other = (PropertyValuePair)obj;
				return other.property.Equals(property) && other.value.Equals(value);
			} else
				return false;
		}
		
		public override int GetHashCode ()
		{
			return property.GetHashCode()^value.GetHashCode();
		}
	}
	*/


}

