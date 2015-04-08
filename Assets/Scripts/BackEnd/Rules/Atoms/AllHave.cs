using System;
using UnityEngine;

public class AllHave<T> : INode<T> where T : IPiece
{
	
	Func<T, bool> propertyCheck;

	
	public AllHave (Func<T, bool> propertyCheck)
	{
		this.propertyCheck = propertyCheck;
	}
	
	public bool Evaluate (Board<T> board)
	{
		bool result = true;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y)) {
					result = result && board.PieceHas(x,y,propertyCheck);
					if(!board.PieceHas(x,y,propertyCheck))
						Debug.Log ("Piece at " + x + ", " + y + " does not have property " + propertyCheck.Method.Name);
				}
			}
		}
		return result;
	}
	
}

