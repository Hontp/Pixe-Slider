﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollspace : MonoBehaviour
{
    public WallScroll ws;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ws.speed * 16f/320f * Vector2.down);
    }
}
