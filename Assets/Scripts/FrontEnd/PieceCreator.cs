using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class PieceCreator<T> : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler where T : IPiece
{

	public GameController<T> gc;
	public T piece;
	public RectTransform ghost;

	public void OnPointerDown(PointerEventData data)
	{
		gc.heldPiece = piece;
		ghost.gameObject.SetActive(true);
		//ghost.GetComponent<Image>().color = new Color(255,255,255,128);
		ghost.GetComponent<Image>().sprite = gc.GetPieceImage(piece);
		ghost.position = data.position;
	}
	
	public void OnDrag (PointerEventData data)
	{
		if(gc.HasHeldPiece()) {
			ghost.position = data.position;
		}
	}

	public void OnPointerUp(PointerEventData data)
	{

		if(gc.HasHeldPiece()) {
			gc.SetPieceAtCursor(gc.heldPiece);
			ghost.gameObject.SetActive(false);
		}

	}

}

