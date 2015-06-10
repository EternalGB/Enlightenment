using System;
using UnityEngine;

public class AllHave : Atom
{

	IPropertyChecker filter;
	IPropertyChecker propertyCheck;

	
	public AllHave (IPropertyChecker propertyCheck)
	{
		this.propertyCheck = propertyCheck;
		this.filter = new PropertyCheckers.Identity();
	}

	public AllHave(IPropertyChecker propertyCheck, IPropertyChecker filter)
	{
		this.propertyCheck = propertyCheck;
		this.filter = filter;
	}
	
	public override bool Evaluate (Board board)
	{
		bool result = true;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y) && board.PieceHas(x,y,filter.Check)) {
					result = result && board.PieceHas(x,y,propertyCheck.Check);
				}
			}
		}
		return result;
	}

	public override Atom Negate()
	{
		return new ExistsOneHas(new PropertyCheckers.Not(propertyCheck), this.filter);
	}

	public override string ToString ()
	{
		return string.Format ("AllHave [{0}]", propertyCheck.ToString());
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

