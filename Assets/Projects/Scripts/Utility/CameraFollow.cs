using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;
    void Start()
    {

    }

    void Update()
    {
        Vector3 target = followObject.position;
        target += new Vector3 (0, 1.5f, -5f);
        transform.position = target;
    }
}
