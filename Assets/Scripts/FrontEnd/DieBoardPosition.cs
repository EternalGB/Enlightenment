using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class DieBoardPosition : BoardPosition<DiePiece>
{

	void Start()
	{
		gc = GameObject.FindWithTag("GameController").GetComponent<DieGameController>();
	}

	public override DiePiece CyclePiece (DiePiece piece)
	{
		DiePiece.Face newFace = piece.face;
		Array faces = Enum.GetValues (typeof(DiePiece.Face));
		for(int i = 0; i < faces.Length; i++) {
			if(faces.GetValue(i).Equals(piece.face)) {
				do {
					i++;
					newFace = (DiePiece.Face)faces.GetValue((i)%faces.Length);
				} while(newFace.Equals(DiePiece.Face.None));

			}
				
		}
		return new DiePiece(newFace,piece.colour);
	}
	
}

