using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingList;
    [SerializeField] private Transform buildingContainer;
    private GameObject[] tracks;
    public float padding;
    void Start()
    {
        tracks = GameObject.FindGameObjectsWithTag("Track");
        foreach (GameObject obj in tracks) {
            SpawnBuilding(obj.transform);
        }
    }

    private int randomBuilding;
    Quaternion orientation;
    void SpawnBuilding(Transform anchor) {
        Vector3 buildingPos = anchor.position;
        randomBuilding = Random.Range(0, buildingList.Length);
        orientation = Quaternion.identity;
        Instantiate(buildingList[randomBuilding], buildingPos + anchor.right * -padding, orientation, buildingContainer);
        randomBuilding = Random.Range(0, buildingList.Length);
        orientation *= Quaternion.Euler(0, 180, 0);
        Instantiate(buildingList[randomBuilding], buildingPos + anchor.right * padding, orientation, buildingContainer);
    }
}
