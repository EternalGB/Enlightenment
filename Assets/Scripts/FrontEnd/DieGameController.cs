using UnityEngine;
using System.Collections.Generic;

public class DieGameController : GameController<DiePiece>
{


	Dictionary<DiePiece,Sprite> imageDict;

	public override void Init ()
	{
		imageDict = new Dictionary<DiePiece, Sprite>();
		for(int i = 0; i < pieces.Count; i++)
			imageDict.Add(pieces[i],images[i]);
	}

	public override Sprite GetPieceImage(DiePiece piece)
	{
		return imageDict[piece];
	}

}

