using System;

public class FaceSum : INode
{

	Func<int, int, bool> countComparator;
	int amount;
	
	public FaceSum (Func<int, int, bool> countComparator, int amount)
	{
		this.countComparator = countComparator;
		this.amount = amount;
	}

	public bool Evaluate (Board board)
	{
		int sum = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y)) {
					sum += PropertyCheckers.DiePiece.ParseFaceValue(board.GetPiece(x,y).GetPropertyValue("Face"));
				}
			}
		}
		return countComparator(sum, amount);
	}



}
