using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeSpwan : MonoBehaviour
{

    public WallScroll myScroll;
    public GameObject sawBlade = null;
    public GameObject sawBladeHorizontal;
    public Transform startLocation;
    public Transform startLocationHorizontal;
    bool hasSpawned;
    bool spawnHorizontal;
    public float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        if (sawBlade != null)
        {
            sawBlade.GetComponent<SawBlade>().Speed = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    
        if (myScroll.distance * 20.0f < 500)
        {
            return;
        }

        if (Mathf.Abs(Mathf.Sin(timePassed)) > 0.95f && !hasSpawned)
        {

            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                spawnHorizontal = true;
            }
            else
            {
                spawnHorizontal = false;
            }
            
            GameObject g;
            if (spawnHorizontal)
            {
                g = Instantiate(sawBladeHorizontal, startLocationHorizontal.position, sawBladeHorizontal.transform.rotation, null) as GameObject;
                g.GetComponent<SawBladeHorizontal>().myScroll = myScroll;
            }
            else
            {
                g = Instantiate(sawBlade, startLocation.position, sawBlade.transform.rotation, null) as GameObject;
                g.GetComponent<SawBlade>().wallSpeed = myScroll.playerSpeed;
            }
           
            
            hasSpawned = true;   
        }

        if(Mathf.Abs(Mathf.Sin(timePassed)) < 0.1f)
        {
            hasSpawned = false;
        }
        
    }
}
