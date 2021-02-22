using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReset : MonoBehaviour
{
    public Quaternion flipRotation;
    private Vector3 currentPos;
    private Vector3 anchorPos;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //currentPos = new Vector3(anchorPos.x, currentPos.y, anchorPos.z);
            transform.position = currentPos;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            currentPos = transform.position;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "TrackBalap")
        {
            anchorPos = collision.collider.transform.position;
        }
    }
}
