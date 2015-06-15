using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public TextAsset dictJson;
	public PieceInfo pieceInfo;
	Rule rule;



	// Use this for initialization
	void Awake ()
	{
		pieceInfo = new PieceInfo(dictJson.text);
	}

	void Start()
	{
		rule = new Rule(new AllHave(new PropertyCheckers.PropertyHasValue("Colour", "Blue")));
	}

	public bool EvaluateExample(Board board)
	{
		return rule.Evaluate(board);
	}

	public bool EvaluateRule(Rule rule)
	{
		if(rule != null) {
			Debug.Log (string.Format("Target Rule: {0}", this.rule));
			Debug.Log (string.Format("Test Rule: {0}", rule));
			Debug.Log (string.Format("Target Normal Form {0}", this.rule.ToNormalForm()));
			Debug.Log (string.Format("Test Normal Form {0}", rule.ToNormalForm()));
			return this.rule.ToNormalForm().Equals(rule.ToNormalForm());
		} else {
			return false;
		}
	}



	public Sprite GetPieceImage(Piece piece)
	{
		if(piece == null)
			return pieceInfo.blankImage;
		else
			return pieceInfo.imageDict[piece];
	}

	public Piece CyclePiece(Piece piece)
	{
		return pieceInfo.CyclePiece(piece);
	}

}

