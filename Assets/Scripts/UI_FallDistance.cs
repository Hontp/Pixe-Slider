using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_FallDistance : MonoBehaviour
{
    public WallScroll ws;
    private Text label;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = ws.distance * 320f / 16f;
        int distanceInt = (int)distance;
        label.text = distanceInt.ToString() + "m";

    }
}
