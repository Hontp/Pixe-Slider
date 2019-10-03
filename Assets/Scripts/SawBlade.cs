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
    float totalSpeed;

    private void Start()
    {
        currentPointIndex = 1;
        Timer = 0;
    }

    private void Update()
    {

        Timer += Time.deltaTime;

        totalSpeed = Timer * Speed;

        transform.position = transform.position + Vector3.up * totalSpeed;
     
        
        if (!transform.GetComponent<SpriteRenderer>().isVisible && Timer > 5.0f)
        {
            Destroy(gameObject);

            Timer = 0;
        }
    }
}
