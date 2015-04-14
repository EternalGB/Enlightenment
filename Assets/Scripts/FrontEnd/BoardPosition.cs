using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class BoardPosition<T> : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler where T : IPiece
{
	
	public int x, y;
	public GameController<T> gc;
	bool moving = false;
	bool inside = false;

	public void OnPointerDown(PointerEventData data)
	{
		if(gc.PieceExistsAt(x,y)) {
			gc.heldPiece = gc.GetPiece(x,y);
			moving = true;
		}
	}

	public abstract T CyclePiece(T piece);

	public void OnPointerEnter(PointerEventData data)
	{
		gc.SetCursorPosition(x,y);
		inside = true;
	}

	public void OnPointerExit(PointerEventData data)
	{
		gc.SetCursorPosition(-1,-1);
		inside = false;
	}

	/*
	public void OnDrag(PointerEventData data)
	{
		if(gc.PieceExistsAt(x,y)) {
			moving = true;
		}
	}
	*/

	public void OnPointerUp(PointerEventData data)
	{
		if(moving && !inside) {
			gc.SetPiece(x,y, default(T));
			gc.SetPieceAtCursor(gc.heldPiece);
		} else if(gc.PieceExistsAt(x,y)) {
			gc.SetPieceAtCursor(CyclePiece(gc.GetPiece(x,y)));
		}
		moving = false;
	}

}
