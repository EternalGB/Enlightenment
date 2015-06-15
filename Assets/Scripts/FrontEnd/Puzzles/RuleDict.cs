using System.Collections.Generic;

public static class RuleDict
{

	public static Dictionary<string, Rule> rules = new Dictionary<string, Rule>
	{
		{"Dice1", new Rule(new AllHave(new PropertyCheckers.PropertyHasValue("Colour", "Blue")))}
	};

}
