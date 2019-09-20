using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 startTouchPos;

    public float swipeTolerance;
    public float jumpSpeed;

    public bool touchingWallRight;
    public bool touchingWallLeft;

    public float minjumpSpeed;
    public float friction;


    enum playerState {SLIDING, JUMPING, BRAKING};
    //playerState state = playerStat.SLIDING;

    private Rigidbody2D rb;
    public WallScroll ws;

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touchSupported)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                
            }

            if(touch.phase == TouchPhase.Stationary)
            {
                ws.pixelsPerTick -= friction;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                startTouchPos = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                if (Mathf.Abs(touch.deltaPosition.x) > swipeTolerance)
                {
                    if (Mathf.Abs(touch.deltaPosition.x) < minjumpSpeed)
                    {
                        if (touch.deltaPosition.x > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * minjumpSpeed * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);

                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                        else
                        {
                            if (touchingWallRight)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * -minjumpSpeed * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }

                    }
                    else
                    {

                        if (touch.deltaPosition.x > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * touch.deltaPosition * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                        else
                        {
                            if (touchingWallRight)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * touch.deltaPosition * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                    }

                }
            }
        }
        else
        {
            if (Input.GetAxis("Vertical") > 0f)
            {
                ws.pixelsPerTick -= Input.GetAxis("Vertical") * friction;
            }
            if (Input.GetMouseButtonDown(0) && (touchingWallLeft || touchingWallRight))
            {

            }

            if (Input.GetMouseButton(0) && (touchingWallLeft || touchingWallRight))
            {
                startTouchPos = Input.mousePosition;

                
            }


            if (Input.GetMouseButtonUp(0) && (touchingWallLeft || touchingWallRight))
            {

                float deltaPosition = Input.mousePosition.x - startTouchPos.x;
                if ( Mathf.Abs(deltaPosition)  > swipeTolerance)
                {
                    if(Mathf.Abs(deltaPosition) < minjumpSpeed)
                    {
                        if (deltaPosition > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * minjumpSpeed * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                
                                touchingWallLeft = false;
                            touchingWallRight = false;
                            rb.gravityScale = 2.5f;
                            }
                        }
                        else
                        {
                            if (touchingWallRight)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * -minjumpSpeed * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }

                    }
                    else
                    {

                        if(deltaPosition > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * deltaPosition * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                        else
                        {
                            if (touchingWallRight)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * deltaPosition * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                    }

                }
            }

        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("leftWall"))
        {
            touchingWallLeft = true;
            ws.pixelsPerTick -= rb.velocity.y;
            rb.velocity = new Vector2(0, 0f);
            rb.gravityScale = -2f;
        }
        if (collision.transform.CompareTag("rightWall"))
        {
            touchingWallRight = true;
            ws.pixelsPerTick -= rb.velocity.y;
            rb.velocity = new Vector2(0, 0f);
            rb.gravityScale = -2f;
        }

        if (collision.transform.CompareTag("ceil"))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.gravityScale = -2f;
        }
    }
}
