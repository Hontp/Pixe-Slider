using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{

    public float Speed;
    public float wallSpeed;
    public Vector3 endPos;

    public int currentPointIndex;
    float Timer;

    private void Start()
    {
        currentPointIndex = 1;
        Timer = 0;
    }

    private void Update()
    {

        Timer += Time.deltaTime * Speed;

        transform.position = transform.position + Vector3.up * Timer;
                
    }
}
