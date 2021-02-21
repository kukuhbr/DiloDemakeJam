using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingList;
    [SerializeField] private GameObject[] objectsList;
    [SerializeField] private Transform buildingContainer;
    [SerializeField] private Transform objectContainer;
    private GameObject[] tracks;
    public float padding;
    public int objectToSpawn;
    public float xRandom;
    public float zRandom;
    void Start()
    {
        tracks = GameObject.FindGameObjectsWithTag("Track");
        foreach (GameObject obj in tracks) {
            SpawnBuilding(obj.transform);
            SpawnObjects(obj.transform);
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


    int randomObject;
    Vector3 objectPos;
    void SpawnObjects(Transform anchor) {
        int nObjects = Random.Range(0, objectToSpawn);
        for(int i = 0; i < nObjects; i++) {
            float x = Random.Range(-xRandom, xRandom);
            float z = Random.Range(-zRandom, zRandom);
            randomObject = Random.Range(0, objectsList.Length);
            objectPos = anchor.position + new Vector3 (x, 0, z);
            Instantiate(objectsList[randomObject], objectPos, Quaternion.identity * Quaternion.Euler(0, 90, 0), objectContainer);
        }
    }
}
