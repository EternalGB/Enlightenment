using System;

public class ExistsOneHas<T> : INode<T> where T : IPiece
{
	
	Func<T, bool> propertyCheck;
	
	
	public ExistsOneHas (Func<T, bool> propertyCheck)
	{
		this.propertyCheck = propertyCheck;
	}
	
	public bool Evaluate (Board<T> board)
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



