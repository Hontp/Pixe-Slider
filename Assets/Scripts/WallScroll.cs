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


    public float gravity;
    public float gravityVel;

    public float terminalVelocity;
    public float minFallSpeed;

    public float previousYVelocity;

    public Rigidbody2D player;

    public int TILESIZE = 16;

    public Vector2 startPos;

    public float speed;
    public Vector3 oldPos, deltaPos;

    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //walls = GetComponent<RawImage>();
        y = 0f;

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        oldPos = transform.position;

        if(player.velocity.y <= 0)
        {
            speed = (playerSpeed + pixelsPerTick / tileSize + gravityVel) * Time.deltaTime;
        }
        else 
        {
            speed = ( pixelsPerTick / tileSize) * Time.deltaTime;
        }

        gravityVel += gravity;

        distance += speed / 16;
        

        scrollAmount += speed;
       /* if (player.velocity.y < 0f)
        {
            distance -= player.velocity.y * Time.deltaTime * TILESIZE / (TILESIZE*20);
        }
        else
        {
           
        }*/


        if (pixelsPerTick < minFallSpeed)
        {
            pixelsPerTick = minFallSpeed;
        }

        if (pixelsPerTick > terminalVelocity)
        {
            pixelsPerTick = terminalVelocity;
        }


        //y = 0;
        //y += player.velocity.y * Time.deltaTime * TILESIZE / (TILESIZE * 20);
        //Rect uvRect = new Rect(0, -scrollAmount - y/2, 1, 1);


        //transform.position = new Vector2( startPos.x, (scrollAmount - y / 2)% (320/16) + startPos.y);
        transform.position = new Vector2(startPos.x, (scrollAmount) % (320 / 16) + startPos.y);


        deltaPos = oldPos - transform.position;
        //walls.uvRect = uvRect;

    }
}
