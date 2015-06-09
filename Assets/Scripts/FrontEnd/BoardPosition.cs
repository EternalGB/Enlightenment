using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BoardPosition : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IDragHandler
{
	
	public int x, y;
	public ExampleBuilder example;
	bool moving = false;
	bool inside = false;
	public RectTransform ghost;

	public void OnPointerDown(PointerEventData data)
	{
		if(example.PieceExistsAt(x,y)) {
			example.heldPiece = example.GetPiece(x,y);
			moving = true;
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		example.SetCursorPosition(x,y);
		inside = true;
	}

	public void OnPointerExit(PointerEventData data)
	{
		example.SetCursorPosition(-1,-1);
		inside = false;
	}


	public void OnDrag(PointerEventData data)
	{
		if(moving) {
			ghost.gameObject.SetActive(true);
			ghost.GetComponent<Image>().sprite = example.GetPieceImage(example.heldPiece);
			ghost.position = data.position;
		}
	}


	public void OnPointerUp(PointerEventData data)
	{
		if(moving && !inside) {
			example.SetPiece(x,y, null);
			example.SetPieceAtCursor(example.heldPiece);
			ghost.gameObject.SetActive(false);
		} else if(example.PieceExistsAt(x,y)) {
			example.CyclePieceAt(x,y);
		}
		moving = false;
	}

}

