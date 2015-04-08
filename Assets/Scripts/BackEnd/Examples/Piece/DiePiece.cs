
public struct DiePiece : IPiece
{

	public enum Face
	{
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6
	}

	public enum Colour
	{
		Red, Blue, Black, White
	}

	public Face face;
	public Colour colour;

}
