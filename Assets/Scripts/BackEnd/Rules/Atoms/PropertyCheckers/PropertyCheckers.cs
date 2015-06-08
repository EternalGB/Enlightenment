using System;

public static class PropertyCheckers
{

	public static Func<Piece, bool> Negate(Func<Piece, bool> func)
	{
		return delegate(Piece p) { return !func(p);};
	}

	public static Func<Piece, bool> PropertyHasValue(string property, string value)
	{
		return delegate(Piece p) {return p.GetPropertyValue(property) == value;};
	}

	public static class DiePiece
	{
		public static Func<Piece, bool> FaceValue(Func<int, int, bool> comparer, int amount)
		{
			return delegate(Piece p)
			{
				return comparer(ParseFaceValue(p.GetPropertyValue("Face")), amount);
			};
		}

		public static int ParseFaceValue(string number)
		{
			switch(number) 
			{
			case "One":
				return 1;
			case "Two":
				return 2;
			case "Three":
				return 3;
			case "Four":
				return 4;
			case "Five":
				return 5;
			case "Six":
				return 6;
			default:
				return 0;
			}
		}
	}


}
