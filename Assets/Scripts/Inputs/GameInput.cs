using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameInput
{
    public static UnityEvent MoveLeftStarted { get; } = new();

    public static UnityEvent MoveLeftEnded { get; } = new();

    public static UnityEvent MoveRightStarted { get; } = new();

    public static UnityEvent MoveRightEnded { get; } = new();

    public static UnityEvent Attacked { get; } = new();
}
