using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Can also go by the name post / check point in non-circular track
public class LapManager : MonoBehaviour
{
    public int totalLap;
    public int currentLap;
    // Lap reached is when player reached lap
    public static event Action OnLapReached;

    void Start()
    {
        currentLap = 1;
    }

    void Update()
    {

    }

    void InvokeLapReached()
    {
        Debug.Log("LapReached");
        if (OnLapReached != null) {
            OnLapReached();
        }
    }

    public void LapReached()
    {
        if (currentLap == totalLap) {
            InvokeLapReached();
            GameState.InvokeRaceEnd();
            return;
        }

        if (currentLap < totalLap)
            currentLap += 1;
        InvokeLapReached();
    }
}