using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayExample : MonoBehaviour
{

	public List<Image> boardPositions;
	Board board;
	bool evaluation;

	public void SetDisplay(GameController gc, Board board)
	{
		this.board = new Board(board);
		evaluation = gc.EvaluateExample(this.board);
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				boardPositions[x + y*board.Width].sprite = gc.GetPieceImage(board.GetPiece(x,y));
			}
		}
	}

	public bool GetEvaluation()
	{
		return evaluation;
	}


}

