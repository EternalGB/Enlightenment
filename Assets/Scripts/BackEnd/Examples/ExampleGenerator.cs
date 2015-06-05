/*
using System.Collections.Generic;
using Facet.Combinatorics;
using UnityEngine;
using System;

public class ExampleGenerator<T> where T : Piece
{

	public static List<Board<T>> GenerateAllExamples(int width, int height)
	{
		Debug.Log ("Generating all pieces");
		List<Piece> pieces = default(T).GetAllPieces();
		Debug.Log ("Generating all variations of " + (width*height).ToString() + " pieces selected from " + pieces.Count);
		List<Board<T>> examples = new List<Board<T>>();

		Debug.Log ("Instantiating Variations object");
		Variations<Piece> variations = new Variations<Piece>(pieces,width*height, GenerateOption.WithRepetition);
		Debug.Log ("There will be " + variations.Count + " variations");
		int count = 0;
		Debug.Log ("Processing Variations");
		long startTime = DateTime.Now.Ticks;
		foreach(IList<Piece> example in variations) {


			Board<T> board = new Board<T>(width,height);
			for(int x = 0; x < width; x++) {
				for(int y = 0; y < height; y++) {
					board.SetPiece(x,y,(T)example[x + width*y]);
				}
			}
			examples.Add(board);

			count++;
		}
		Debug.Log ("Processing finished in " + (TimeSpan.FromTicks(DateTime.Now.Ticks - startTime)).TotalMilliseconds + " milliseconds");
		return examples;
	}



}
*/
