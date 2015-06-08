using System;

public class ExistsOneHas : INode
{
	
	Func<Piece, bool> propertyCheck;
	Func<Piece, bool> filter;
	
	
	public ExistsOneHas (Func<Piece, bool> propertyCheck)
	{
		this.propertyCheck = propertyCheck;
		this.filter = delegate(Piece p) { return true;};
	}

	public ExistsOneHas(Func<Piece, bool> propertyCheck, Func<Piece, bool> filter)
	{
		this.propertyCheck = propertyCheck;
		this.filter = filter;
	}
	
	public bool Evaluate (Board board)
	{
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,filter) && board.PieceHas(x,y,propertyCheck)) {
					return true;
				}
			}
		}
		return false;
	}
	
}



