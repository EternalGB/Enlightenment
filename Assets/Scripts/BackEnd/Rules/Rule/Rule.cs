using System.Collections.Generic;

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

	public void And(Rule rule)
	{
		And newRoot = new And(root, rule.root);
		root = newRoot;
	}

	public void Or(Rule rule)
	{
		Or newRoot = new Or(root, rule.root);
		root = newRoot;
	}

	public override string ToString()
	{
		return root.ToString();
	}

	public override bool Equals (object obj)
	{
		Rule other = obj as Rule;
		if(other == null)
			return false;

		return ToString().Equals(other.ToString());
	}

	public override int GetHashCode ()
	{
		throw new System.NotImplementedException();
	}

}
