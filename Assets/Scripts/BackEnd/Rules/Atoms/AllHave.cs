using System;
using UnityEngine;

public class AllHave : INode
{

	Func<Piece, bool> filter;
	Func<Piece, bool> propertyCheck;

	
	public AllHave (Func<Piece, bool> propertyCheck)
	{
		this.propertyCheck = propertyCheck;
		this.filter = delegate(Piece p) {return true;};
	}

	public AllHave(Func<Piece, bool> propertyCheck,Func<Piece, bool> filter)
	{
		this.propertyCheck = propertyCheck;
		this.filter = filter;
	}
	
	public bool Evaluate (Board board)
	{
		bool result = true;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y) && board.PieceHas(x,y,filter)) {
					result = result && board.PieceHas(x,y,propertyCheck);
					if(!board.PieceHas(x,y,propertyCheck))
						Debug.Log ("Piece at " + x + ", " + y + " does not have property " + propertyCheck.Method.Name);
				}
			}
		}
		return result;
	}
	
}

