public static class DiePiecePropertyCheckers
{

	public static bool IsOne(Piece piece)
	{
		return piece.GetPropertyValue("Face") == "One";
	}

	public static bool IsBlue(Piece piece)
	{
		return piece.GetPropertyValue("Colour") == "Blue";
	}



}
