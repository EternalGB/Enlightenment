using UnityEngine;
using System.Collections;

public class DieTest : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
		Board<DiePiece> board = new Board<DiePiece>(3,3);
		board.SetPiece(0,0,new DiePiece(DiePiece.Face.One, DiePiece.Colour.White));
		board.SetPiece(1,0,new DiePiece(DiePiece.Face.Two, DiePiece.Colour.White));
		board.SetPiece(2,0,new DiePiece(DiePiece.Face.Three, DiePiece.Colour.White));

		Rule<DiePiece> rule1 = new Rule<DiePiece>(new AllHave<DiePiece>(DiePiecePropertyCheckers.IsWhite));

		Debug.Log (rule1.Evaluate(board));
	}

}

