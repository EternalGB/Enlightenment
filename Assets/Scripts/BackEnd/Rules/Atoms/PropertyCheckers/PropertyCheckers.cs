using System;

public static class PropertyCheckers
{

	[System.Serializable]
	public struct Not : IPropertyChecker
	{

		IPropertyChecker child;

		public Not(IPropertyChecker child)
		{
			this.child = child;
		}

		public bool Check(Piece p)
		{
			return !child.Check(p);
		}

		public IPropertyChecker GetNegation()
		{
			return child;
		}

		public override string ToString ()
		{
			return string.Format ("NOT ({0})", child.ToString());
		}

	}

	[System.Serializable]
	public struct Identity : IPropertyChecker
	{

		public bool Check(Piece p)
		{
			return true;
		}

		public IPropertyChecker GetNegation()
		{
			return new Not(this);
		}

		public override string ToString()
		{
			return "Pieces";
		}
	}

	[System.Serializable]
	public struct PropertyHasValue : IPropertyChecker
	{
		string property, value;

		public PropertyHasValue(string property, string value)
		{
			this.property = property;
			this.value = value;
		}

		public bool Check(Piece p)
		{
			return p.GetPropertyValue(property).Equals(value);
		}

		public IPropertyChecker GetNegation()
		{
			return new Not(this);
		}

		public override string ToString ()
		{
			return string.Format ("{0} == {1}", property, value);
		}
	}




	public static class DiePiece
	{

		[System.Serializable]
		public struct FaceValue : IPropertyChecker
		{
			IComparer<int> comparer;
			int amount;

			public FaceValue(IComparer<int> comparer, int amount)
			{
				this.comparer = comparer;
				this.amount = amount;
			}

			public bool Check(Piece p)
			{
				return comparer.Compare(ParseFaceValue(p.GetPropertyValue("Face")), amount);
			}

			public IPropertyChecker GetNegation()
			{
				return new Not(this);
			}
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
