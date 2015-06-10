using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public TextAsset dictJson;
	public PieceInfo pieceInfo;

	// Use this for initialization
	void Awake ()
	{
		pieceInfo = new PieceInfo(dictJson.text);
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

	// Update is called once per frame
	void Update ()
	{
	
	}
}

