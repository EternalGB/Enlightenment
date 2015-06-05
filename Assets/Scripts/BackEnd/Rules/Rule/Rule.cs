
public class Rule
{

	INode root;

	public Rule(INode root)
	{
		this.root = root;
	}

	public bool Evaluate(Board board)
	{
		return root.Evaluate(board);
	}

	public void Negate()
	{
		Not newRoot = new Not(root);
		root = newRoot;
	}

	public void And(INode node)
	{
		And newRoot = new And(root,node);
		root = newRoot;
	}

	public void Or(INode node)
	{
		Or newRoot = new Or(root,node);
		root = newRoot;
	}

}
