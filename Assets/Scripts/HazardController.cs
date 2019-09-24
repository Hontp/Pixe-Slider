using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    WallScroll wScroll;
    public float scrollAmount;


    // Start is called before the first frame update
    void Start()
    {
        wScroll = FindObjectOfType<WallScroll>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scrollAmount = wScroll.pixelsPerTick;
        transform.Translate(Vector2.up * (scrollAmount * Time.fixedDeltaTime), Space.World);
    }
}

