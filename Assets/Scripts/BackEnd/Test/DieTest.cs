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
		Rule<DiePiece> rule2 = new Rule<DiePiece>(new ExistsOneHas<DiePiece>(DiePiecePropertyCheckers.IsBlack));
		Rule<DiePiece> rule3 = new Rule<DiePiece>(new NoneHave<DiePiece>(DiePiecePropertyCheckers.IsBlack));
		Rule<DiePiece> rule4 = new Rule<DiePiece>(new PropertyCount<DiePiece>(DiePiecePropertyCheckers.IsOne, Comparers<int>.Equal, 3));
		Rule<DiePiece> rule5 = new Rule<DiePiece>(new PropertyCount<DiePiece>(DiePiecePropertyCheckers.IsOne, Comparers<int>.LessThan, 3));
		Rule<DiePiece> rule6 = new Rule<DiePiece>(new FaceSum(Comparers<int>.GreaterThanOrEqualTo,6));

		Debug.Log (rule1.Evaluate(board) == true);
		Debug.Log (rule2.Evaluate(board) == false);
		Debug.Log (rule3.Evaluate(board) == true);
		Debug.Log (rule4.Evaluate(board) == false);
		Debug.Log (rule5.Evaluate(board) == true);
		Debug.Log (rule6.Evaluate(board) == true);
	}

}

