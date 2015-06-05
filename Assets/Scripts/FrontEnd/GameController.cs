using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

	public Piece heldPiece;
	public int numPieces;
	public TextAsset dictJson;
	PieceInfo pieceInfo;
	public int width, height;
	public List<Image> boardPositions;
	Board board;
	int cursorX, cursorY;

	public List<RectTransform> verticalPieceGroups;

	void Start()
	{
		board = new Board(width, height);
		pieceInfo = new PieceInfo(dictJson.text);
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
		if(piece == null)
			return pieceInfo.blankImage;
		else
			return pieceInfo.imageDict[piece];
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
		SetPiece(x,y, pieceInfo.CyclePiece(GetPiece(x,y)));
	}
}

