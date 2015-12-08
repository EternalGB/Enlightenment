using UnityEngine;
using System.Collections;

public class ScreenSelectionController : MonoBehaviour
{

	public Animator initiallyOpen;

	Animator open;
	Animator previous;

	const string paramName = "Open";
	const string closedStateName = "Closed";
	const string openStateName = "Open";

	bool swapping = false;

	public DialogueWindow dialWindow;

	public void OnEnable()
	{
		if(initiallyOpen != null)
			SwapTo(initiallyOpen);
	}

	public void SwapTo(Animator anim)
	{
		StartCoroutine(DoSwap(anim));
	}

	public void GoBack()
	{
		StartCoroutine(DoSwap(previous));
	}

	IEnumerator DoSwap(Animator anim)
	{
		if(!swapping) {
			swapping = true;
			yield return StartCoroutine(CloseCurrent());
			yield return StartCoroutine(DoPanelOpen(anim));
			swapping = false;
		}
	}

	IEnumerator DoPanelOpen(Animator anim)
	{

		anim.gameObject.SetActive(true);
		//Debug.Log ("Opening " + anim.gameObject.name);
		anim.SetBool(paramName, true);
		bool stateReached = false;
		while(!stateReached) {
			stateReached = anim.GetCurrentAnimatorStateInfo(0).IsName("Open");
			yield return new WaitForEndOfFrame();
		}
		//Debug.Log ("Opening animation finished");
		open = anim;
        ScreenController sc;
        if (sc = open.GetComponent<ScreenController>())
        {
            sc.DoOpen();
        }
	}

	IEnumerator CloseCurrent()
	{
		if(open != null) {
			yield return StartCoroutine(DoPanelClose(open));
			previous = open;
            ScreenController sc;
            if (sc = previous.GetComponent<ScreenController>())
            {
                sc.DoClose();
            }
		}
	}

	IEnumerator DoPanelClose(Animator anim)
	{
		//Debug.Log ("Closing " + anim.gameObject.name);
		anim.SetBool(paramName, false);
		bool stateReached = false;
		while(!stateReached) {
			stateReached = anim.GetCurrentAnimatorStateInfo(0).IsName("Closed");
			yield return new WaitForEndOfFrame();
		}
		//Debug.Log ("Closing animation finished");
		anim.gameObject.SetActive(false);
	}

	public void DisplayMessage(string message, UnityEngine.Events.UnityAction callback)
	{
		dialWindow.DisplayMessage(message, callback);
	}

	public void HideMessage()
	{
		dialWindow.gameObject.SetActive(false);
	}

}

