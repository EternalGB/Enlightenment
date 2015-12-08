using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayExample : MonoBehaviour
{

	public List<Image> boardPositions;
	Board board;
	bool evaluation;
    LayoutElement layout;

    void OnEnable()
    {
        layout = GetComponent<LayoutElement>();
    }

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

    public void SetSize(Rect parentRect)
    {
        layout.preferredWidth = parentRect.width;
        layout.preferredHeight = parentRect.height;
        Debug.Log("Setting example size to " + parentRect.width + ", " + parentRect.height);
    }

	public bool GetEvaluation()
	{
		return evaluation;
	}

	public bool BoardEquals(Board board)
	{
		return this.board.Equals(board);
	}

	public Board GetBoard()
	{
		return new Board(board);
	}


}

