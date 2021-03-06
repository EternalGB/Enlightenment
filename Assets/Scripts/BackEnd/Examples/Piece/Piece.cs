﻿using UnityEngine;
using System.Collections.Generic;
using LitJson;

[System.Serializable]
public class Piece
{

	[SerializeField]
	private List<PropertyValuePair> properties;

	public static readonly Piece Empty = new Piece();

	public Piece()
	{
		properties = new List<PropertyValuePair>();
	}

	public Piece(Piece old)
	{
		properties = new List<PropertyValuePair>();
		foreach(PropertyValuePair pair in old.properties) {
			properties.Add(new PropertyValuePair(pair.property, pair.value));
		}
	}

	public List<PropertyValuePair>.Enumerator GetProperties()
	{
		return properties.GetEnumerator();
	}

	public bool HasProperty(string property)
	{
		foreach(PropertyValuePair pair in properties) {
			if(pair.property.Equals(property))
				return true;
		}
		return false;
	}

	public string GetPropertyValue(string property)
	{
		foreach(PropertyValuePair pair in properties) {
			if(pair.property.Equals(property))
				return pair.value;
		}
		return null;
	}

	public void SetPropertyValue(string property, string value)
	{
		for(int i = 0; i < properties.Count; i++) {
			if(properties[i].property.Equals(property))
				properties[i] = new PropertyValuePair(property, value);
		}
	}

	public void AddProperty(string name, string value)
	{
		properties.Add(new PropertyValuePair(name, value));
	}

	public override string ToString ()
	{
		string output = "Piece \n";
		foreach(PropertyValuePair pair in properties) {
			output += "\t" + pair.ToString() + "\n";
		}
		return output;
	}

	public override bool Equals (object obj)
	{
		Piece other = obj as Piece;
		if(other == null)
			return false;
		//Debug.Log(string.Format("Checkings equals: {0} and {1}",this,other));
		if(other.properties.Count != this.properties.Count)
			return false;
		foreach(PropertyValuePair pair in this.properties) {
			if(!other.HasProperty(pair.property))
				return false;
			if(!other.GetPropertyValue(pair.property).Equals (this.GetPropertyValue(pair.property)))
				return false;
		}
		return true;
	}

	public override int GetHashCode ()
	{
		//ensures that you get the same hash if the properties are in a different order
		//may cause collisions though?
		int hash = 0;
		foreach(PropertyValuePair pair in properties) {
			//Debug.Log ("Generating hash for " + pair.ToString());
			hash += pair.GetHashCode();
		}
		return hash;
	}

	public static Piece FromJson(JsonData properties)
	{
		Piece piece = new Piece();
		foreach(string property in properties.Keys) {
			piece.AddProperty(property, (string)properties[property]);
		}
		return piece;
	}

	public static Piece DiePiece(string face, string colour)
	{
		Piece piece = new Piece();
		piece.AddProperty("Face", face);
		piece.AddProperty("Colour", colour);
		return piece;
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
			if(!obj.GetType().IsAssignableFrom(typeof(PropertyValuePair)))
				return false;
			PropertyValuePair other = (PropertyValuePair)obj;
			if(property == null || value == null || other.property == null || other.value == null)
				return false;
			return property.Equals(other.property) && value.Equals(other.value);
		}

		public override int GetHashCode ()
		{
			if(property == null || value == null)
				return 0;
			int hash = 17;
			hash = hash*23 + property.GetHashCode();
			hash = hash*23 + value.GetHashCode();
			return hash;
		}

		public override string ToString ()
		{
			return string.Format ("{0} : {1}", property, value);
		}
	}


}
