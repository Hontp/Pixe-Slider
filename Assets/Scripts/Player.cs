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

    private Rigidbody2D rb;

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
                //startTouchPos = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                if(touch.deltaPosition.x > swipeTolerance)
                {
                   // rb.AddForce(Vector2.right * jumpSpeed, ForceMode2D.Impulse);
                }

                if (touch.deltaPosition.x < -swipeTolerance)
                {
                    //rb.AddForce(Vector2.left * jumpSpeed, ForceMode2D.Impulse);
                }
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0) && (touchingWallLeft || touchingWallRight))
            {
            }

            if (Input.GetMouseButton(0) && (touchingWallLeft || touchingWallRight))
            {
                startTouchPos = Input.mousePosition;

            }

            if (Input.GetMouseButtonUp(0) && (touchingWallLeft || touchingWallRight))
            {

                float deltaSwipe = Input.mousePosition.x - startTouchPos.x;
                if ( Mathf.Abs(deltaSwipe)  > swipeTolerance)
                {
                    if(Mathf.Abs(deltaSwipe) < minjumpSpeed)
                    {
                        if (deltaSwipe > 0)
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

                        if(deltaSwipe > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * deltaSwipe * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
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
                                rb.AddForce(Vector2.right * deltaSwipe * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                    }

                    //rb.velocity = new Vector2(rb.velocity.x, -1f);

                }
            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("leftWall"))
        {
            touchingWallLeft = true;
            rb.velocity = new Vector2(0, 0f);
            rb.gravityScale = -2f;
        }
        if (collision.transform.CompareTag("rightWall"))
        {
            touchingWallRight = true;
            rb.velocity = new Vector2(0, 0f);
            rb.gravityScale = -2f;
        }

        if (collision.transform.CompareTag("ceil"))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.gravityScale = -0f;
        }
    }
}
