using System;

public class NoneHave : INode
{
	
	Func<Piece, bool> propertyCheck;
	
	
	public NoneHave (Func<Piece, bool> propertyCheck)
	{
		this.propertyCheck = propertyCheck;
	}
	
	public bool Evaluate (Board board)
	{
		bool result = true;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y)) {
					result = result && !board.PieceHas(x,y,propertyCheck);
				}
			}
		}
		return result;
	}
	
}


