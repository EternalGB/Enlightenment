using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public TextAsset dictJson;
	public PieceInfo pieceInfo;
	Puzzle puzzle;



	// Use this for initialization
	void Awake ()
	{
		pieceInfo = new PieceInfo(dictJson.text);
	}

	public void SetPuzzle(Puzzle puzzle)
	{
		this.puzzle = puzzle;
	}

	public bool EvaluateExample(Board board)
	{
		return puzzle.rule.Evaluate(board);
	}

	public bool EvaluateRule(Rule rule)
	{
		if(rule != null) {
			Debug.Log (string.Format("Target Rule: {0}", puzzle.rule));
			Debug.Log (string.Format("Test Rule: {0}", rule));
			Debug.Log (string.Format("Target Normal Form {0}", puzzle.rule.ToNormalForm()));
			Debug.Log (string.Format("Test Normal Form {0}", rule.ToNormalForm()));
			return puzzle.rule.ToNormalForm().Equals(rule.ToNormalForm());
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

