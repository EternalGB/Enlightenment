public static class DiePiecePropertyCheckers
{

	public static bool IsOne(DiePiece piece)
	{
		return piece.face == DiePiece.Face.One;
	}

	public static bool IsWhite(DiePiece piece)
	{
		return piece.colour == DiePiece.Colour.White;
	}

	public static bool IsBlack(DiePiece piece)
	{
		return piece.colour == DiePiece.Colour.Black;
	}

}
