using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   
    public float scrollSpeed;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    float newPos;
    void Update()
    {


        newPos = Mathf.Repeat(newPos, 10);
        newPos += Time.deltaTime * scrollSpeed;

        transform.position = startPos + Vector3.up*newPos;
    }
}

