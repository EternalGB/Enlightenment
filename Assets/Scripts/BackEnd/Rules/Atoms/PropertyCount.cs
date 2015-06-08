using System;

public class PropertyCount : Atom
{

	IPropertyChecker propertyCheck;
	IComparer<int> countComparator;
	int amount;

	public PropertyCount (IPropertyChecker propertyCheck, IComparer<int> countComparator, int amount)
	{
		this.propertyCheck = propertyCheck;
		this.countComparator = countComparator;
		this.amount = amount;
	}

	public override bool Evaluate (Board board)
	{
		int count = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,propertyCheck.Check))
					count++;
			}
		}
		return countComparator.Compare(count, amount);
	}

	public override Atom Negate()
	{
		return new PropertyCount(this.propertyCheck, countComparator.GetNegation(), amount);
	}

	public override string ToString ()
	{
		return string.Format ("PropertyCount [{0} {1} {2}]", propertyCheck.ToString(), countComparator.ToString(), amount);
	}

}
