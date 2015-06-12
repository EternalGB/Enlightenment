using UnityEngine;
using System.Collections;

public class NormalisationTest : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Atom A = new AllHave(new PropertyCheckers.PropertyHasValue("Face","One"));
		Atom B = new ExistsOneHas(new PropertyCheckers.PropertyHasValue("Colour", "Black"));
		Rule rule1 = new Rule(new Not(new And(A,B)));
		Rule rule2 = new Rule(new Or(A.Negate(), B.Negate()));

		Debug.Log (rule1.ToString());
		Debug.Log (rule2.ToString());

		Debug.Log (rule1.ToNormalForm().ToString());
		Debug.Log (rule2.ToNormalForm().ToString());

		Debug.Log ("Unormalised - " + rule1.Equals(rule2));
		Debug.Log ("Normalised - " + rule1.ToNormalForm().Equals(rule2.ToNormalForm()));
	}
	

}

