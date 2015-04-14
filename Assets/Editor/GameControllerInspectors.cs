using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(DieGameController))]
public class DieGameControllerInspector : Editor 
{

	public bool showAdvanced = false;

	public override void OnInspectorGUI()
	{
		DieGameController cont = (DieGameController)target;
		showAdvanced = EditorGUILayout.Foldout(showAdvanced, "Piece Assignment");
		if(showAdvanced) {
			EditorGUILayout.BeginVertical();
			EditorGUI.BeginChangeCheck();
			bool returnPressed = Event.current.isKey && Event.current.keyCode == KeyCode.Return;
			cont.numPieces = EditorGUILayout.IntField("Num Pieces",cont.numPieces);
			if(returnPressed) {
				//Debug.Log ("Change occurred, remaking lists to size " + cont.numPieces);
				List<DiePiece> pieces = new List<DiePiece>(cont.pieces);
				List<Sprite> images = new List<Sprite>(cont.images);
				cont.pieces = new List<DiePiece>(cont.numPieces);
				cont.images = new List<Sprite>(cont.numPieces);
				for(int i = 0; i < cont.numPieces; i++) {
					if(i < pieces.Count)
						cont.pieces.Add(pieces[i]);
					else
						cont.pieces.Add(default(DiePiece));
					if(i < images.Count)
						cont.images.Add(images[i]);
					else
						cont.images.Add(null);
				}
			}
			
			
			for(int i = 0; i < Mathf.Min(cont.pieces.Count, cont.images.Count); i++) {
				EditorGUILayout.BeginHorizontal();
				//EditorGUILayout.LabelField(i.ToString());
				DiePiece.Colour colour = (DiePiece.Colour)EditorGUILayout.EnumPopup(cont.pieces[i].colour);
				DiePiece.Face face = (DiePiece.Face)EditorGUILayout.EnumPopup(cont.pieces[i].face);
				cont.pieces[i] = new DiePiece(face, colour);
				cont.images[i] = (Sprite)EditorGUILayout.ObjectField(cont.images[i], typeof(Sprite), false);
				EditorGUILayout.EndHorizontal();
			}
			
			if(GUILayout.Button("Generate Piece List")) {
				cont.pieces = new List<DiePiece>();
				cont.images = new List<Sprite>();
				int count = 0;
				foreach(DiePiece.Colour colour in Enum.GetValues(typeof(DiePiece.Colour))) {
					foreach(DiePiece.Face face in Enum.GetValues (typeof(DiePiece.Face))) {
						cont.pieces.Add(new DiePiece(face,colour));
						cont.images.Add(null);
						count++;
					}
				}
				cont.numPieces = count;
			}
			
			EditorGUILayout.EndVertical();
		}

		DrawDefaultInspector();

	}

}
