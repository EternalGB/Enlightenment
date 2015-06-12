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
		rule = new Rule(new AllHave(new PropertyCheckers.DiePiece.FaceValue(new Comparers<int>.GreaterThan(),2)));
	}

	public bool EvaluateExample(Board board)
	{
		return rule.Evaluate(board);
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

