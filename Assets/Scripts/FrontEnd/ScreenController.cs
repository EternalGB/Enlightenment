using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ScreenController : MonoBehaviour
{

    public delegate void ScreenOpenEvent();
    public delegate void ScreenCloseEvent();

    public event ScreenOpenEvent OnOpenComplete;
    public event ScreenCloseEvent OnCloseComplete;

    public void DoOpen()
    {
        if(OnOpenComplete != null)
        {
            OnOpenComplete();
        }
    }

    public void DoClose()
    {
        if(OnCloseComplete != null)
        {
            OnCloseComplete();
        }
    }

}

