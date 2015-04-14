using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class GameController<T> : MonoBehaviour where T : IPiece
{

	public T heldPiece;
	public int numPieces;
	public List<T> pieces;
	public List<Sprite> images;
	public int width, height;
	public List<Image> boardPositions;
	Board<T> board;
	int cursorX, cursorY;

	public abstract Sprite GetPieceImage(T piece);

	public abstract void Init();

	void Start()
	{
		board = new Board<T>(width, height);
		Init();
	}

	void RedrawBoard()
	{
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				boardPositions[x + y*board.Width].sprite = GetPieceImage(board.GetPiece(x,y));
			}
		}
	}

	public bool PieceExistsAt(int x, int y)
	{
		return board.PieceExistsAt(x,y);
	}

	public void SetPieceAtCursor(T piece)
	{
		if(board.IsValidSpace(cursorX,cursorY))
			SetPiece(cursorX,cursorY,piece);
	}

	public void SetPiece(int x, int y, T piece)
	{
		board.SetPiece(x,y, piece);
		RedrawBoard();
	}

	public T GetPiece(int x, int y)
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
		return !heldPiece.Equals(default(T));
	}
}

