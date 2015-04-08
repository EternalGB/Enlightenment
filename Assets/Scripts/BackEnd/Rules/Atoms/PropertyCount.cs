using System;

public class PropertyCount<T> : INode<T> where T : IPiece
{

	Func<T, bool> propertyCheck;
	Func<int, int, bool> countComparator;
	int amount;

	public PropertyCount (Func<T, bool> propertyCheck, Func<int, int, bool> countComparator, int amount)
	{
		this.propertyCheck = propertyCheck;
		this.countComparator = countComparator;
		this.amount = amount;
	}

	public bool Evaluate (Board<T> board)
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
