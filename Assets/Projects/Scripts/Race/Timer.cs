using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public float gameTimer;
    public List<float> lapTimer;
    private bool isTimerShouldRecord;
    private bool isRaceStarted;
    void Start()
    {
        GameState.OnGameStart += OnGameStartHandler;
        GameState.OnRaceStart += OnRaceStartHandler;
        LapManager.OnLapReached += OnLapReachedHandler;
        GameState.OnRaceEnd += OnRaceEndHandler;
        lapTimer = new List<float>();
        GameState.InvokeGameStart();
    }

    void Update()
    {
        if (isTimerShouldRecord) {
            gameTimer += Time.deltaTime;
        }

        if (!isRaceStarted) {
            if (gameTimer > 0) {
                isRaceStarted = true;
                GameState.InvokeRaceStart();
            }
        }
    }

    float GetLapDuration(int lap) {
        if (lap < 0 || lap >= lapTimer.Count) return -1;
        if (lap == 0) {
            return lapTimer[0];
        } else {
            return (lapTimer[lap] - lapTimer[lap-1]);
        }
    }

    public static string ConvertToString(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds((double) time);
        return timeSpan.ToString(@"mm\:ss\.ff");
    }

    void OnGameStartHandler()
    {
        gameTimer = -3f;
        isTimerShouldRecord = true;
    }

    void OnRaceStartHandler()
    {
        gameTimer = 0f;
    }

    void OnLapReachedHandler()
    {
        lapTimer.Add(gameTimer);
    }

    void OnRaceEndHandler()
    {
        Debug.Log("Race ended");
        isTimerShouldRecord = false;
    }

    void OnDestroy()
    {
        GameState.OnGameStart -= OnGameStartHandler;
        GameState.OnRaceStart -= OnRaceStartHandler;
        LapManager.OnLapReached -= OnLapReachedHandler;
        GameState.OnRaceEnd -= OnRaceEndHandler;
    }
}
