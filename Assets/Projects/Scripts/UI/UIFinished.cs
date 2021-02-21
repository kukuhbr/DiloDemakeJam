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
        GameState.OnGameEnd += OnGameEndHandler;
    }

    void OnGameEndHandler()
    {
        gameUI.SetActive(false);
        timerText.text = Timer.ConvertToString(timer.gameTimer);
        finishedUI.SetActive(true);
    }

    void OnDestroy()
    {
        GameState.OnGameEnd -= OnGameEndHandler;
    }
}
