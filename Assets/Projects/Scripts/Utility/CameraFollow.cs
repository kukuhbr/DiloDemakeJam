using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;
    public float yDistance;
    public float maxZDistance;
    public float zDistance;
    public Vector3 rotationOffset;
    public float cameraCatchUpSpeed;
    private float _catchUpSpeed;
    void Start()
    {

    }

    void Update()
    {
        Vector3 target = followObject.position;
        if (Input.GetButton("Mirror")) {
            transform.position = target + followObject.up * yDistance + followObject.forward * 4f;

        } else {
            target += followObject.up * yDistance + followObject.forward * -zDistance;
            if (Input.GetButtonUp("Mirror")) {
                transform.position = target;
            } else {
                Vector3 diff = target - transform.position;
                if (diff.magnitude > 0.1f) {
                    if (diff.magnitude > maxZDistance) {
                        _catchUpSpeed = cameraCatchUpSpeed * 4;
                        //transform.position = target;
                    } else {
                        _catchUpSpeed = cameraCatchUpSpeed;
                    }
                    transform.position += diff.normalized * Time.deltaTime * _catchUpSpeed;
                }

                //transform.position = Vector3.Slerp(transform.position, target, Time.fixedDeltaTime * cameraCatchUpSpeed);
                //transform.position = target;
            }
        }
        transform.LookAt(followObject);
        transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);
    }
}
