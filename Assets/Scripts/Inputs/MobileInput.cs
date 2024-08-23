using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public void InvokeEventOnMoveLeftStarted()
    {
        GameInput.MoveLeftStarted.Invoke();
    }

    public void InvokeEventOnMoveLeftEnded()
    {
        GameInput.MoveLeftEnded.Invoke();
    }

    public void InvokeEventOnMoveRightStarted()
    {
        GameInput.MoveRightStarted.Invoke();
    }

    public void InvokeEventOnMoveRightEnded()
    {
        GameInput.MoveRightEnded.Invoke();
    }

    public void InvokeEventOnAttack()
    {
        GameInput.Attacked.Invoke();
    }
}
