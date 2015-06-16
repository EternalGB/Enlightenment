using UnityEngine;
using System.Collections;
using System;
using LitJson;

[System.Serializable]
public class Board
{

	[SerializeField]
	protected int width, height;
	[SerializeField]
	protected Piece[,] pieces;

	public int Width { get{ return width;}}
	public int Height { get {return height;}}

	public Board(int width, int height)
	{
		this.width = width;
		this.height = height;
		pieces = new Piece[width,height];
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				pieces[x,y] = null;
			}
		}
	}

	public Board(Board old)
	{
		width = old.width;
		height = old.height;
		pieces = new Piece[width, height];
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				pieces[x,y] = old.pieces[x,y] == null ? null : new Piece(old.pieces[x,y]);
			}
		}
	}

	public Piece GetPiece(int x, int y)
	{
		return pieces[x,y];
	}

	public void SetPiece(int x, int y, Piece newPiece)
	{
		pieces[x,y] = newPiece;
	}

	public bool IsValidSpace(int x, int y)
	{
		return x >= 0 && x < width && y >= 0 && y < height;
	}

	public bool IsEmpty(int x, int y)
	{
		return pieces[x,y] == null;
	}

	public bool IsAdjacent(int x1, int y1, int x2, int y2)
	{
		return IsValidSpace(x1,y1) && IsValidSpace(x2,y2)
			&& Mathf.Abs(x1 - x2) <= 1 && Mathf.Abs (y1 - y2) <= 0;
	}

	public bool PieceExistsAt(int x, int y)
	{
		return IsValidSpace(x,y) && !IsEmpty(x,y);
	}

	public int Distance(int x1, int y1, int x2, int y2)
	{
		return Mathf.Abs (x1 - x2) + Mathf.Abs(y1 - y2);
	}

	public bool PieceHas(int x, int y, Func<Piece, bool> propertyEvaluator)
	{
		return PieceExistsAt(x,y) && propertyEvaluator(pieces[x,y]);
	}

	public int NumPiecesWith(Func<Piece, bool> propertyEvaluator)
	{
		int count = 0;
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				if(PieceHas(x,y, propertyEvaluator))
					count++;
			}
		}
		return count;
	}

	public override bool Equals (object obj)
	{
		Board other = obj as Board;
		if(other == null)
			return false;
		if(other.width != width || other.height != height)
			return false;
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				if(pieces[x,y] == null) {
					if(other.pieces[x,y] != null)
						return false;
				} else if(!pieces[x,y].Equals(other.pieces[x,y]))
					return false;
			}
		}
		return true;
	}

	public override int GetHashCode ()
	{
		//TODO re-examine
		int hash = 0;
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				if(pieces[x,y] != null) 
					hash += pieces[x,y].GetHashCode();
			}
		}
		return hash;
	}

	public override string ToString ()
	{
		string output = "";
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				output += string.Format(" ({0}) ", GetPiece(x,y));
			}
		}
		return output;
	}

	public static Board FromJson(JsonData pieces)
	{
		//TODO hard coded board stuff here
		Board board = new Board(3,3);
		for(int i = 0; i < pieces.Count; i++) {
			JsonData pieceJson = pieces[i];
			int x = (int)pieceJson["x"];
			int y = (int)pieceJson["y"];
			board.SetPiece(x,y,Piece.FromJson(pieceJson["Properties"]));
		}
		return board;
	}

}
