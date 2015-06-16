using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ExampleSerializationTest : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Board board = new Board(3,3);
		board.SetPiece(0,0, Piece.DiePiece("One","White"));
		board.SetPiece(0,1, Piece.DiePiece("Two","White"));
		board.SetPiece(0,2, Piece.DiePiece("Three", "Black"));

		Debug.Log (board.ToString());

		MemoryStream ms = new MemoryStream();
		BinaryFormatter serializer = new BinaryFormatter();
		serializer.Serialize(ms, board);

		ms.Seek(0, SeekOrigin.Begin);

		Board board2 = (Board)serializer.Deserialize(ms);
		Debug.Log (board2.ToString());
		Debug.Log (board.Equals(board2));
	}
	

}

