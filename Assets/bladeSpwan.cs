using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeSpwan : MonoBehaviour
{

    public WallScroll myScroll;
    public GameObject sawBlade = null;
    public List<Transform> pathWay = null;
    bool hasSpawned;
    public float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        if (sawBlade != null)
        {
            sawBlade.GetComponent<SawBlade>().wayPoint = pathWay;
            sawBlade.GetComponent<SawBlade>().Speed = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (Mathf.Abs(Mathf.Sin(timePassed)) > 0.95f && !hasSpawned)
        {
            GameObject g = Instantiate(sawBlade, pathWay[0].position, sawBlade.transform.rotation, null) as GameObject;
            g.GetComponent<SawBlade>().wallSpeed = myScroll.playerSpeed;
            hasSpawned = true;   
        }

        if(Mathf.Abs(Mathf.Sin(timePassed)) < 0.1f)
        {
            hasSpawned = false;
        }
        
    }
}
