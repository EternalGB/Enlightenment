using System;

public class FaceSum : Atom
{

	IComparer<int> countComparator;
	int amount;
	
	public FaceSum (IComparer<int> countComparator, int amount)
	{
		this.countComparator = countComparator;
		this.amount = amount;
	}

	public override bool Evaluate (Board board)
	{
		int sum = 0;
		for(int x = 0; x < board.Width; x++) {
			for(int y = 0; y < board.Height; y++) {
				if(board.PieceExistsAt(x,y)) {
					sum += PropertyCheckers.DiePiece.ParseFaceValue(board.GetPiece(x,y).GetPropertyValue("Face"));
				}
			}
		}
		return countComparator.Compare(sum, amount);
	}

	public override INode DeepClone()
	{
		return new FaceSum(countComparator, amount);
	}

	public override Atom Negate()
	{
		return new FaceSum(countComparator.GetNegation(), amount);
	}

	public override string ToString ()
	{
		return string.Format ("FaceSum {0} {1}", countComparator.ToString(), amount);
	}


}
