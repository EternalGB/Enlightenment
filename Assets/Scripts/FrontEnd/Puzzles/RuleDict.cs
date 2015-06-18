using System.Collections.Generic;

public static class RuleDict
{

	public static Dictionary<string, Rule> rules = new Dictionary<string, Rule>
	{
		{"Dice1", new Rule(new AllHave(new PropertyCheckers.PropertyHasValue("Colour", "Blue")))},
		{"Dice2", new Rule(new ExistsOneHas(new PropertyCheckers.PropertyHasValue("Face", "One")))},
		{"Dice3", new Rule(new AllHave(new PropertyCheckers.Not(new PropertyCheckers.PropertyHasValue("Colour", "Black"))))},
		{"Dice4", new Rule(new ExistsOneHas(new PropertyCheckers.Not(new PropertyCheckers.PropertyHasValue("Face","Two"))))},
		{"Dice5", new Rule(new ExistsOneHas(new PropertyCheckers.PropertyHasValue("Colour", "Red")))},
		{"Dice6", new Rule(new AllHave(new PropertyCheckers.PropertyHasValue("Face", "Six")))},
		{"Dice7", new Rule(new And(new AllHave(new PropertyCheckers.PropertyHasValue("Face","Two")),
			                           new AllHave(new PropertyCheckers.PropertyHasValue("Colour","Red"))))},
		{"Dice8", new Rule(new And(new AllHave(new PropertyCheckers.Not(new PropertyCheckers.PropertyHasValue("Face","Three"))),
			                           new AllHave(new PropertyCheckers.PropertyHasValue("Colour","Black"))))},
		{"Dice9", new Rule(new Or(new AllHave(new PropertyCheckers.PropertyHasValue("Colour","Red")),
			                          new AllHave(new PropertyCheckers.PropertyHasValue("Colour","Blue"))))},
		{"Dice10", new Rule(new Or(new ExistsOneHas(new PropertyCheckers.Not(new PropertyCheckers.PropertyHasValue("Colour","White"))),
			                           new AllHave(new PropertyCheckers.PropertyHasValue("Colour","Black"))))}
	};

}
