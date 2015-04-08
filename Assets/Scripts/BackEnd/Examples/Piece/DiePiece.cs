public struct DiePiece : IPiece
{

	public enum Face
	{
		None = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6
	}

	public enum Colour
	{
		None, Red, Blue, Black, White
	}

	public Face face;
	public Colour colour;

	public DiePiece(Face face, Colour colour)
	{
		this.face = face;
		this.colour = colour;
	}



}
