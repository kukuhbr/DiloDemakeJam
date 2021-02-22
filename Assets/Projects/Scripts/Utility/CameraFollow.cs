using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFS.Car.Movements;
using NFS.Car.Audio;

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
    private bool isRaceFinish = false;
    private CarAudio carAudio;
    void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
        followRigidbody = GetComponentInParent<Rigidbody>();
        gearEngine = GetComponentInParent<GearEngine>();
        carAudio = GetComponentInParent<CarAudio>();
        GameState.OnRaceEnd += OnRaceEnd;
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
                    xMod = Mathf.Lerp(0, xMod, (1-t) * Time.deltaTime);
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

    void OnRaceEnd()
    {
        yDistance = 4;
        zDistance = -4;
        rotationOffset += new Vector3(0, 0, 25f);
        StartCoroutine(EndCoroutine());
    }

    IEnumerator EndCoroutine()
    {
        while (gearEngine.GetCurrentSpeed() > 2f) {
            yield return null;
        }
        while (yDistance - 2f > .3f) {
            if (yDistance > 2f) {
                yDistance = Mathf.Lerp(yDistance, 2f, Time.deltaTime);
            }
            if (xDistance > -2f) {
                xDistance = Mathf.Lerp(xDistance, -2f, Time.deltaTime);
            }
            yield return null;
        }
        carAudio.PlayOneShot(1);
    }

    void OnDestroy()
    {
        GameState.OnRaceEnd -= OnRaceEnd;
    }
}
