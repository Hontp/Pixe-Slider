using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SpawnController = null;

    public GameObject  Wall = null;


    HazardSpawner spawner;
    WallScroll myScroll;

    bool hasraiseDiff;

    private void Start()
    {
        if ( SpawnController != null && Wall != null)
        {
            spawner = SpawnController.GetComponent<HazardSpawner>();
            myScroll = Wall.GetComponent<WallScroll>();

            spawner.spawnTime = 3.5f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (myScroll.distance * 20.0f > 100.0f && myScroll.distance * 20.0f < 250.0f)
        {
            spawner.distanceToSpawn = 9;
        }
        else if (myScroll.distance * 20.0f >= 250.0f && myScroll.distance * 20.0f < 500.0f)
        {
            spawner.distanceToSpawn = 8;
        }
        else if (myScroll.distance * 20.0f >= 500.0f && myScroll.distance * 20.0f < 750.0f)
        {
            spawner.distanceToSpawn = 7;
        }
        else if (myScroll.distance * 20.0f >= 1000.0f && myScroll.distance * 20.0f < 1250.0f)
        {
            spawner.distanceToSpawn = 6;
        }
        else if (myScroll.distance * 20.0f >= 1500.0f)
        {
            spawner.distanceToSpawn = 5;
        }

    }
}
