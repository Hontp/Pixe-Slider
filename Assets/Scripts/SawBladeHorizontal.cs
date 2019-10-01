using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeHorizontal : MonoBehaviour
{

    public float Speed;
    public float wallSpeed;
    public WallScroll myScroll;
    public float maxDistance;
    public float currentDistance;
    bool moveRight;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
       
        moveRight = true;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        wallSpeed = myScroll.speed;

        currentDistance = (transform.position - startPos).x;

        transform.position = transform.position + Vector3.up * wallSpeed;

        if(currentDistance >= maxDistance)
        {
            moveRight = false;
        }
        else if(currentDistance <= 0)
        {
            moveRight = true;
        }

        if (moveRight)
        {

            transform.position = transform.position + Vector3.right * Speed;
        }
        else
        {
            transform.position = transform.position + Vector3.right * -Speed;
        }


    }
}
