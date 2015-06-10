using System.Collections.Generic;

public interface INode
{

	bool Evaluate(Board board);

	List<INode> GetChildren();

	string ToString();

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
	
	public List<INode> GetChildren()
	{
		List<INode> children = new List<INode>();
		children.Add(child);
		return children;
	}

	public override string ToString ()
	{
		string cString;
		if(child.GetType().IsAssignableFrom(typeof(Atom)))
			cString = child.ToString();
		else
			cString = string.Format("({0})", child.ToString());
		return string.Format("NOT {0}", cString);
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


	public List<INode> GetChildren()
	{
		List<INode> children = new List<INode>();
		children.Add(lChild);
		children.Add(rChild);
		return children;
	}

	public override string ToString ()
	{
		string lString, rString;
		if(lChild.GetType().IsAssignableFrom(typeof(Atom)))
			lString = lChild.ToString();
		else
			lString = string.Format("({0})", lChild.ToString());

		if(rChild.GetType().IsAssignableFrom(typeof(Atom)))
			rString = rChild.ToString();
		else
			rString = string.Format("({0})", rChild.ToString());

		return string.Format("{0} AND {1}", lString, rString);

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


	public List<INode> GetChildren()
	{
		List<INode> children = new List<INode>();
		children.Add(lChild);
		children.Add(rChild);
		return children;
	}

	public override string ToString ()
	{
		string lString, rString;
		if(lChild.GetType().IsAssignableFrom(typeof(Atom)))
			lString = lChild.ToString();
		else
			lString = string.Format("({0})", lChild.ToString());
		
		if(rChild.GetType().IsAssignableFrom(typeof(Atom)))
			rString = rChild.ToString();
		else
			rString = string.Format("({0})", rChild.ToString());
		
		return string.Format("{0} OR {1}", lString, rString);
		
	}

}

public abstract class Atom : INode
{

	public abstract bool Evaluate(Board board);

	public abstract Atom Negate();


	public List<INode> GetChildren()
	{
		List<INode> children = new List<INode>();
		return children;
	}

}
