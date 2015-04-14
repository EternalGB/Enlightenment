using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class PieceCreator<T> : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler where T : IPiece
{

	public GameController<T> gc;
	public T piece;

	public void OnPointerDown(PointerEventData data)
	{
		gc.heldPiece = piece;
	}
	
	public void OnDrag (PointerEventData data)
	{
		//Debug.Log (name + " drag");
	}

	public void OnPointerUp(PointerEventData data)
	{

		if(gc.HasHeldPiece()) {
			gc.SetPieceAtCursor(gc.heldPiece);
		}

	}

}

