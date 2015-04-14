using UnityEngine;
using System.Collections;

public class DiePieceCreator : PieceCreator<DiePiece>
{

	void Start()
	{
		gc = GameObject.FindWithTag("GameController").GetComponent<DieGameController>();
	}


}

