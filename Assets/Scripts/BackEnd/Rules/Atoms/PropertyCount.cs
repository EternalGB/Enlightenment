using System;

public class PropertyCount : INode
{

	Func<Piece, bool> propertyCheck;
	Func<int, int, bool> countComparator;
	int amount;

	public PropertyCount (Func<Piece, bool> propertyCheck, Func<int, int, bool> countComparator, int amount)
	{
		this.propertyCheck = propertyCheck;
		this.countComparator = countComparator;
		this.amount = amount;
	}

	public bool Evaluate (Board board)
	{
		int count = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,propertyCheck))
					count++;
			}
		}
		return countComparator(count, amount);
	}

}
