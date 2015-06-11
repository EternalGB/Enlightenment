using UnityEngine;
using System.Collections;

public class NotBlock : RuleBlock
{
	
	Not node;
	public RuleBlockSlot child;
	
	void Awake()
	{
		node = new Not(null);
		child.OnSlotFilled += ChildFilled;
	}
	
	void ChildFilled (INode child)
	{
		node.child = child;
	}

	public override INode GetNode ()
	{
		return node;
	}
	
	
}

