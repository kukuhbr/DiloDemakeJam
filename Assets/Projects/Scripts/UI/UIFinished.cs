using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIFinished : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject finishedUI;
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI timerText;
    void Start()
    {
        GameState.OnRaceEnd += OnRaceEndHandler;
    }

    void OnRaceEndHandler()
    {
        gameUI.SetActive(false);
        timerText.text = Timer.ConvertToString(timer.gameTimer);
        finishedUI.SetActive(true);
    }

    void OnDestroy()
    {
        GameState.OnRaceEnd -= OnRaceEndHandler;
    }
}
