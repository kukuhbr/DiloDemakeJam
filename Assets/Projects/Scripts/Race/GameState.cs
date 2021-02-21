using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState : MonoBehaviour
{
    // Game start is when countdown started
    public static event Action OnGameStart;
    // Race start is when countdown ends, race started
    public static event Action OnRaceStart;
    // Race end is when player reached goal
    public static event Action OnRaceEnd;

    public static void InvokeGameStart()
    {
        Debug.Log("GameStarted");
        if (OnGameStart != null) {
            OnGameStart();
        }
    }

    public static void InvokeRaceStart()
    {
        Debug.Log("RaceStarted");
        if (OnRaceStart != null) {
            OnRaceStart();
        }
    }

    public static void InvokeRaceEnd()
    {
        Debug.Log("RaceEnd");
        if (OnRaceEnd != null) {
            OnRaceEnd();
        }
    }
}