public interface INode<T> where T : IPiece
{

	bool Evaluate(Board<T> board);

}

public class Not<T> : INode<T> where T : IPiece
{

	public INode<T> child;

	public Not(INode<T> child)
	{
		this.child = child;
	}

	public bool Evaluate(Board<T> board)
	{
		return !child.Evaluate(board);
	}

}

public class And<T> : INode<T> where T : IPiece
{

	public INode<T> lChild, rChild;

	public And(INode<T> lChild, INode<T> rChild)
	{
		this.lChild = lChild;
		this.rChild = rChild;
	}

	public bool Evaluate(Board<T> board)
	{
		return lChild.Evaluate(board) && rChild.Evaluate(board);
	}

}

public class Or<T> : INode<T> where T : IPiece
{

	public INode<T> lChild, rChild;
	
	public Or(INode<T> lChild, INode<T> rChild)
	{
		this.lChild = lChild;
		this.rChild = rChild;
	}
	
	public bool Evaluate(Board<T> board)
	{
		return lChild.Evaluate(board) || rChild.Evaluate(board);
	}

}

public interface IAtom<T> : INode<T> where T : IPiece
{



}
