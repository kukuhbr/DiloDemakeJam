using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReset : MonoBehaviour
{
    public Quaternion flipRotation;
    public LineRenderer lineRenderer;
    private Vector3 currentPos;
    private Vector3 anchorPos;
    private Quaternion anchorRot;
    private GameObject[] tracks;
    private GameObject currentTrack;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        GetAllTracks();
    }

    // Update is called once per frame
    void Update()
    {
        currentTrack = GetCurrentTrack();
        anchorPos = currentTrack.transform.position;
        anchorRot = currentTrack.transform.rotation;
        //RaycastDetect();
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentPos = new Vector3(anchorPos.x, 0.0055f, anchorPos.z);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = currentPos;
            transform.rotation = anchorRot;
        }
        else
        {
            currentPos = transform.position;
        }
    }

    private void GetAllTracks()
    {
        tracks = GameObject.FindGameObjectsWithTag("Track");
    }

    private GameObject GetCurrentTrack()
    {
        int i = 0;
        Vector3 trackPosition;
        Vector3 diff;
        float distance = Mathf.Infinity;
        GameObject closest = null;
        while ((i < tracks.Length))
        {
            trackPosition = tracks[i].transform.position;
            diff = currentPos - trackPosition;
            float currDistance = diff.sqrMagnitude;
            if (currDistance < distance)
            {
                closest = tracks[i];
                distance = currDistance;
            }
            i = i + 1;
        }
        return closest;
    }

    private void RaycastDetect()
    {
        int layerMask = LayerMask.GetMask("Track");
        Debug.Log(layerMask);
        Vector3 down = new Vector3(currentPos.x, currentPos.y-100, currentPos.z);
        Vector3 startPos = new Vector3(currentPos.x, currentPos.y+100, currentPos.z);

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, down);
        

        RaycastHit hit;
        if (Physics.Raycast(startPos, down, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(
                transform.position, 
                down * hit.distance, 
                Color.yellow
                );
            string tag = hit.collider.tag;
            Debug.Log(hit.collider.gameObject);
            if (tag == "TrackBalap")
            {
                anchorPos = hit.collider.transform.position;
                anchorRot = hit.collider.transform.rotation;
            }
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
