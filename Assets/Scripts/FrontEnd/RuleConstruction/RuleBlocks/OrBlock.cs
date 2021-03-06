using UnityEngine;
using System.Collections;

public class OrBlock : RuleBlock
{
	
	Or node;
	public RuleBlockSlot lChild, rChild;
	
	void Awake()
	{
		node = new Or(null, null);
		lChild.OnSlotFilled += LeftChildFilled;
		rChild.OnSlotFilled += RightChildFilled;
	}
	
	void LeftChildFilled (INode child)
	{
		node.lChild = child;
	}
	
	void RightChildFilled (INode child)
	{
		node.rChild = child;
	}
	
	public override INode GetNode ()
	{
		return node;
	}
	
	
}

