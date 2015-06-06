using UnityEngine;
using System.Collections;


public class DieTest : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

		Board board = new Board(3,3);
		board.SetPiece(0,0, Piece.DiePiece("One","White"));
		board.SetPiece(0,1, Piece.DiePiece("Two","White"));
		board.SetPiece(0,2, Piece.DiePiece("Three", "Black"));

		Rule rule1 = new Rule(new AllHave(PropertyCheckers.PropertyHasValue("Face","One")));
		Rule rule2 = new Rule(new ExistsOneHas(PropertyCheckers.PropertyHasValue("Face","One")));
		Rule rule3 = new Rule(new NoneHave(PropertyCheckers.PropertyHasValue("Colour","Blue")));
		Rule rule4 = new Rule(new FaceSum(Comparers<int>.LessThan, 7));
		Rule rule5 = new Rule(new PropertyCount(PropertyCheckers.PropertyHasValue("Face","One"), Comparers<int>.Equal, 1));

		System.Diagnostics.Debug.Assert(rule1.Evaluate(board) == false);
		System.Diagnostics.Debug.Assert(rule2.Evaluate(board) == true);
		System.Diagnostics.Debug.Assert(rule3.Evaluate(board) == true);
		System.Diagnostics.Debug.Assert(rule4.Evaluate(board) == true);
		System.Diagnostics.Debug.Assert(rule5.Evaluate(board) == true);

	}

}

