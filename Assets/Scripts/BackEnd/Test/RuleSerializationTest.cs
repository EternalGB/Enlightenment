using UnityEngine;
using System.Collections;
using LitJson;

public class RuleSerializationTest : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Rule rule = new Rule(new AllHave(new PropertyCheckers.PropertyHasValue("Colour", "Blue")));
		string ruleJson = JsonMapper.ToJson(rule);
		Debug.Log (ruleJson);

		JsonData data = JsonMapper.ToObject(ruleJson);
		Debug.Log(data.ToString());
	}
	

}

