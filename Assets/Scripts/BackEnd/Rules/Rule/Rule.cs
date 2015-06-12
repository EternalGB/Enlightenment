using System.Collections.Generic;
using System;

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

	public Rule ToNormalForm()
	{
		return new Rule(Normalise(root));
	}

	static INode Normalise(INode node)
	{
		Type nodeType = node.GetType();
		if(nodeType.IsAssignableFrom(typeof(Not))) {
			Not notNode = node as Not;
			Type childType = notNode.child.GetType();
			//Double Negation
			if(childType.IsAssignableFrom(typeof(Not))) {
				return Normalise((notNode.child as Not).child);
			//Not and -> or not
			} else if(childType.IsAssignableFrom(typeof(And))) {
				And childAnd = notNode.child as And;
				return Normalise(new Or(new Not(childAnd.lChild), new Not(childAnd.rChild)));
			//Not or -> and not
			} else if(childType.IsAssignableFrom(typeof(Or))) {
				Or childOr = notNode.child as Or;
				return Normalise(new And(new Not(childOr.lChild), new Not(childOr.rChild)));
			//Not atom with property -> atom with not property
			} else {
				Atom childAtom = notNode.child as Atom;
				return childAtom.Negate();
			}
		} else if(nodeType.IsAssignableFrom(typeof(And))) {
			And andNode = node as And;
			return new And(Normalise(andNode.lChild), Normalise(andNode.rChild));
		} else if(nodeType.IsAssignableFrom(typeof(Or))) {
			Or orNode = node as Or;
			return new Or(Normalise(orNode.lChild), Normalise(orNode.rChild));
		} else {
			return node;
		}
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
