using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   
    private float scrollSpeed = 5;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    float newPos;
    void Update()
    {


        newPos = Mathf.Repeat(newPos, 5);
        newPos += Time.deltaTime * scrollSpeed;

        transform.position = startPos + Vector3.up*newPos;
    }
}

