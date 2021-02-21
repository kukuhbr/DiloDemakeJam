using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFS.Car.Movements;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;
    public float xDistance;
    public float yDistance;
    public float zDistance;
    public float maxZDistance;
    public Vector3 rotationOffset;
    private Rigidbody followRigidbody;
    private GearEngine gearEngine;
    private Transform parentTransform;
    void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
        followRigidbody = GetComponentInParent<Rigidbody>();
        gearEngine = GetComponentInParent<GearEngine>();
    }

    private float xMod;
    private float zMod;
    void Update()
    {
        if (Input.GetButton("Mirror")) {
            transform.localPosition = new Vector3(0, yDistance, zDistance);
        } else {
            float t = gearEngine.GetCurrentSpeed() / gearEngine.GetMaxSpeed();
            if (gearEngine.GetCurrentSpeed() > 3f) {
                if (Input.GetButton("Horizontal")) {
                    xMod = xDistance * Input.GetAxis("Horizontal");
                    xMod = Mathf.Lerp(0, xMod, 1-t);
                } else {
                    xMod = Mathf.Lerp(xMod, 0, Time.deltaTime);
                }
            } else {
                xMod = Mathf.Lerp(xMod, 0, Time.deltaTime);
            }
            zMod = Mathf.Lerp(zDistance, maxZDistance, t);
            transform.localPosition = new Vector3 (0 + xMod, yDistance, -zMod);
        }
        transform.LookAt(followObject);
        transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);
    }
}
