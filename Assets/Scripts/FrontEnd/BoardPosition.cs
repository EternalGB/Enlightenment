using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BoardPosition : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IDragHandler
{
	
	public int x, y;
	public GameController gc;
	bool moving = false;
	bool inside = false;
	public RectTransform ghost;

	public void OnPointerDown(PointerEventData data)
	{
		if(gc.PieceExistsAt(x,y)) {
			gc.heldPiece = gc.GetPiece(x,y);
			moving = true;
		}
	}

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


	public void OnDrag(PointerEventData data)
	{
		if(moving) {
			ghost.gameObject.SetActive(true);
			ghost.GetComponent<Image>().sprite = gc.GetPieceImage(gc.heldPiece);
			ghost.position = data.position;
		}
	}


	public void OnPointerUp(PointerEventData data)
	{
		if(moving && !inside) {
			gc.SetPiece(x,y, null);
			gc.SetPieceAtCursor(gc.heldPiece);
			ghost.gameObject.SetActive(false);
		} else if(gc.PieceExistsAt(x,y)) {
			gc.CyclePieceAt(x,y);
		}
		moving = false;
	}

}

