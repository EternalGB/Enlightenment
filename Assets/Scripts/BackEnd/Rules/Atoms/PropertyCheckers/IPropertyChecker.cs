using System;

public interface IPropertyChecker
{
	bool Check(Piece p);

	IPropertyChecker GetNegation();
}
