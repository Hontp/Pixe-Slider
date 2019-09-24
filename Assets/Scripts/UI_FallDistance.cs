﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_FallDistance : MonoBehaviour
{
    public WallScroll ws;
    private Text label;
    public float distance;
    public int TILESIZE = 16;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = ws.distance * (20 * TILESIZE) / TILESIZE;
        int distanceInt = (int)distance;
        label.text = distanceInt.ToString() + "m";

    }
}
