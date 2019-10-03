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
        if (myScroll.distance * 20.0f > 100.0f && myScroll.distance * 20.0f < 500.0f)
        {
            spawner.spawnTime = 3.3f;
        }
        else if (myScroll.distance * 20.0f >= 500.0f && myScroll.distance * 20.0f < 1000.0f)
        {
            spawner.spawnTime = 2.3f;
        }
        else if (myScroll.distance * 20.0f >= 1500.0f && myScroll.distance * 20.0f < 1600.0f)
        {
            spawner.spawnTime = 1.3f;
        }
        else if (myScroll.distance * 20.0f >= 2000.0f && myScroll.distance * 20.0f < 2600.0f)
        {
            spawner.spawnTime = 1;
        }
        else if (myScroll.distance * 20.0f >= 3000.0f)
        {
            spawner.spawnTime = 0.5f;
        }

    }
}
