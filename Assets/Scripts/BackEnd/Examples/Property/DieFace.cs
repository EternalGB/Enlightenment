using System;

public class DieFace : IProperty
{

	public enum Faces
	{
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6
	}

	public string GetPropertyName(int i)
	{
		if(i <= 0 || i >= 6)
			throw new ArgumentException("Outside of property index range");
		else
			return Enum.GetName(typeof(Faces),Enum.GetValues(typeof(Faces)).GetValue(i));
	}
}
