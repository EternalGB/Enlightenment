using System;

public class ExistsOneHas : Atom
{
	
	IPropertyChecker propertyCheck;
	IPropertyChecker filter;
	
	
	public ExistsOneHas (IPropertyChecker propertyCheck)
	{
		this.propertyCheck = propertyCheck;
		this.filter = new PropertyCheckers.Identity();
	}

	public ExistsOneHas(IPropertyChecker propertyCheck, IPropertyChecker filter)
	{
		this.propertyCheck = propertyCheck;
		this.filter = filter;
	}
	
	public override bool Evaluate (Board board)
	{
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceHas(x,y,filter.Check) && board.PieceHas(x,y,propertyCheck.Check)) {
					return true;
				}
			}
		}
		return false;
	}

	public override INode DeepClone()
	{
		return new ExistsOneHas(propertyCheck, filter);
	}

	public override Atom Negate()
	{
		return new AllHave(new PropertyCheckers.Not(this.propertyCheck), this.filter);
	}

	public override string ToString ()
	{
		return string.Format ("ExistsOneHas [{0}]", propertyCheck.ToString());
	}

	public void SetPropertyCheck(IPropertyChecker check)
	{
		this.propertyCheck = check;
	}
	
	public void SetFilter(IPropertyChecker check)
	{
		this.filter = check;
	}

}



