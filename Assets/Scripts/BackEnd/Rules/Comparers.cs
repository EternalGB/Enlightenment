using System;

public static class Comparers<T> where T : IComparable
{

	public static bool GreaterThan(T x, T y)
	{
		return x.CompareTo(y) > 0;
	}

	public static bool GreaterThanOrEqualTo(T x, T y)
	{
		return x.CompareTo(y) >= 0;
	}

	public static bool Equal(T x, T y)
	{
		return x.CompareTo(y) == 0;
	}

	public static bool LessThan(T x, T y)
	{
		return x.CompareTo(y) < 0;
	}

	public static bool LessThanOrEqualTo(T x, T y)
	{
		return x.CompareTo(y) <= 0;
	}

}
