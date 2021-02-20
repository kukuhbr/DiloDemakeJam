using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Timer myTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject lapTimerContainer;
    private TextMeshProUGUI[] lapTimerText;
    private DateTime timeDisplay;
    private int lapCounter = 0;

    void Start()
    {
        lapTimerText = lapTimerContainer.GetComponentsInChildren<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        if (myTimer.gameTimer > 0) {
            timerText.text = Timer.ConvertToString(myTimer.gameTimer);
        } else {
            timerText.text = "00:00.00";
        }

        // for (int i = 0; i < lapTimerText.Length; i++) {
        //     if (i < myTimer.lapTimer.Count) {
        //         lapTimerText[i].text = Timer.ConvertToString(myTimer.lapTimer[i]);
        //     } else {
        //         lapTimerText[i].text = "--:--.--";
        //     }
        // }
    }
}
