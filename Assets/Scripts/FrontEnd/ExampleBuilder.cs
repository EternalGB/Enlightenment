using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ExampleBuilder : MonoBehaviour
{


	public Piece heldPiece;
	public int numPieces;
	public GameController gc;
	public int width, height;
	public List<Image> boardPositions;
	Board board;
	int cursorX, cursorY;

	Rule rule;

	public List<RectTransform> verticalPieceGroups;

	void Start()
	{
		board = new Board(width, height);

		rule = new Rule(new AllHave(new PropertyCheckers.DiePiece.FaceValue(new Comparers<int>.GreaterThan(),2)));
	}

	void RedrawBoard()
	{
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				boardPositions[x + y*board.Width].sprite = GetPieceImage(board.GetPiece(x,y));
			}
		}
	}

	public Sprite GetPieceImage(Piece piece)
	{
		return gc.GetPieceImage(piece);
	}

	public bool PieceExistsAt(int x, int y)
	{
		return board.PieceExistsAt(x,y);
	}

	public void SetPieceAtCursor(Piece piece)
	{
		if(board.IsValidSpace(cursorX,cursorY))
			SetPiece(cursorX,cursorY,piece);
	}

	public void SetPiece(int x, int y, Piece piece)
	{
		board.SetPiece(x,y, piece);
		RedrawBoard();
	}

	public Piece GetPiece(int x, int y)
	{
		return board.GetPiece(x,y);
	}

	public void SetCursorPosition(int x, int y)
	{
		cursorX = x;
		cursorY = y;
	}

	public bool HasHeldPiece()
	{
		return !(heldPiece == null);
	}

	public void CyclePieceAt(int x, int y)
	{
		SetPiece(x,y, gc.CyclePiece(GetPiece(x,y)));
	}

	public bool EvaluateBoard()
	{
		return rule.Evaluate(board);
	}

	public void TestBoard()
	{
		Debug.Log(EvaluateBoard());
	}
}

