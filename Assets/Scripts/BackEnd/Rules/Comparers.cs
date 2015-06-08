using System;

public interface IComparer<T>
{
	bool Compare(T x, T y);

	IComparer<T> GetNegation();
}

public static class Comparers<T> where T : IComparable
{

	public struct GreaterThan : IComparer<T>
	{
		public bool Compare(T x, T y)
		{
			return x.CompareTo(y) > 0;
		}

		public IComparer<T> GetNegation()
		{
			return new LessThanOrEqualTo();
		}

		public override string ToString ()
		{
			return ">";
		}
	}

	public struct GreaterThanOrEqualTo : IComparer<T>
	{
		public bool Compare(T x, T y)
		{
			return x.CompareTo(y) >= 0;
		}

		public IComparer<T> GetNegation()
		{
			return new LessThan();
		}

		public override string ToString ()
		{
			return ">=";
		}
	}

	public struct Equal : IComparer<T>
	{
		public bool Compare(T x, T y)
		{
			return x.CompareTo(y) == 0;
		}

		public IComparer<T> GetNegation()
		{
			return new NotEqual();
		}

		public override string ToString ()
		{
			return "==";
		}
	}

	public struct NotEqual : IComparer<T>
	{
		public bool Compare(T x, T y)
		{
			return x.CompareTo(y) != 0;
		}
		
		public IComparer<T> GetNegation()
		{
			return new Equal();
		}
		
		public override string ToString ()
		{
			return "!=";
		}
	}

	public struct LessThan : IComparer<T>
	{
		public bool Compare(T x, T y)
		{
			return x.CompareTo(y) < 0;
		}
		
		public IComparer<T> GetNegation()
		{
			return new GreaterThanOrEqualTo();
		}

		public override string ToString ()
		{
			return "<";
		}
	}

	public struct LessThanOrEqualTo : IComparer<T>
	{
		public bool Compare(T x, T y)
		{
			return x.CompareTo(y) <= 0;
		}
		
		public IComparer<T> GetNegation()
		{
			return new GreaterThan();
		}

		public override string ToString ()
		{
			return "<=";
		}
	}
	

}
