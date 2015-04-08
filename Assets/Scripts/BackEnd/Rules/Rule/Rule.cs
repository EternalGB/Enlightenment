
public class Rule<T> where T : IPiece
{

	INode<T> root;

	public Rule(INode<T> root)
	{
		this.root = root;
	}

	public bool Evaluate(Board<T> board)
	{
		return root.Evaluate(board);
	}

	public void Negate()
	{
		Not<T> newRoot = new Not<T>(root);
		root = newRoot;
	}

	public void And(INode<T> node)
	{
		And<T> newRoot = new And<T>(root,node);
		root = newRoot;
	}

	public void Or(INode<T> node)
	{
		Or<T> newRoot = new Or<T>(root,node);
		root = newRoot;
	}

}
