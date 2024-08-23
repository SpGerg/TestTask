using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private bool _isLeft;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isLeft)
        {
            GameInput.MoveLeftStarted.Invoke();
        }
        else
        {
            GameInput.MoveRightStarted.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isLeft)
        {
            GameInput.MoveLeftEnded.Invoke();
        }
        else
        {
            GameInput.MoveRightEnded.Invoke();
        }
    }
}
