using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScroll : MonoBehaviour
{
    public float pixelsPerTick;
    private float tileSize = 16f;
    public float scrollAmount;
    public float distance;
    public float y;
    private RawImage walls;

    public float previousYVelocity;

    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        walls = GetComponent<RawImage>();
        y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scrollAmount += (pixelsPerTick / tileSize) * Time.deltaTime;
        if(player.velocity.y < 0f)
        {
            distance -= player.velocity.y * Time.deltaTime * 16f / 320f;
        }
        else
        {
            distance += (pixelsPerTick / tileSize) * Time.deltaTime;
        }
  


        y += player.velocity.y * Time.deltaTime * 16f/320f;
        Rect uvRect = new Rect(0, -scrollAmount - y, 1, 1);
        walls.uvRect = uvRect;

    }
}
