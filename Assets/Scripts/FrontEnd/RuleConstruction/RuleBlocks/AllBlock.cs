using UnityEngine;
using System.Collections;

public class AllBlock : RuleBlock
{

	AllHave node;
	public PropertyCheckSelector filterSelector, checkSelector;

	void Awake()
	{
		node = new AllHave(null);
		filterSelector.OnCheckerSelected += SetPropertyFilter;
		checkSelector.OnCheckerSelected += SetPropertyCheck;
	}

	public override INode GetNode ()
	{
		return node;
	}

	public void SetPropertyFilter(IPropertyChecker checker)
	{
		node.SetFilter(checker);
	}
	
	public void SetPropertyCheck(IPropertyChecker checker)
	{
		node.SetPropertyCheck(checker);
	}

}

