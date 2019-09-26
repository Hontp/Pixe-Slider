using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScroll : MonoBehaviour
{
    public float pixelsPerTick = 0f;
    private float tileSize = 16f;
    public float scrollAmount;
    public float distance;
    public float y;
    private RawImage walls;


    public float terminalVelocity;
    public float minFallSpeed;

    public float previousYVelocity;

    public Rigidbody2D player;

    public int TILESIZE = 16;

    // Start is called before the first frame update
    void Start()
    {
        walls = GetComponent<RawImage>();
        y = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BaseScroll();
        PlayerOffset();
        WallScroller();

    }

    void BaseScroll()
    {
        scrollAmount += (pixelsPerTick / tileSize) * Time.fixedDeltaTime;
    }

    void PlayerOffset()
    {

        if (player.velocity.y < 0f)
        {
            distance -= player.velocity.y * Time.fixedDeltaTime * TILESIZE / (TILESIZE * 20);
        }
        else
        {
            distance += (pixelsPerTick / tileSize) * Time.fixedDeltaTime;
        }


        if (pixelsPerTick < minFallSpeed)
        {
            pixelsPerTick = minFallSpeed;
        }

        if (pixelsPerTick > terminalVelocity)
        {
            pixelsPerTick = terminalVelocity;
        }

        y += player.velocity.y * Time.fixedDeltaTime * TILESIZE / (TILESIZE * 20);
    }

    void WallScroller()
    {

        Rect uvRect = new Rect(0, -scrollAmount - y / 2, 1, 1);
        walls.uvRect = uvRect;
    }

}
