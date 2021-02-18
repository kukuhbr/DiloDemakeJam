using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        GameState.InvokeGameStart();
    }

    void Update()
    {

    }


}
