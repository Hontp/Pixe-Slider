using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    WallScroll wScroll;
    public float scrollAmount;

    public float extraVal;


    // Start is called before the first frame update
    void Start()
    {
        wScroll = FindObjectOfType<WallScroll>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //scrollAmount = wScroll.scrollAmount * 16/320;

        transform.Translate(Vector2.up * (wScroll.speed));
        //transform.position = new Vector2(transform.position.x, (wScroll.scrollAmount - wScroll.y / 2) % (320 / 16) + transform.position.y);
        // transform.position = new Vector2(transform.position.x, (Mathf.Round(transform.position.y * 16) / 16));
    }
}

