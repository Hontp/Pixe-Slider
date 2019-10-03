using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxBackground : MonoBehaviour
{
    public WallScroll ws;
    public float scrollMultiplier;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(startPos.x, (ws.scrollAmount * scrollMultiplier) % (320 / 16) + startPos.y);
    }
}
