using System;

public class HasColourCount : INode<DiePiece>
{

	DiePiece.Colour colour;
	int amount;
	Func<int, int, bool> comparison;

	public HasColourCount(DiePiece.Colour colour, int amount, Func<int, int, bool> comparison)
	{
		this.colour = colour;
		this.amount = amount;
		this.comparison = comparison;
	}

	public bool Evaluate (Board<DiePiece> board)
	{
		int count = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,ColourCheck))
					count++;
			}
		}
		return comparison(count, amount);
	}

	public bool ColourCheck(DiePiece piece)
	{
		return piece.colour == colour;
	}

}

public class HasFaceCount : INode<DiePiece>
{
	
	DiePiece.Face face;
	int amount;
	Func<int, int, bool> comparison;
	
	public HasFaceCount(DiePiece.Face face, int amount, Func<int, int, bool> comparison)
	{
		this.face = face;
		this.amount = amount;
		this.comparison = comparison;
	}
	
	public bool Evaluate (Board<DiePiece> board)
	{
		int count = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,FaceCheck))
					count++;
			}
		}
		return comparison(count, amount);
	}
	
	public bool FaceCheck(DiePiece piece)
	{
		return piece.face == face;
	}

}
