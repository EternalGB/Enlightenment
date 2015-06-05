public interface INode
{

	bool Evaluate(Board board);

}

public class Not : INode
{

	public INode child;

	public Not(INode child)
	{
		this.child = child;
	}

	public bool Evaluate(Board board)
	{
		return !child.Evaluate(board);
	}

}

public class And : INode
{

	public INode lChild, rChild;

	public And(INode lChild, INode rChild)
	{
		this.lChild = lChild;
		this.rChild = rChild;
	}

	public bool Evaluate(Board board)
	{
		return lChild.Evaluate(board) && rChild.Evaluate(board);
	}

}

public class Or : INode
{

	public INode lChild, rChild;
	
	public Or(INode lChild, INode rChild)
	{
		this.lChild = lChild;
		this.rChild = rChild;
	}
	
	public bool Evaluate(Board board)
	{
		return lChild.Evaluate(board) || rChild.Evaluate(board);
	}

}

public interface IAtom : INode
{



}
