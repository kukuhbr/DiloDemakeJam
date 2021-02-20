using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool isGoal;
    public bool isPassed;
    private LapManager lapManager;

    void Start()
    {
        lapManager = FindObjectOfType<LapManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Car" && !isPassed) {
            isPassed = true;
            lapManager.LapReached();
        }
    }
}
