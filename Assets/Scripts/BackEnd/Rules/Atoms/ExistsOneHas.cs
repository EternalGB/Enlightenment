using System;

public class ExistsOneHas : INode
{
	
	Func<Piece, bool> propertyCheck;
	
	
	public ExistsOneHas (Func<Piece, bool> propertyCheck)
	{
		this.propertyCheck = propertyCheck;
	}
	
	public bool Evaluate (Board board)
	{
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,propertyCheck)) {
					return true;
				}
			}
		}
		return false;
	}
	
}



