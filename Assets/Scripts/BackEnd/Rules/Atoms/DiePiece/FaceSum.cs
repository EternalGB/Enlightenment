using System;

public class FaceSum : INode<DiePiece>
{

	Func<int, int, bool> countComparator;
	int amount;
	
	public FaceSum (Func<int, int, bool> countComparator, int amount)
	{
		this.countComparator = countComparator;
		this.amount = amount;
	}

	public bool Evaluate (Board<DiePiece> board)
	{
		int sum = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y)) {
					sum += (int)board.GetPiece(x,y).face;
				}
			}
		}
		return countComparator(sum, amount);
	}


}
