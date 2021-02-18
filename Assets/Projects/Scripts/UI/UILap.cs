using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILap : MonoBehaviour
{
    private TextMeshProUGUI lapText;
    [SerializeField] private LapManager lapManager;
    void Start()
    {
        lapText = GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        lapText.text = "Lap "+ lapManager.currentLap + "/" + lapManager.totalLap;
    }
}
